#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using Normal.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using UnityEngine.XR;
using MagicLeapTools;

public class BowlingManager : MonoBehaviour
{

    private enum holdState
    {
        none,
        single,
        tenPin,
        ball,
        track,
        locationPoint
    }
    private enum menuState
    {
        none,
        home,
        modifiers,
        changeBall
    }

    // Input
    private MLInputController controller;
    public LineRenderer laserLineRenderer;
    RaycastHit rayHit;

    private enum HandPoses { OpenHand, Fist, NoPose };
    private HandPoses pose = HandPoses.NoPose;
    private Vector3[] pos;
    private MLHandKeyPose[] _gestures;

    private holdState holding = holdState.single;

    // Declare GameObjects.  Public GameObjects are set in Unity Editor.  
    [SerializeField] private GameObject mainCam, control, ballPrefab, controlCube, deleteLoader, menuCanvas, handCenter, toggleMicButton, reachedPinLimit, singleSelector, bowlingBallSelector, tenPinSelector, swapHandButton, tutorialLeft, tutorialRight, tutorialLeftText, tutorialRightText, track, pinPlacement, startPoint, endPoint, transmissionObj, spatialAlignmentObj;

    [SerializeField] private GameObject menu, ballMenu, modifierMenu, tutorialMenu, multiplayerMenu, multiplayerConfirmMenu, helpMenu, tutorialHelpMenu, deleteMenu, pinLimitMenu, multiplayerStatusMenu, handMenu, objMenu;
    [SerializeField] private GameObject[] tutorialPage;

    public Text pinLimitText, multiplayerCodeText, multiplayerStatusText, multiplayerMenuCodeText, connectedPlayersText, pinsFallenText, noGravityText, gestureHandText;
    private GameObject bowlingBall, _realtime, pinObj, pin, currentTutorialPage;
    public Material[] ballMats, meshMats;

    public Transform singlePrefab, tenPinPrefab, pinHolder, singleNoGravityPrefab, tenPinNoGravityPrefab, meshHolder;

    public MeshRenderer mesh;

    private Vector3 endPosition, forcePerSecond, trackStartPosition, trackEndPosition;

    List<Vector3> Deltas = new List<Vector3>();
    private int currentPage = 0, totalObjs = 0, objLimit = 100;
    private float timer = 0.0f, waitTime = 30.0f, menuMoveSpeed, connectedPlayers, deleteTimer = 0.0f;

    public int pinsFallen = 0;

    //public static string ballColor;

    private string roomCode = "";

    public Image loadingImage;

    public Texture2D emptyCircle, check, handLeft, handRight;

    private bool holdingBall = false, ballMenuOpened = false, holdingBallMenu = true, noGravity = false, tutorialActive = true, tutorialBumperPressed, tutorialHomePressed, occlusionActive = true, joinedLobby = false, realtimeBowlingBall = false, pickedNumber = true, deletedCharacter = false, helpAppeared = false, micActive = true, getLocalPlayer = false, networkConnected, pinLimitAppeared = false, dontSpawn, leftHand = true, setLocationPos = false;

    public Realtime _realtimeObject;

    private Vector3 pinOrientation = new Vector3(-90,0,90), tenPinOrientation = new Vector3(0,0,-90);
    // AUDIO VARIABLES

    public AudioSource menuAudio;

    // Use this for initialization
    void Start()
    {

        MLInput.Start();
        // If the user is new, open the tutorial menu
        CheckNewUser();

        // Get input from the Control, accessible via controller
        controller = MLInput.GetController(0);
        // When the Control's button(s) are pressed, run OnButtonDown
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnTriggerDown += OnTriggerDown;
        MLInput.OnTriggerUp += OnTriggerUp;
        MLInput.TriggerDownThreshold = 0.75f;
        MLInput.TriggerUpThreshold = 0.2f;

        // Initialize both line points at Vector3.Zero
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);

        MLHands.Start();
        _gestures = new MLHandKeyPose[2];
        _gestures[0] = MLHandKeyPose.OpenHand;
        _gestures[1] = MLHandKeyPose.Fist;
        MLHands.KeyPoseManager.EnableKeyPoses(_gestures, true, false);
        pos = new Vector3[1];

