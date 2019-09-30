using System.Collections;
using System.Collections.Generic;
using Normal.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class BowlingManager : MonoBehaviour
{

    public enum holdState
    {
        none,
        single,
        tenPin,
        ball,
        track
    }
    public enum menuState
    {
        none,
        home,
        modifiers,
        changeBall
    }

    public enum HandPoses { OpenHand, Fist, NoPose };
    public HandPoses pose = HandPoses.NoPose;
    public Vector3[] pos;

    private MLHandKeyPose[] _gestures;

    public static holdState holding = holdState.single;
    public static menuState currentMenuState;

    // ML-Related objects.  "controller" manages input from the Control and "persistentBehavior" is to manage objects staying in place between session (not yet implemented)
    private MLInputController controller;
    public MLPersistentBehavior persistentBehavior;

    // Declare GameObjects.  Public GameObjects are set in Unity Editor.  
    public GameObject mainCam, orientationCube, control, tenPinOrientation, ballPrefab, menu, ballMenu, modifierMenu, tutorialMenu, multiplayerMenu, controlCube, deleteLoader, menuCanvas, handCenter, multiplayerConfirmMenu, helpMenu, tutorialHelpMenu, deleteMenu, pinLimitMenu, trackObj, localPlayer, toggleMicButton, multiplayerStatusMenu, reachedPinLimit, objMenu, singleSelector, bowlingBallSelector, tenPinSelector, handMenu;
    public Text pinLimitText, multiplayerCodeText, multiplayerStatusText, multiplayerMenuCodeText, connectedPlayersText, pinsFallenText, noGravityText;
    public static GameObject menuControl;
    private GameObject bowlingBall, _realtime, pinObj;

    public Material transparent, activeMat;

    public Material[] ballMats, meshMats;

    public Transform singlePrefab, tenPinPrefab, pinHolder, singleNoGravityPrefab, tenPinNoGravityPrefab, meshHolder, planeHolder;

    public LineRenderer laserLineRenderer;

    public MeshRenderer mesh;

    private Vector3 endPosition, forcePerSecond;

    List<Vector3> Deltas = new List<Vector3>();

    private float timeHold = 3.0f, totalObjs = 0, objLimit = 50, timeHomePress = 0.01f, timeOfFirstHomePress, realtimeObjectCount = 0, timer = 0.0f, waitTime = 30.0f, menuMoveSpeed, connectedPlayers, deleteTimer = 0.0f;

    private Controller checkController;

    public static float growSpeed = 5f;

    public int pinsFallen = 0;

    //public static string ballColor;

    private string roomCode = "";

    public Image loadingImage;

    public Texture2D emptyCircle, check;

    private bool setHand = false, placed = false, holdingBall = false, menuOpened = false, ballMenuOpened = false, holdingBallMenu = true, noGravity = false, tutorialActive = true, tutorialBumperPressed, tutorialHomePressed, tutorialMenuOpened = false, settingsOpened = false, occlusionActive = true, firstHomePressed = false, joinedLobby = false, realtimeBowlingBall = false, multiplayerMenuOpen = false, pickedNumber = true, deletedCharacter = false, acceptedTerms = false, helpAppeared = false, pinLimitHelp = false, micActive = true, getLocalPlayer = false, toggledMic = false, networkConnected, pinLimitAppeared = false, dontSpawn, buttonLock = false;

    [SerializeField] private GameObject bowlingPinRealtimePrefab = null, bowlingPinRealtimeNoGravityPrefab, tenPinRealtimePrefab, tenPinRealtimeNoGravityPrefab, bowlingBallRealtimePrefab;
    public Realtime _realtimeObject;
    private GameObject pin;

    // AUDIO VARIABLES

    public AudioSource menuAudio;

    // Use this for initialization
    void Start()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);

        // If the user is new, open the tutorial menu
        CheckNewUser();
        // Start input from Control and Headpose
        MLInput.Start();
        print("Checking input..." + MLInput.IsStarted);

        // Get input from the Control, accessible via controller
        controller = MLInput.GetController(MLInput.Hand.Left);
        // When the Control's button(s) are pressed, run OnButtonDown
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnControllerButtonUp += OnButtonUp;

        // Initialize both line points at Vector3.Zero
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);

        // Access the object menu
        menuControl = GameObject.Find("ObjectMenu");

        checkController = control.GetComponentInChildren<Controller>();

        // Create the bowling ball at (100,100,100) so it cannot be seen by the user but can still be accessed
        bowlingBall = Instantiate(ballPrefab, new Vector3(100, 100, 100), tenPinOrientation.transform.rotation);

        MLHands.Start();
        _gestures = new MLHandKeyPose[2];
        _gestures[0] = MLHandKeyPose.OpenHand;
        _gestures[1] = MLHandKeyPose.Fist;
        MLHands.KeyPoseManager.EnableKeyPoses(_gestures, true, false);
        pos = new Vector3[1];


        menuMoveSpeed = Time.deltaTime * 2f;
        tenPinOrientation.transform.rotation = new Quaternion(0, mainCam.transform.rotation.y, 0, 0);

        MLNetworking.IsInternetConnected(ref networkConnected);
        if (networkConnected == false)
        {
            multiplayerStatusText.text = ("Multiplayer Status:\n" + "<color='red'>No Internet</color>");
        }
    }
    private void OnDisable()
    {
        MLInput.Stop();
        MLHands.Stop();
        MLInput.OnControllerButtonDown += OnButtonDown;
    }
    private void OnDestroy()
    {
        MLInput.Stop();
        MLHands.Stop();
    }
    private void OnEnable()
    {
        MLInput.Start();
        MLHands.Start();
        MLNetworking.IsInternetConnected(ref networkConnected);
        if (networkConnected == false)
        {
            multiplayerStatusText.text = ("Multiplayer Status:\n" + "<color='red'>No Internet</color>");
        }
        else
        {
            multiplayerStatusText.text = ("Multiplayer Status:\n" + "<color='red'>Not Connected</color>");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckGestures();
        if (timer < waitTime)
        {
            PlayTimer();
        }
        SetLine();

        // Always keep the control GameObject at the Control's position
        control.transform.position = controller.Position;
        control.transform.rotation = controller.Orientation;

        // If the user is not reading the tutorial menu, activate the line from the Control and prepare for the user to place objects
        if (tutorialActive == false)
        {
            PlaceObject();
        }
        else
        {
            // If the user presses anything while the tutorial is active, hide the tutorial and active the pointer
            if ((controller.Touch1Active || controller.TriggerValue >= 0.2f || tutorialBumperPressed == true || tutorialHomePressed == true) && tutorialMenuOpened == false)
            {
                tutorialMenu.SetActive(false);
                laserLineRenderer.material = activeMat;
                CheckNewUser();
            }
        }
        if (controller.Touch1Active)
        {
            if (pinLimitAppeared)
            {
                reachedPinLimit.SetActive(false);
            }
        }
        if (controller.TriggerValue <= 0.2f && tutorialMenuOpened == true)
        {
            tutorialMenuOpened = false;
        }
        if (_realtimeObject.connected)
        {
            connectedPlayers = 0;
            if (getLocalPlayer == false)
            {
                getLocalPlayer = true;
                foreach (GameObject obj in GameObject.FindObjectsOfType(typeof(GameObject)))
                {
                    if (obj.name == "VR Player(Clone)")
                    {
                        if (obj.GetComponent<RealtimeView>().isOwnedLocally)
                        {
                            localPlayer = obj;
                        }
                    }
                }
            }
            foreach (GameObject obj in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if (obj.name == "VR Player(Clone)")
                {
                    connectedPlayers += 1;
                    connectedPlayersText.text = ("Connected Players: " + connectedPlayers);
                }
            }
            multiplayerStatusText.text = ("Multiplayer Status:\n" + "<color='green'>Connected</color>");
        }
        Vector3 pos = mainCam.transform.position + mainCam.transform.forward * 1.0f;
        helpMenu.transform.position = Vector3.SlerpUnclamped(helpMenu.transform.position, pos, menuMoveSpeed);

        Quaternion rot = Quaternion.LookRotation(helpMenu.transform.position - mainCam.transform.position);
        helpMenu.transform.rotation = Quaternion.Slerp(helpMenu.transform.rotation, rot, menuMoveSpeed);

        if (pinLimitMenu.activeSelf)
        {
            if (GetUserGesture.GetGesture(MLHands.Left, MLHandKeyPose.OpenHand))
            {
                pinLimitMenu.SetActive(false);
            }
            if (controller.IsBumperDown)
            {
                pinLimitMenu.SetActive(false);
            }
        }
    }
    private void PlayTimer()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            if (holding == holdState.none && tutorialMenu.activeSelf == false && menu.activeSelf == false && menuOpened == false && totalObjs == 0)
            {
                if (!helpAppeared)
                {
                    helpAppeared = true;
                    tutorialHelpMenu.SetActive(true);

                    helpMenu.transform.position = mainCam.transform.position + mainCam.transform.forward * 10f;
                    helpMenu.transform.rotation = mainCam.transform.rotation;
                }
            }
            else
            {
                waitTime = 999999999999999999f;
                helpAppeared = true;
            }
        }
        else
        {
            //
        }
    }

    private void CheckGestures()
    {
        if (GetUserGesture.GetGesture(MLHands.Left, MLHandKeyPose.OpenHand))
        {
            pose = HandPoses.OpenHand;
            helpAppeared = true;
        }
        else if (GetUserGesture.GetGesture(MLHands.Left, MLHandKeyPose.Fist))
        {
            pose = HandPoses.Fist;
        }
        else
        {
            pose = HandPoses.NoPose;
        }

        if (pose != HandPoses.NoPose) ShowPoints();
        if (pose != HandPoses.Fist)
        {
            deleteTimer = 0.0f;
            handMenu.SetActive(true);
        }
        if (pose == HandPoses.NoPose)
        {
            deleteLoader.SetActive(false);
        }
    }

    private void ShowPoints()
    {

        if (pose == HandPoses.Fist)
        {
            if (!deleteLoader.activeSelf)
            {
                pos[0] = MLHands.Left.Middle.KeyPoints[0].Position;
                handCenter.transform.position = pos[0];
                handCenter.transform.LookAt(mainCam.transform.position);
            }
            if (!handCenter.activeSelf)
            {
                handCenter.SetActive(true);
            }
            handMenu.SetActive(false);
            deleteTimer += Time.deltaTime;
            print(deleteTimer);

            deleteLoader.SetActive(true);
            float percentComplete = deleteTimer / timeHold;
            loadingImage.fillAmount = percentComplete;

            if (deleteTimer > 3.0f)
            {
                ClearAllObjects();
                deleteLoader.SetActive(false);
            }
        }
        else if (pose == HandPoses.OpenHand)
        {
            deleteLoader.SetActive(false);
            if (!helpMenu.activeSelf)
            {
                helpMenu.SetActive(true);
            }
            if (!handCenter.activeSelf)
            {
                handCenter.SetActive(true);
            }
            pos[0] = MLHands.Left.Middle.KeyPoints[0].Position;
            handCenter.transform.position = pos[0];
            handCenter.transform.LookAt(mainCam.transform.position);
        }
    }
    private void SetLine()
    {
        RaycastHit rayHit;
        Vector3 heading = control.transform.forward;

        // Set the origin of the line to the controller's position.  Occurs every frame
        laserLineRenderer.SetPosition(0, controller.Position);

        if (Physics.Raycast(controller.Position, heading, out rayHit, 10.0f))
        {
            // If the ray hits an object, set the line's end position to the distance between the controller and that point
            endPosition = controller.Position + (control.transform.forward * rayHit.distance);
            laserLineRenderer.SetPosition(1, endPosition);

            if (settingsOpened && controller.TriggerValue <= 0.2f)
            {
                settingsOpened = false;
            }

            if (controller.TriggerValue >= 0.9f)
            {
                string objGameHit = rayHit.transform.gameObject.name;
                switch (objGameHit)
                {
                    case "Home":
                        MLInput.Stop();
                        MLHands.Stop();
                        MLInput.OnControllerButtonDown -= OnButtonDown;
                        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                        SceneManager.LoadScene("Main", LoadSceneMode.Single);
                        menuAudio.Play();
                        break;
                    case "JoinLobby":
                        if (_realtimeObject.connected)
                        {
                            multiplayerStatusMenu.SetActive(true);
                        }
                        else
                        {
                            multiplayerConfirmMenu.SetActive(true);
                        }
                        menuOpened = true;
                        menu.SetActive(false);
                        menuAudio.Play();
                        break;
                    case "AcceptTerms":
                        multiplayerMenu.SetActive(true);
                        multiplayerMenuOpen = true;
                        multiplayerConfirmMenu.SetActive(false);
                        menuAudio.Play();
                        break;
                    case "CancelTerms":
                        multiplayerConfirmMenu.SetActive(false);
                        menuOpened = true;
                        menu.SetActive(true);
                        menuAudio.Play();
                        break;
                    case "ChangeBall":
                        ballMenu.transform.position = mainCam.transform.position + (mainCam.transform.forward * 1.5f);
                        ballMenu.transform.LookAt(mainCam.transform.position);
                        ballMenu.SetActive(true);
                        menu.SetActive(false);
                        ballMenuOpened = true;
                        holdingBallMenu = true;
                        menuAudio.Play();
                        break;
                    case "Modifiers":
                        modifierMenu.SetActive(true);
                        menu.SetActive(false);
                        settingsOpened = true;
                        menuAudio.Play();
                        break;
                    case "Tutorial":
                        menuOpened = false;
                        menu.SetActive(false);
                        holding = holdState.none;
                        tutorialActive = true;
                        tutorialMenuOpened = true;
                        tutorialMenu.SetActive(true);
                        tutorialBumperPressed = false;
                        tutorialHomePressed = false;
                        PlayerPrefs.SetInt("hasPlayedBowling", 0);
                        CheckNewUser();
                        menuAudio.Play();
                        break;
                    case "YesPlease":
                        PlayerPrefs.SetInt("hasPlayedBowling", 0);
                        CheckNewUser();
                        tutorialMenuOpened = true;
                        tutorialActive = true;
                        tutorialHelpMenu.SetActive(false);
                        menuAudio.Play();
                        break;
                    case "NoThanks":
                        tutorialHelpMenu.SetActive(false);
                        menuAudio.Play();
                        break;
                    case "NewGame":
                        trackObj.SetActive(true);
                        holding = holdState.track;
                        menuAudio.Play();
                        break;
                    case "ToggleMic":
                        if (toggledMic == false)
                        {
                            toggledMic = true;
                            menuAudio.Play();
                            if (micActive == true)
                            {
                                micActive = false;
                                localPlayer.GetComponentInChildren<RealtimeAvatarVoice>().mute = true;
                                toggleMicButton.GetComponent<MeshRenderer>().material.mainTexture = emptyCircle;
                            }
                            else
                            {
                                micActive = true;
                                localPlayer.GetComponentInChildren<RealtimeAvatarVoice>().mute = false;
                                toggleMicButton.GetComponent<MeshRenderer>().material.mainTexture = check;
                            }
                        }
                        break;
                    case "LeaveRoom":
                        joinedLobby = false;
                        _realtime.GetComponent<Realtime>().Disconnect();
                        multiplayerStatusText.text = ("Multiplayer Status:\n" + "<color='red'>Not Connected</color>");
                        multiplayerStatusMenu.SetActive(false);
                        menuOpened = false;
                        menuAudio.Play();
                        break;
                    case "NoGravity":
                        if (!settingsOpened)
                        {
                            if (noGravity)
                            {
                                noGravity = false;
                                noGravityText.text = ("Disable Gravity");
                            }
                            else
                            {
                                noGravity = true;
                                noGravityText.text = ("Enable Gravity");
                            }
                            // modifierMenu.SetActive(false);
                            // menuOpened = false;
                        }
                        menuAudio.Play();
                        break;
                    case "ShowMesh":
                        if (!settingsOpened)
                        {
                            if (occlusionActive)
                            {
                                foreach (Transform child in meshHolder)
                                {
                                    var objectRender = child.GetComponent<MeshRenderer>();
                                    objectRender.material = meshMats[1];
                                }
                                mesh.material = meshMats[1];
                                occlusionActive = false;
                            }
                            else
                            {
                                foreach (Transform child in meshHolder)
                                {
                                    var objectRender = child.GetComponent<MeshRenderer>();
                                    objectRender.material = meshMats[0];
                                }
                                mesh.material = meshMats[0];
                                occlusionActive = true;
                            }
                            modifierMenu.SetActive(false);
                            menuOpened = false;
                        }
                        menuAudio.Play();
                        break;
                    default:
                        break;
                }
            }
            else if (controller.TriggerValue < 0.2f)
            {
                toggledMic = false;
            }

            string objHit = rayHit.transform.gameObject.name;
            switch (objHit)
            {
                case "SinglePinSelector":
                    if (singleSelector.transform.localScale.x < 4)
                    {
                        Vector3 localObjScale = singleSelector.transform.localScale;
                        localObjScale.x += Time.deltaTime * 5.0f;
                        localObjScale.y += Time.deltaTime * 5.0f;
                        localObjScale.z += Time.deltaTime * 5.0f;
                        singleSelector.transform.localScale = localObjScale;
                    }
                    if (controller.TriggerValue >= 0.9f)
                    {
                        objMenu.SetActive(false);
                        holding = holdState.single;
                        dontSpawn = true;
                    }
                    break;
                case "BowlingBallSelector":
                    if (bowlingBallSelector.transform.localScale.x < 4)
                    {
                        Vector3 localObjScale = bowlingBallSelector.transform.localScale;
                        localObjScale.x += Time.deltaTime * 5.0f;
                        localObjScale.y += Time.deltaTime * 5.0f;
                        localObjScale.z += Time.deltaTime * 5.0f;
                        bowlingBallSelector.transform.localScale = localObjScale;
                    }
                    if (controller.TriggerValue >= 0.9f)
                    {
                        objMenu.SetActive(false);
                        holding = holdState.ball;
                        dontSpawn = true;
                    }
                    break;
                case "TenPinSelector":
                    if (tenPinSelector.transform.localScale.x < 4)
                    {
                        Vector3 localObjScale = tenPinSelector.transform.localScale;
                        localObjScale.x += Time.deltaTime * 5.0f;
                        localObjScale.y += Time.deltaTime * 5.0f;
                        localObjScale.z += Time.deltaTime * 5.0f;
                        tenPinSelector.transform.localScale = localObjScale;
                    }
                    if (controller.TriggerValue >= 0.9f)
                    {
                        objMenu.SetActive(false);
                        holding = holdState.tenPin;
                        dontSpawn = true;
                    }
                    break;

            }

            if (singleSelector.transform.localScale.x > 3.33f && rayHit.transform.gameObject.name != "SinglePinSelector")
            {
                Vector3 localObjScale = singleSelector.transform.localScale;
                localObjScale.x -= Time.deltaTime * 5.0f;
                localObjScale.y -= Time.deltaTime * 5.0f;
                localObjScale.z -= Time.deltaTime * 5.0f;
                singleSelector.transform.localScale = localObjScale;
            }
            if (tenPinSelector.transform.localScale.x > 3.33f && rayHit.transform.gameObject.name != "TenPinSelector")
            {
                Vector3 localObjScale = tenPinSelector.transform.localScale;
                localObjScale.x -= Time.deltaTime * 5.0f;
                localObjScale.y -= Time.deltaTime * 5.0f;
                localObjScale.z -= Time.deltaTime * 5.0f;
                tenPinSelector.transform.localScale = localObjScale;
            }
            if (bowlingBallSelector.transform.localScale.x > 3.33f && rayHit.transform.gameObject.name != "BowlingBallSelector")
            {
                Vector3 localObjScale = bowlingBallSelector.transform.localScale;
                localObjScale.x -= Time.deltaTime * 5.0f;
                localObjScale.y -= Time.deltaTime * 5.0f;
                localObjScale.z -= Time.deltaTime * 5.0f;
                bowlingBallSelector.transform.localScale = localObjScale;
            }

            if (!holdingBallMenu)
            {
                BowlingColorLoader.GetBallColor(rayHit, controller, ballMenu, ballMenuOpened, holdingBallMenu, bowlingBall, ballMats);
            }
            else if (holdingBallMenu && controller.TriggerValue <= 0.2f)
            {
                holdingBallMenu = false;
            }
            if (multiplayerMenuOpen == true)
            {
                if (controller.TriggerValue >= 0.9f)
                {
                    string objGameHit = rayHit.transform.gameObject.name;
                    switch (objGameHit)
                    {
                        case "0":
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                        case "6":
                        case "7":
                        case "8":
                        case "9":
                            if (!pickedNumber && roomCode.Length < 18)
                            {
                                pickedNumber = true;
                                roomCode += objGameHit;
                                multiplayerCodeText.text = roomCode;
                                menuAudio.Play();
                            }
                            break;
                        case "Delete":
                            if (!deletedCharacter)
                            {
                                deletedCharacter = true;
                                if (roomCode.Length > 0)
                                {
                                    roomCode = roomCode.Substring(0, roomCode.Length - 1);
                                    multiplayerCodeText.text = roomCode;
                                }
                            }
                            break;
                        case "Join":
                            if (!joinedLobby)
                            {
                                if (roomCode.Length < 1)
                                {
                                    multiplayerCodeText.text = "Please enter a code";
                                }
                                else
                                {
                                    joinedLobby = true;
                                    _realtime = GameObject.Find("Realtime + VR Player");
                                    // Connect to Realtime room
                                    ClearAllObjects();
                                    _realtime.GetComponent<Realtime>().Connect(roomCode + "Bowling");
                                    multiplayerStatusText.text = ("Multiplayer Status:\n" + "<color='yellow'>Connecting</color>");
                                    multiplayerMenu.SetActive(false);
                                    multiplayerStatusMenu.SetActive(true);
                                    multiplayerMenuOpen = false;
                                    multiplayerMenuCodeText.text = ("<b>Room Code:</b>\n" + roomCode);
                                    menuAudio.Play();
                                }
                            }
                            break;
                        case "Cancel":
                            multiplayerMenu.SetActive(false);
                            multiplayerMenuOpen = false;
                            menu.SetActive(true);
                            menuOpened = true;
                            roomCode = "";
                            menuAudio.Play();
                            break;
                        default:
                            break;
                    }
                }
                else if (controller.TriggerValue <= 0.2f)
                {
                    pickedNumber = false;
                    deletedCharacter = false;
                }

            }

        }
        else
        {
            // If no object is hit, make the length of the line 7 meters out from the controller
            endPosition = controller.Position + (control.transform.forward * 7.0f);
            laserLineRenderer.SetPosition(1, endPosition);
        }
        if (holding == holdState.ball)
        {
            laserLineRenderer.SetPosition(0, mainCam.transform.position);
            laserLineRenderer.SetPosition(1, mainCam.transform.position);
        }
    }

    private void PlaceObject()
    {
        if (holding == holdState.track)
        {
            laserLineRenderer.material = activeMat;
            if (!trackObj.activeSelf)
            {
                trackObj.SetActive(true);
            }
            trackObj.transform.position = endPosition;
            placed = true;
        }
        else if (holding == holdState.ball)
        {
            laserLineRenderer.material = transparent;
            if (controller.TriggerValue >= 0.9f)
            {
                if (holdingBall)
                {
                    HoldingBall();
                }
                else
                {
                    holdingBall = true;
                    BowlingColorLoader.LoadBallColor(bowlingBall, ballMats);
                }
            }
        }
        else if (holding == holdState.single)
        {
            laserLineRenderer.material = activeMat;
        }
        else if (holding == holdState.tenPin)
        {
            laserLineRenderer.material = activeMat;
        }
        else if (holding == holdState.none && tutorialMenuOpened == false)
        {
            laserLineRenderer.material = activeMat;
        }
        if (controller.TriggerValue >= 0.9f)
        {
            if (!dontSpawn)
            {
                if (placed == false)
                {
                    placed = true;
                    SpawnObject();
                    GetCount();
                }
            }
        }
        else if (controller.TriggerValue <= 0.2f)
        {
            if (dontSpawn)
            {
                dontSpawn = false;
            }
            if (holdingBall == true)
            {
                Deltas.Clear();
                holdingBall = false;
                var rigidbody = bowlingBall.GetComponent<Rigidbody>();
                // Enable the rigidbody on the ball, then apply current forces to the ball
                rigidbody.useGravity = true;
                rigidbody.velocity = Vector3.zero;
                rigidbody.AddForce(forcePerSecond);
                forcePerSecond = Vector3.zero;
            }
            placed = false;
        }
    }
    private void HoldingBall()
    {
        var rigidbody = bowlingBall.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;

        bowlingBall.transform.rotation = Quaternion.identity;
        var oldPosition = bowlingBall.transform.position;
        var newPosition = controller.Position;

        var delta = newPosition - oldPosition;
        if (Deltas.Count == 10)
        {
            Deltas.RemoveAt(0);
        }
        Deltas.Add(delta);
        Vector3 toAverage = Vector3.zero;
        foreach (var toAdd in Deltas)
        {
            toAverage += toAdd;
        }
        toAverage /= Deltas.Count;
        var forcePerSecondAvg = toAverage * 550;
        forcePerSecond = forcePerSecondAvg;
        bowlingBall.transform.position = controller.Position;
    }

    public static void CloseMenu()
    {
        menuControl.SetActive(false);
    }

    private void GetCount()
    {
        totalObjs = 0;
        foreach (Transform bowlObj in pinHolder)
        {
            Transform objectstotal = bowlObj.GetComponentInChildren<Transform>();
            totalObjs += objectstotal.childCount;
        }
        pinLimitText.text = "Pin Limit:\n " + totalObjs + " of 50";
    }

    private void ClearAllObjects()
    {
        foreach (Transform child in pinHolder.transform)
        {
            GameObject.Destroy(child.gameObject);
            RealtimeView childComponent;
            childComponent = child.GetComponent<RealtimeView>();
            // If the pin has a RealtimeView component, then they are a Realtime object and must be removed remotely as well as locally
            if (childComponent != null)
            {
                Realtime.Destroy(child.gameObject);
            }
            else
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        totalObjs = 0;
        GetCount();
    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        if (!buttonLock)
        {
            buttonLock = true;

            if (button == MLInputControllerButton.Bumper)
            {
                multiplayerStatusMenu.SetActive(false);
                multiplayerConfirmMenu.SetActive(false);
                multiplayerMenu.SetActive(false);
                modifierMenu.SetActive(false);
                if (tutorialActive)
                {
                    tutorialBumperPressed = true;
                    tutorialMenu.SetActive(false);
                }
                if (menu.activeSelf)
                {
                    menu.SetActive(false);
                }
                if (objMenu.activeSelf)
                {
                    objMenu.SetActive(false);
                }
                else
                {
                    objMenu.transform.position = controlCube.transform.position + controlCube.transform.forward * 0.6f;
                    objMenu.transform.rotation = new Quaternion(controlCube.transform.rotation.x, controlCube.transform.rotation.y, 0, controlCube.transform.rotation.w);
                    objMenu.SetActive(true);
                }
            }
            else
            {
                print("gay");

                if (tutorialActive)
                {
                    tutorialHomePressed = true;
                    tutorialMenu.SetActive(false);
                }
                helpAppeared = true;

                if (menuOpened)
                {
                    menu.SetActive(false);
                    menuOpened = false;
                    modifierMenu.SetActive(false);
                    multiplayerConfirmMenu.SetActive(false);
                    multiplayerMenuOpen = false;
                    multiplayerStatusMenu.SetActive(false);
                    multiplayerMenu.SetActive(false);
                }
                else
                {
                    if (objMenu.activeSelf)
                    {
                        objMenu.SetActive(false);
                    }
                    laserLineRenderer.material = activeMat;
                    menu.SetActive(true);
                    modifierMenu.SetActive(false);
                    settingsOpened = false;
                    multiplayerMenu.SetActive(false);
                    multiplayerMenuOpen = false;
                    menuOpened = true;
                }
            }

            if (pinLimitAppeared)
            {
                reachedPinLimit.SetActive(false);
            }

            menuCanvas.transform.position = mainCam.transform.position + mainCam.transform.forward * 1.0f;
            menuCanvas.transform.LookAt(mainCam.transform.position);

            holding = holdState.none;
        }

    }
    private void OnButtonUp(byte controller_id, MLInputControllerButton button)
    {
        buttonLock = false;
    }
    private void SpawnObject()
    {
        if (holding == holdState.track)
        {
            holding = holdState.none;
        }
        if (holding == holdState.tenPin && totalObjs > 40)
        {
            if (!pinLimitAppeared)
            {
                pinLimitAppeared = true;
                helpMenu.transform.position = mainCam.transform.position + mainCam.transform.forward * 10.0f;
                helpMenu.transform.rotation = mainCam.transform.rotation;
                reachedPinLimit.SetActive(true);
            }
            // If you are trying to spawn 10 pins while the limit is less than 10 from being filled, don't spawn anything
        }
        else if (totalObjs < objLimit)
        {
            // Check to see if the user has enabled the noGravity modifier
            if (!noGravity)
            {
                if (holding == holdState.single)
                {
                    if (_realtimeObject.connected)
                    {
                        pin = Realtime.Instantiate(bowlingPinRealtimePrefab.name, endPosition, orientationCube.transform.rotation, true, false, true, null);
                        pin.transform.parent = pinHolder;
                        GetCount();
                    }
                    else
                    {
                        Instantiate(singlePrefab, endPosition, orientationCube.transform.rotation, pinHolder);
                    }
                }
                else if (holding == holdState.tenPin)
                {
                    if (_realtimeObject.connected)
                    {
                        pin = Realtime.Instantiate(tenPinRealtimePrefab.name, endPosition, tenPinOrientation.transform.rotation, true, false, true, null);
                        pin.transform.parent = pinHolder;
                        GetCount();
                    }
                    else
                    {
                        Instantiate(tenPinPrefab, endPosition, Quaternion.Euler(new Vector3(0, 0, 0)), pinHolder);
                    }
                }
                else if (holding == holdState.ball)
                {
                    if (_realtimeObject.connected && realtimeBowlingBall == false)
                    {
                        realtimeBowlingBall = true;
                        bowlingBall = Realtime.Instantiate(bowlingBallRealtimePrefab.name, true, false, true, null);
                        GetCount();
                    }
                    bowlingBall.GetComponent<RealtimeView>().RequestOwnership();
                    bowlingBall.GetComponent<RealtimeTransform>().RequestOwnership();
                    Rigidbody ballRB = bowlingBall.GetComponent<Rigidbody>();
                    ballRB.useGravity = false;
                }
            }
            else if (noGravity)
            {
                if (holding == holdState.single)
                {
                    if (_realtimeObject.connected)
                    {
                        pin = Realtime.Instantiate(singleNoGravityPrefab.name, endPosition, orientationCube.transform.rotation, true, false, true, null);
                        pin.transform.parent = pinHolder;
                        GetCount();
                    }
                    else
                    {
                        Instantiate(singleNoGravityPrefab, endPosition, orientationCube.transform.rotation, pinHolder);
                    }
                }
                else if (holding == holdState.tenPin)
                {
                    if (_realtimeObject.connected)
                    {
                        pin = Realtime.Instantiate(tenPinNoGravityPrefab.name, endPosition, tenPinOrientation.transform.rotation, true, false, true, null);
                        pin.transform.parent = pinHolder;
                        GetCount();
                    }
                    else
                    {
                        Instantiate(tenPinNoGravityPrefab, endPosition, tenPinOrientation.transform.rotation, pinHolder);
                    }
                }
                else if (holding == holdState.ball)
                {
                    Rigidbody ballRB = bowlingBall.GetComponent<Rigidbody>();
                    ballRB.useGravity = false;
                }
            }
        }
        else if (totalObjs == objLimit || totalObjs > objLimit)
        {
            if (pinLimitHelp == false)
            {
                pinLimitHelp = true;
                pinLimitMenu.SetActive(false);

                helpMenu.transform.position = mainCam.transform.position + mainCam.transform.forward * 10f;
                helpMenu.transform.rotation = mainCam.transform.rotation;
            }
        }
        // Get a count of how many objects there are to ensure that there are not too many objects at once
        GetCount();
    }
    private void CheckNewUser()
    {
        // TODO: CHANGE INT BACK TO 1, CURRENT IMPLEMENTATION WILL ALWAYS SHOW TUTORIAL
        if (PlayerPrefs.GetInt("hasPlayedBowling") == 1)
        {
            holding = holdState.none;
            tutorialActive = false;
            laserLineRenderer.material = activeMat;
            tutorialMenu.SetActive(false);
        }
        else
        {
            menuCanvas.transform.position = mainCam.transform.position + mainCam.transform.forward * 1.0f;
            menuCanvas.transform.LookAt(mainCam.transform.position);
            holding = holdState.none;
            print("Not Played");
            tutorialMenu.SetActive(true);
            PlayerPrefs.SetInt("hasPlayedBowling", 1);
        }
    }
}