        menuMoveSpeed = Time.deltaTime * 2f;
        // tenPinOrientation.transform.rotation = new Quaternion(0, mainCam.transform.rotation.y, 0, 0);

        MLNetworking.IsInternetConnected(ref networkConnected);
        if (networkConnected == false)
        {
            multiplayerStatusText.text = ("<b>Multiplayer Status:</b>\n" + "<color='red'>No Internet</color>");
        }
        if (PlayerPrefs.GetString("gestureHand") == null)
        {
            PlayerPrefs.SetString("gestureHand", "left");
        }
        else if (PlayerPrefs.GetString("gestureHand") == "right")
        {
            gestureHandText.text = ("Gestures:\n Right Hand");
            swapHandButton.GetComponent<MeshRenderer>().material.mainTexture = handRight;
            leftHand = false;
        }

        currentTutorialPage = GameObject.Find("/[CONTENT]/Menu/Canvas/Tutorial/0");

        // holding = holdState.track;

    }
    private void OnDisable()
    {
        MLInput.Stop();
        MLHands.Stop();
        MLInput.OnControllerButtonDown -= OnButtonDown;
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
            multiplayerStatusText.text = ("<b>Multiplayer Status:</b>\n" + "<color='red'>No Internet</color>");
        }
        else
        {
            multiplayerStatusText.text = ("<b>Multiplayer Status:</b>\n" + "<color='red'>Not Connected</color>");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckGestures();

        if (holding == holdState.track && trackStartPosition != Vector3.zero)
        {
            PlaceTrack();
        }

        if (timer < waitTime)
        {
            PlayTimer();
        }
        SetLine();

        if (holdingBall)
        {
            HoldingBall();
        }

        // Always keep the control GameObject at the Control's position
        control.transform.position = controller.Position;
        control.transform.rotation = controller.Orientation;

        // If the user is not reading the tutorial menu, activate the line from the Control and prepare for the user to place objects
        if (tutorialActive)
        {
            // If the user presses anything while the tutorial is active, hide the tutorial and active the pointer
            if ((controller.Touch1Active || controller.TriggerValue >= 0.2f || tutorialBumperPressed == true || tutorialHomePressed == true) && !tutorialMenu.activeSelf)
            {
                tutorialMenu.SetActive(false);
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
                            // localPlayer = obj;
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
            multiplayerStatusText.text = ("<b>Multiplayer Status:</b>\n" + "<color='green'>Connected</color>");
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
            if (holding == holdState.none && tutorialMenu.activeSelf == false && menu.activeSelf == false && menu.activeSelf == false && totalObjs == 0)
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
        if (leftHand)
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
        else
        {
            if (GetUserGesture.GetGesture(MLHands.Right, MLHandKeyPose.OpenHand))
            {
                pose = HandPoses.OpenHand;
                helpAppeared = true;
            }
            else if (GetUserGesture.GetGesture(MLHands.Right, MLHandKeyPose.Fist))
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

    }

    private void ShowPoints()
    {
        if (leftHand)
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

                deleteLoader.SetActive(true);

                // Calculate the amount of time that you need to hold your fist to delete all objects
                float percentComplete = deleteTimer / 3.0f;
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
        else
        {

            if (pose == HandPoses.Fist)
            {
                if (!deleteLoader.activeSelf)
                {
                    pos[0] = MLHands.Right.Middle.KeyPoints[0].Position;
                    handCenter.transform.position = pos[0];
                    handCenter.transform.LookAt(mainCam.transform.position);
                }
                if (!handCenter.activeSelf)
                {
                    handCenter.SetActive(true);
                }
                handMenu.SetActive(false);
                deleteTimer += Time.deltaTime;

                deleteLoader.SetActive(true);

                // Calculate the amount of time that you need to hold your fist to delete all objects
                float percentComplete = deleteTimer / 3.0f;
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
                pos[0] = MLHands.Right.Middle.KeyPoints[0].Position;
                handCenter.transform.position = pos[0];
                handCenter.transform.LookAt(mainCam.transform.position);
            }
        }

    }
    private void SetLine()
    {
        Vector3 heading = control.transform.forward;

        // Set the origin of the line to the controller's position.  Occurs every frame
        laserLineRenderer.SetPosition(0, controller.Position);

        if (Physics.Raycast(controller.Position, heading, out rayHit, 10.0f))
        {
            // If the ray hits an object, set the line's end position to the distance between the controller and that point
            endPosition = controller.Position + (control.transform.forward * rayHit.distance);
            laserLineRenderer.SetPosition(1, endPosition);

            if (holding == holdState.locationPoint)
            {
                if (setLocationPos)
                {
                    //locationPointObj.transform.LookAt(endPosition);
                }
                else
                {
                    //locationPointObj.transform.position = endPosition;
                }
            }
            string objHit = rayHit.transform.gameObject.name;
            switch (objHit)
            {
                case "SinglePinSelector":
                    if (singleSelector.transform.localScale.x < 4)
                    {
                        Vector3 localObjScale = singleSelector.transform.localScale;
                        localObjScale += new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
                        singleSelector.transform.localScale = localObjScale;
                    }
                    break;
                case "BowlingBallSelector":
                    if (bowlingBallSelector.transform.localScale.x < 4)
                    {
                        Vector3 localObjScale = bowlingBallSelector.transform.localScale;
                        localObjScale += new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
                        bowlingBallSelector.transform.localScale = localObjScale;
                    }
                    break;
                case "TenPinSelector":
                    if (tenPinSelector.transform.localScale.x < 4)
                    {
                        Vector3 localObjScale = tenPinSelector.transform.localScale;
                        localObjScale += new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
                        tenPinSelector.transform.localScale = localObjScale;
                    }
                    break;

            }

            if (singleSelector.transform.localScale.x > 3.33f && rayHit.transform.gameObject.name != "SinglePinSelector")
            {
                Vector3 localObjScale = singleSelector.transform.localScale;
                localObjScale -= new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
                singleSelector.transform.localScale = localObjScale;
            }
            if (tenPinSelector.transform.localScale.x > 3.33f && rayHit.transform.gameObject.name != "TenPinSelector")
            {
                Vector3 localObjScale = tenPinSelector.transform.localScale;
                localObjScale -= new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
                tenPinSelector.transform.localScale = localObjScale;
            }
            if (bowlingBallSelector.transform.localScale.x > 3.33f && rayHit.transform.gameObject.name != "BowlingBallSelector")
            {
                Vector3 localObjScale = bowlingBallSelector.transform.localScale;
                localObjScale -= new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
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
            if (multiplayerMenu.activeSelf)
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
                            MLNetworking.IsInternetConnected(ref networkConnected);
                            // if (networkConnected == false)
                            // {
                            //     multiplayerCodeText.text = ("<color='red'>No Internet</color>");
                            // }
                            // else
                            // {
                                multiplayerCodeText.color = Color.white;
                                if (!pickedNumber && roomCode.Length < 18)
                                {
                                    pickedNumber = true;
                                    roomCode += objGameHit;
                                    multiplayerCodeText.text = roomCode;
                                    menuAudio.Play();
                                }
                          // }

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
                                MLNetworking.IsInternetConnected(ref networkConnected);
                                // if (networkConnected == false)
                                // {
                                //     multiplayerCodeText.text = ("<color='red'>No Internet Connection</color>");
                                // }
                                // else
                                // {
                                    multiplayerCodeText.color = Color.white;
                                    if (roomCode.Length < 1)
                                    {
                                        multiplayerCodeText.text = "Please enter a code";
                                    }
                                    else
                                    {
                                        joinedLobby = true;
                                        // _realtime = GameObject.Find("Realtime + VR Player");
                                        // Connect to Realtime room
                                        ClearAllObjects();
                                        // _realtime.GetComponent<Realtime>().Connect(roomCode + "Bowling");

                                        transmissionObj.SetActive(true);
                                        transmissionObj.GetComponent<Transmission>().privateKey = roomCode;
                                        
                                        spatialAlignmentObj.SetActive(true);

                                        multiplayerStatusText.text = ("<b>Multiplayer Status:</b>\n" + "<color='yellow'>Connecting</color>");
                                        multiplayerMenu.SetActive(false);
                                        multiplayerStatusMenu.SetActive(true);
                                        multiplayerMenuCodeText.text = ("<b>Room Code:</b>\n" + roomCode);
                                        menuAudio.Play();
                                    }
                              //  }
                            }
                            break;
                        case "Cancel":
                            multiplayerMenu.SetActive(false);
                            menu.SetActive(true);
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
    private void SpawnObject()
    {

        if (totalObjs < objLimit)
        {
            // Check to see if the user has enabled the noGravity modifier
            if (!noGravity)
            {
                if (holding == holdState.single)
                {
                    if (joinedLobby)
                    {
                        Transmission.Spawn("SingleMultiplayer", endPosition, Quaternion.Euler(pinOrientation), Vector3.one);
                        GetCount();
                    }
                    else
                    {
                        Instantiate(singlePrefab, endPosition, Quaternion.Euler(pinOrientation), pinHolder);
                    }
                }
                else if (holding == holdState.tenPin)
                {
                    if (totalObjs <= objLimit - 10)
                    {
                        if (joinedLobby)
                        {
                            Transmission.Spawn("TenPinMultiplayer", endPosition, Quaternion.Euler(tenPinOrientation), Vector3.one);

                            GetCount();
                        }
                        else
                        {
                            Instantiate(tenPinPrefab, endPosition, Quaternion.Euler(new Vector3(0, 0, 0)), pinHolder);
                        }
                    }

                }
                else if (holding == holdState.ball)
                {
                    if (_realtimeObject.connected && realtimeBowlingBall == false)
                    {
                        realtimeBowlingBall = true;
                        bowlingBall.GetComponent<RealtimeView>().RequestOwnership();
                        bowlingBall.GetComponent<RealtimeTransform>().RequestOwnership();
                    }

                    Rigidbody ballRB = bowlingBall.GetComponent<Rigidbody>();
                    ballRB.useGravity = false;
                }
            }
            else if (noGravity)
            {
                if (holding == holdState.single)
                {
                    if (joinedLobby)
                    {
                        Transmission.Spawn("SingleNoGravity", endPosition, Quaternion.Euler(pinOrientation), Vector3.one);
                        GetCount();
                    }
                    else
                    {
                        Instantiate(singleNoGravityPrefab, endPosition, Quaternion.Euler(pinOrientation), pinHolder);
                    }
                }
                else if (holding == holdState.tenPin)
                {
                    if (joinedLobby)
                    {
                        Transmission.Spawn("TenPinMultiplayerNoGravity", endPosition, Quaternion.Euler(tenPinOrientation), Vector3.one);
                        GetCount();
                    }
                    else
                    {
                        Instantiate(tenPinNoGravityPrefab, endPosition, Quaternion.Euler(tenPinOrientation), pinHolder);
                    }
                }
                else if (holding == holdState.ball)
                {
                    Rigidbody ballRB = bowlingBall.GetComponent<Rigidbody>();
                    ballRB.useGravity = false;
                }
            }
        }
        else if (!pinLimitAppeared)
        {
            pinLimitAppeared = true;
            helpMenu.transform.position = mainCam.transform.position + mainCam.transform.forward * 8.0f;
            helpMenu.transform.rotation = mainCam.transform.rotation;
            reachedPinLimit.SetActive(true);
        }
        GetCount();
    }
    private void CheckNewUser()
    {
        // Check this value to determine whether or not the player has opened the bowling game before
        if (PlayerPrefs.GetInt("hasPlayedBowling") == 1)
        {
            holding = holdState.none;
            tutorialActive = false;
            tutorialMenu.SetActive(false);
        }
        else
        {
            menuCanvas.transform.position = mainCam.transform.position + mainCam.transform.forward * 1.5f;
            menuCanvas.transform.LookAt(mainCam.transform.position);
            holding = holdState.none;
            tutorialMenu.SetActive(true);
            // Set the int to 1 to tell the game that the user has opened the bowling game
            PlayerPrefs.SetInt("hasPlayedBowling", 1);
        }
    }

    private void HoldingBall()
    {
        // Run on LateUpdate if the holdState is ball and the Trigger is held down
        if (bowlingBall == null)
        {
            // Spawn the ball away from the player and set the correct color
            bowlingBall = Instantiate(ballPrefab, new Vector3(15, 15, 15), Quaternion.Euler(tenPinOrientation));
            BowlingColorLoader.LoadBallColor(bowlingBall, ballMats);
        }
        if (_realtimeObject.connected)
        {
            bowlingBall.GetComponent<RealtimeView>().RequestOwnership();
            bowlingBall.GetComponent<RealtimeTransform>().RequestOwnership();
        }
        // Stop the ball moving on its own while holding
        var rigidbody = bowlingBall.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;

        // Reset the bowling ball and then get the bowling ball's previous and current position
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

    public void GetCount()
    {
        totalObjs = 0;
        foreach (Transform bowlObj in pinHolder)
        {
            Transform objectstotal = bowlObj.GetComponentInChildren<Transform>();
            totalObjs += objectstotal.childCount;
        }
        pinLimitText.text = "<b>Pin Limit:</b>\n " + totalObjs + " of 100";
        pinsFallenText.text = ("<b>Pins Fallen:</b>\n" + pinsFallen + " of " + totalObjs);
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
        pinsFallen = 0;
        UpdateFallen();

        totalObjs = 0;
        GetCount();
    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        currentPage = 1;
        SetTutorialPage(false);

        if (button == MLInputControllerButton.Bumper)
        {
            tutorialMenu.SetActive(false);
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
            ballMenu.SetActive(false);
            if (tutorialMenu.activeSelf)
            {
                tutorialMenu.SetActive(false);
            }
            helpAppeared = true;

            if (menu.activeSelf)
            {
                menu.SetActive(false);
                tutorialMenu.SetActive(false);
                modifierMenu.SetActive(false);
                multiplayerConfirmMenu.SetActive(false);
                multiplayerStatusMenu.SetActive(false);
                multiplayerMenu.SetActive(false);
            }
            else
            {
                objMenu.SetActive(false);
                menu.SetActive(true);
                modifierMenu.SetActive(false);
                multiplayerMenu.SetActive(false);
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
    private void PlaceTrack()
    {
        if (trackStartPosition == Vector3.zero)
        {
            trackStartPosition = endPosition;
            startPoint.transform.position = trackStartPosition;
        }
        else
        {
            trackEndPosition = endPosition;
            endPoint.transform.position = trackEndPosition;
            startPoint.transform.LookAt(endPoint.transform.position);
            track.transform.rotation = startPoint.transform.rotation;
            float scaleZ = Vector3.Distance(trackStartPosition, trackEndPosition);
            Vector3 centerPos = new Vector3(trackStartPosition.x + trackEndPosition.x, (trackStartPosition.y + 0.02f) + trackEndPosition.y, trackStartPosition.z + trackEndPosition.z) / 2f;
            track.transform.position = centerPos;
            track.transform.localScale = new Vector3(.10668f, 1, (scaleZ / 10));
        }
    }
    private void OnTriggerDown(byte controller_Id, float triggerValue)
    {
        if (holding == holdState.ball)
        {
            holdingBall = true;
        }
        else if (holding == holdState.track)
        {
            if (trackEndPosition == Vector3.zero)
            {
                PlaceTrack();
            } else {

                Transmission.Spawn("10PinLowPoly", pinPlacement.transform.position, pinPlacement.transform.rotation, Vector3.one);

                holding = holdState.none;
            }
        }
        else if (holding == holdState.locationPoint)
        {
            if (setLocationPos)
            {
                holding = holdState.none;
                //pinHolder.transform.rotation = locationPointObj.transform.rotation;
                //locationPointObj.SetActive(false);
            }
            else
            {
                InputTracking.Recenter();
                setLocationPos = true;
                //pinHolder.transform.position = locationPointObj.transform.position;
            }
            //holding = holdState.none;
        }

        SpawnObject();

        string objGameHit = rayHit.transform.gameObject.name;
        switch (objGameHit)
        {
            case "Home":
                MLInput.Stop();
                MLHands.Stop();
                menu.SetActive(false);
                Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
                laserLineRenderer.SetPositions(initLaserPositions);
                MLInput.OnControllerButtonDown -= OnButtonDown;
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
                menu.SetActive(false);
                menuAudio.Play();
                break;
            case "AcceptTerms":
                multiplayerMenu.SetActive(true);
                multiplayerConfirmMenu.SetActive(false);
                menuAudio.Play();
                break;
            case "CancelTerms":
                multiplayerConfirmMenu.SetActive(false);
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
                menuAudio.Play();
                break;
            case "Tutorial":
                menu.SetActive(false);
                tutorialMenu.SetActive(true);
                PlayerPrefs.SetInt("hasPlayedBowling", 0);
                CheckNewUser();
                menuAudio.Play();
                break;
            case "TutorialLeft":
                SetTutorialPage(false);
                break;
            case "TutorialRight":
                SetTutorialPage(true);
                break;
            case "YesPlease":
                PlayerPrefs.SetInt("hasPlayedBowling", 0);
                CheckNewUser();
                tutorialActive = true;
                tutorialHelpMenu.SetActive(false);
                menuAudio.Play();
                break;
            case "NoThanks":
                tutorialHelpMenu.SetActive(false);
                menuAudio.Play();
                break;
            case "NewGame":
                holding = holdState.track;
                menuAudio.Play();
                break;
            case "ToggleMic":
                menuAudio.Play();
                if (micActive == true)
                {
                    micActive = false;
                    // localPlayer.GetComponentInChildren<RealtimeAvatarVoice>().mute = true;
                    toggleMicButton.GetComponent<MeshRenderer>().material.mainTexture = emptyCircle;
                }
                else
                {
                    micActive = true;
                    // localPlayer.GetComponentInChildren<RealtimeAvatarVoice>().mute = false;
                    toggleMicButton.GetComponent<MeshRenderer>().material.mainTexture = check;
                }
                break;
            case "LeaveRoom":
                joinedLobby = false;
                _realtime.GetComponent<Realtime>().Disconnect();
                multiplayerStatusText.text = ("<b>Multiplayer Status:</b>\n" + "<color='red'>Not Connected</color>");
                multiplayerStatusMenu.SetActive(false);
                menuAudio.Play();
                break;
            case "NoGravity":
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
                menuAudio.Play();
                break;
            case "ShowMesh":
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
                menuAudio.Play();
                break;
            case "SwapHand":
                if (PlayerPrefs.GetString("gestureHand") == "left")
                {
                    PlayerPrefs.SetString("gestureHand", "right");
                    swapHandButton.GetComponent<MeshRenderer>().material.mainTexture = handRight;
                    gestureHandText.text = ("Gestures:\n Right Hand");
                    leftHand = false;

                }
                else
                {
                    PlayerPrefs.SetString("gestureHand", "left");
                    swapHandButton.GetComponent<MeshRenderer>().material.mainTexture = handLeft;
                    gestureHandText.text = ("Gestures:\n Left Hand");
                    leftHand = true;
                }
                break;
            case "SinglePinSelector":
                objMenu.SetActive(false);
                holding = holdState.single;
                break;
            case "BowlingBallSelector":
                objMenu.SetActive(false);
                holding = holdState.ball;
                break;
            case "TenPinSelector":
                objMenu.SetActive(false);
                holding = holdState.tenPin;
                break;
            default:
                break;
        }

    }
    private void OnTriggerUp(byte controller_Id, float triggerValue)
    {
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
    }
    public void UpdateFallen()
    {
        pinsFallenText.text = ("<b>Pins Fallen:</b> \n" + pinsFallen + " of " + totalObjs);
    }
    private void SetTutorialPage(bool forward)
    {
        currentTutorialPage.SetActive(false);
        if (forward)
        {
            if (currentPage < tutorialPage.Length - 1)
            {
                currentPage = currentPage + 1;
            }
        }
        else
        {
            if (currentPage > 0)
            {
                currentPage = currentPage - 1;
            }
        }
        currentTutorialPage = GameObject.Find("/[CONTENT]/Menu/Canvas/Tutorial/" + currentPage);
        print(currentTutorialPage);
        currentTutorialPage.SetActive(true);

        if (currentPage == 0)
        {
            tutorialLeft.SetActive(false);
            tutorialLeftText.SetActive(false);
        }
        else if (currentPage == tutorialPage.Length - 1)
        {
            tutorialRight.SetActive(false);
            tutorialRightText.SetActive(false);
        }
        else
        {
            tutorialLeft.SetActive(true);
            tutorialLeftText.SetActive(true);
            tutorialRight.SetActive(true);
            tutorialRightText.SetActive(true);
        }
    }
}