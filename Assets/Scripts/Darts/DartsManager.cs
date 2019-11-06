using System.Collections;
using System.Collections.Generic;
using Normal.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using MagicLeapTools;

public class DartsManager : MonoBehaviour
{
    public enum holdState
    {
        none,
        dart,
        dartboard
    }

    public enum HandPoses { OpenHand, Fist, NoPose };
    public HandPoses pose = HandPoses.NoPose;
    public Vector3[] pos;
    private MLHandKeyPose[] _gestures;
    public static holdState holding = holdState.none;
    private MLInputController controller;
    public GameObject mainCam, control, dartPrefab, dartboardHolder, dartboardOutline, menu, modifierMenu, tutorialMenu, dartMenu, multiplayerMenu, dartboard, deleteLoader, menuCanvas, handCenter, multiplayerConfirmMenu, helpMenu, tutorialHelpMenu, deleteMenu, multiplayerStatusMenu, localPlayer, toggleMicButton, objMenu, dartSelector, dartboardSelector, handMenu, dartLimitMenu, swapHandButton, tutorialLeft, tutorialRight, tutorialLeftText, tutorialRightText, controlOrientationObj;
    public Text dartLimitText, multiplayerCodeText, multiplayerStatusText, multiplayerMenuCodeText, connectedPlayersText, noGravityText, gestureHandText;
    [SerializeField]
    private GameObject[] tutorialPage;
    public Transform dartHolder, meshHolder;
    public static GameObject menuControl;
    private GameObject  _realtime, currentTutorialPage;
    private TransmissionObject dart;
    public Material transparent, activeMat;
    public Material[] dartMats, meshMats;
    public LineRenderer laserLineRenderer;
    public MeshRenderer mesh;
    private string roomCode = "";
    private Vector3 endPosition, forcePerSecond;
    private float timeHold = 3.0f, totalObjs = 0, objLimit = 40, timeHomePress = 0.01f, timeOfFirstHomePress, timer = 0.0f, waitTime = 30.0f, menuMoveSpeed, connectedPlayers, deleteTimer = 0.0f, bumperTest, colorObjSelected = 0;
    private Controller checkController;
    [SerializeField] private GameObject dartRealtime = null, dartboardRealtime = null;
    public Image loadingImage;
    public Texture2D emptyCircle, check, handLeft, handRight;

    private int currentPage = 0;
    public Realtime _realtimeObject;
    private PlayerManagerModel _playerManager;

    private bool setHand = false, holdingDart = false, tutorialActive = true, noGravity = false, holdingDartMenu = true, tutorialBumperPressed, tutorialHomePressed, movingDartboard = true, occlusionActive = true, firstHomePressed = false, pickedNumber = true, deletedCharacter = false, realtimeDartboard = false, helpAppeared = false, initializedRealtimePlayer = false, micActive = true, getLocalPlayer = false, toggledMic = false, networkConnected, objSelected = false, dartLimitAppeared, leftHand = true;
    public static bool lockedDartboard = false;
    List<Vector3> Deltas = new List<Vector3>();

    public AudioSource menuAudio;

    RaycastHit rayHit;

    // Use this for initialization
    void Start()
    {
        print("Buttonz");
        CheckNewUser();

        MLInput.Start();

        print("Getting controller..");
        controller = MLInput.GetController(0);
        MLInput.OnControllerButtonDown += OnButtonDown;

        MLInput.OnTriggerDown += OnTriggerDown;
        MLInput.TriggerDownThreshold = 0.75f;

        MLInput.OnTriggerUp += OnTriggerUp;
        MLInput.TriggerUpThreshold = 0.2f;

        // Initialize both line points at Vector3.zero
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);

        menuControl = GameObject.Find("ObjectMenu");
        checkController = control.GetComponentInChildren<Controller>();

        MLHands.Start();
        _gestures = new MLHandKeyPose[2];
        _gestures[0] = MLHandKeyPose.OpenHand;
        _gestures[1] = MLHandKeyPose.Fist;
        MLHands.KeyPoseManager.EnableKeyPoses(_gestures, true, false);
        pos = new Vector3[1];

        _realtime = GameObject.Find("Realtime + VR Player");

        MLNetworking.IsInternetConnected(ref networkConnected);
        if (networkConnected == false)
        {
            multiplayerStatusText.text = ("Multiplayer Status:\n" + "<color='red'>No Internet</color>");
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

        currentTutorialPage = GameObject.Find("/Menu/Canvas/Tutorial/0");
    }
    private void OnDisable()
    {
        MLInput.Stop();
        MLHands.Stop();
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
    void LateUpdate()
    {

        if (holdingDart)
        {
            HoldingDart();
        }

        CheckGestures();
        if (timer < waitTime)
        {
            PlayTimer();
        }
        SetLine();

        control.transform.position = controller.Position;
        control.transform.rotation = controller.Orientation;

        if (objSelected && controller.TriggerValue <= 0.2f)
        {
            objSelected = false;
        }
        menuMoveSpeed = Time.deltaTime * 2f;
        if (tutorialActive == false)
        {
            PlaceObject();
        }
        else
        {
            if ((controller.Touch1Active || controller.TriggerValue >= 0.2f || tutorialBumperPressed || tutorialHomePressed) && !tutorialMenu.activeSelf)
            {
                laserLineRenderer.material = activeMat;
                CheckNewUser();
            }
        }
        if (controller.Touch1Active)
        {
            if (menu.activeSelf)
            {
                // menuControl.SetActive(true);
            }
            if (setHand == false)
            {
                setHand = true;

            }
        }
        if (dartLimitMenu.activeSelf)
        {
            if (GetUserGesture.GetGesture(MLHands.Left, MLHandKeyPose.OpenHand))
            {
                dartLimitMenu.SetActive(false);
            }
            if (controller.IsBumperDown)
            {
                dartLimitMenu.SetActive(false);
            }
        }

        if (controller.Touch1Active == false)
        {
            setHand = false;
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
        Vector3 camPos = mainCam.transform.position + mainCam.transform.forward * 1.0f;
        helpMenu.transform.position = Vector3.SlerpUnclamped(helpMenu.transform.position, camPos, menuMoveSpeed);

        Quaternion rot = Quaternion.LookRotation(helpMenu.transform.position - mainCam.transform.position);
        helpMenu.transform.rotation = Quaternion.Slerp(helpMenu.transform.rotation, rot, menuMoveSpeed);
    }
    private void PlayTimer()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            if (holding == holdState.none && tutorialMenu.activeSelf != true && menu.activeSelf != true)
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
        // if (holdingDart)
        // {
        //     HoldingDart();
        // }
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

        // Set the origin of the line to the controller's position, because the first position does not dynamically change
        laserLineRenderer.SetPosition(0, controller.Position);
        if (Physics.Raycast(controller.Position, heading, out rayHit, 10.0f))
        {
            endPosition = controller.Position + (control.transform.forward * rayHit.distance);
            laserLineRenderer.SetPosition(1, endPosition);

            if (rayHit.transform.gameObject.name == "DartSelector")
            {
                GameObject selector = GameObject.Find("DartSelector");
                if (selector.transform.localScale.x < 4)
                {
                    Vector3 localObjScale = selector.transform.localScale;
                    localObjScale += new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
                    selector.transform.localScale = localObjScale;
                }
            }
            else if (rayHit.transform.gameObject.name == "DartboardSelector")
            {
                GameObject selector = GameObject.Find("DartboardSelector");
                if (selector.transform.localScale.x < 4)
                {
                    Vector3 localObjScale = selector.transform.localScale;
                    localObjScale += new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
                    selector.transform.localScale = localObjScale;
                }
            }

            if (!holdingDartMenu)
            {
                // DartColorLoader.GetDartColor(rayHit.transform.gameObject.name, controller, dartMenu, holdingDartMenu, dart, dartMats);
            }
            else if (holdingDartMenu && controller.TriggerValue <= 0.2f)
            {
                holdingDartMenu = false;
            }
            if (dartSelector.transform.localScale.x > 3.33f && rayHit.transform.gameObject.name != "DartSelector")
            {
                Vector3 localObjScale = dartSelector.transform.localScale;
                localObjScale -= new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
                dartSelector.transform.localScale = localObjScale;
            }
            if (dartboardSelector.transform.localScale.x > 3.33f && rayHit.transform.gameObject.name != "DartboardSelector")
            {
                Vector3 localObjScale = dartboardSelector.transform.localScale;
                localObjScale -= new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
                dartboardSelector.transform.localScale = localObjScale;
            }
        }
        else
        {
            if (holding == holdState.dartboard)
            {
                dartboardOutline.SetActive(true);

                dartboardOutline.transform.position = endPosition;
                dartboardOutline.transform.rotation = Quaternion.LookRotation(-mainCam.transform.up, -mainCam.transform.forward);
            }
            endPosition = controller.Position + (control.transform.forward * 3.0f);
            laserLineRenderer.SetPosition(1, endPosition);
        }
        if (holding == holdState.dart)
        {
            laserLineRenderer.SetPosition(0, mainCam.transform.position);
            laserLineRenderer.SetPosition(1, mainCam.transform.position);
        }
        if (toggledMic == true && controller.TriggerValue < 0.2f)
        {
            toggledMic = false;
        }
    }
    private void PlaceObject()
    {
        if (holding == holdState.dartboard)
        {
            if (!objSelected)
            {
                // Only triggers if Realtime is connected
                if (_realtimeObject.connected && realtimeDartboard == false)
                {
                    realtimeDartboard = true;
                    dartboardHolder.transform.position = new Vector3(100, 100, 100);
                    dartboardHolder = Realtime.Instantiate(dartboardRealtime.name, new Vector3(100, 100, 100), new Quaternion(0, 0, 0, 0), true, false, true, null);
                    dartboard = dartboardHolder.transform.GetChild(0).gameObject;
                    var dartboardCollider = dartboard.GetComponent<MeshCollider>();
                    dartboardCollider.enabled = false;
                    dartboardHolder.GetComponent<RealtimeView>().RequestOwnership();
                    dartboardHolder.GetComponent<RealtimeTransform>().RequestOwnership();
                }

                if (controller.TriggerValue >= 0.9f && !lockedDartboard)
                {
                    lockedDartboard = true;
                    dartboardHolder.SetActive(true);
                    dartboardHolder.transform.position = endPosition;
                    dartboardHolder.transform.rotation = Quaternion.LookRotation(-mainCam.transform.up, -mainCam.transform.forward);
                }
                else if (controller.TriggerValue <= 0.2f && lockedDartboard)
                {
                    lockedDartboard = false;
                }
            }
        }
        else if (holding == holdState.none && !tutorialMenu.activeSelf)
        {
            laserLineRenderer.material = activeMat;
        }
    }
    private void HoldingDart()
    {
        //var oldPosition = dart.transform.position;
        var oldPosition = dart.transform.position;
        var newPosition = controller.Position;

        var delta = newPosition - oldPosition;
        if (Deltas.Count == 15)
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
        var forcePerSecondAvg = toAverage * 300;
        forcePerSecond = forcePerSecondAvg;
        dart.transform.position = controlOrientationObj.transform.position;
        //dart.transform.rotation = controller.Orientation;
        dart.transform.rotation = controlOrientationObj.transform.rotation;
    }

    private void SpawnObject()
    {
        if (totalObjs < objLimit)
        {
            if (!noGravity)
            {
                if (holding == holdState.dart)
                {
                    if (!objSelected)
                    {
                        if (_realtimeObject.connected)
                        {
                            // Spawn dart while connected to realtime room and gravity is enabled
                            //dart = Realtime.Instantiate(dartRealtime.name, controller.Position, controller.Orientation, true, false, true, null);
                            dart.transform.parent = dartHolder;

                            dart.GetComponent<RealtimeView>().RequestOwnership();
                            dart.GetComponent<RealtimeTransform>().RequestOwnership();

                            Transform dartChild = dart.gameObject.transform.GetChild(0);

                            Renderer dartRender = dartChild.GetComponent<Renderer>();
                            dartRender.material = dartMats[PlayerPrefs.GetInt("dartColorInt", 0)];

                            Rigidbody dartRB = dartChild.GetComponent<Rigidbody>();
                            dartRB.useGravity = false;

                        }
                        else
                        {
                            // Spawn dart while NOT connected to multiplayer room and gravity is enabled
                            //dart = Instantiate(dartPrefab, controller.Position, controller.Orientation, dartHolder);
                            dart = Transmission.Spawn("Dart", controller.Position, controller.Orientation, Vector3.one);
                            dart.transform.parent = dartHolder;

                            holdingDart = true;

                            //Transform dartChild = dart.gameObject.transform.GetChild(0);

                            Renderer dartRender = dart.transform.GetComponent<Renderer>();
                            dartRender.material = dartMats[PlayerPrefs.GetInt("dartColorInt", 0)];

                            Rigidbody dartRB = dart.transform.GetComponent<Rigidbody>();
                            dartRB.useGravity = false;
                        }
                    }
                }
            }
            else
            {
                if (holding == holdState.dart)
                {
                    if (!objSelected)
                    {
                        if (_realtimeObject.connected)
                        {
                            // Spawn dart while connected to realtime room and gravity is NOT enabled
                            // dart = Realtime.Instantiate(dartRealtime.name, controller.Position, controller.Orientation, true, false, true, null);
                            dart.transform.parent = dartHolder;

                            dart.GetComponent<RealtimeView>().RequestOwnership();
                            dart.GetComponent<RealtimeTransform>().RequestOwnership();

                            Transform dartChild = dart.gameObject.transform.GetChild(0);

                            Renderer dartRender = dartChild.GetComponent<Renderer>();
                            dartRender.material = dartMats[PlayerPrefs.GetInt("dartColorInt", 0)];

                            UpdateColor _dartCol = dart.GetComponent<UpdateColor>();
                            _dartCol._objColor = dartMats[PlayerPrefs.GetInt("dartColorInt", 0)].color;

                            Rigidbody dartRB = dartChild.GetComponent<Rigidbody>();
                            dartRB.useGravity = false;
                        }
                        else
                        {
                            // Spawn dart while NOT connected to realtime room and gravity is NOT enabled
                           // dart = Instantiate(dartPrefab, controller.Position, controller.Orientation, dartHolder);
                            dart.transform.parent = dartHolder;

                            Transform dartChild = dart.gameObject.transform.GetChild(0);

                            Renderer dartRender = dartChild.GetComponent<Renderer>();
                            dartRender.material = dartMats[PlayerPrefs.GetInt("dartColorInt", 0)];

                            Rigidbody dartRB = dartChild.GetComponent<Rigidbody>();
                            dartRB.useGravity = false;
                        }
                    }
                }
            }
        }
        else if (!dartLimitAppeared)
        {
            dartLimitAppeared = true;
            helpMenu.transform.position = mainCam.transform.position + mainCam.transform.forward * 8.0f;
            helpMenu.transform.rotation = mainCam.transform.rotation;
            dartLimitMenu.SetActive(true);
        }
        else
        {
            dart = null;
        }
        // Recount the total number of darts currently in the game to ensure that there are never too many on screen (by objLimit)
        GetCount();
    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        currentPage = 1;
        SetTutorialPage(false);
        if (button == MLInputControllerButton.Bumper)
        {
            print("yee");
            holding = holdState.none;
            dartboardOutline.SetActive(false);

            tutorialMenu.SetActive(false);
            multiplayerStatusMenu.SetActive(false);
            multiplayerConfirmMenu.SetActive(false);
            multiplayerMenu.SetActive(false);
            modifierMenu.SetActive(false);
            menu.SetActive(false);

            if (objMenu.activeSelf)
            {
                print("inactive");
                objMenu.SetActive(false);
            }
            else
            {
                print("ObjMenu");
                objMenu.transform.position = control.transform.position + control.transform.forward * 0.6f;
                objMenu.transform.rotation = new Quaternion(control.transform.rotation.x, control.transform.rotation.y, 0, control.transform.rotation.w);
                menu.SetActive(false);
                modifierMenu.SetActive(false);
                objMenu.SetActive(true);
            }
        }
        else
        {

            dartMenu.SetActive(false);
            holding = holdState.none;
            dartboardOutline.SetActive(false);

            tutorialMenu.SetActive(false);
            helpAppeared = true;

            if (menu.activeSelf)
            {
                menu.SetActive(false);
                modifierMenu.SetActive(false);
                multiplayerConfirmMenu.SetActive(false);
                multiplayerStatusMenu.SetActive(false);
                multiplayerMenu.SetActive(false);
            }
            else
            {
                objMenu.SetActive(false);
                laserLineRenderer.material = activeMat;
                menu.SetActive(true);
                modifierMenu.SetActive(false);
                multiplayerMenu.SetActive(false);
            }
        }

        menuCanvas.transform.position = mainCam.transform.position + mainCam.transform.forward * 1.0f;
        menuCanvas.transform.LookAt(mainCam.transform.position);

        holding = holdState.none;
    }
    private void ClearAllObjects()
    {
        foreach (Transform child in dartHolder)
        {
            GameObject.Destroy(child.gameObject);
        }
        totalObjs = 0;
        holding = holdState.none;
        GetCount();
    }
    private void GetCount()
    {
        totalObjs = 0;
        foreach (Transform dartObj in dartHolder)
        {
            Transform objectstotal = dartObj.GetComponentInChildren<Transform>();
            totalObjs += objectstotal.childCount;
        }
        dartLimitText.text = "Dart Limit:\n " + totalObjs + " of 40";
    }
    private void CheckNewUser()
    {
        // TODO: CHANGE INT BACK TO 1, CURRENT IMPLEMENTATION WILL ALWAYS SHOW TUTORIAL
        if (PlayerPrefs.GetInt("hasPlayedDarts") == 1)
        {
            print("Played");
            tutorialActive = false;
            tutorialMenu.SetActive(false);
            laserLineRenderer.material = activeMat;
        }
        else
        {
            menuCanvas.transform.position = mainCam.transform.position + mainCam.transform.forward * 1.5f;
            menuCanvas.transform.LookAt(mainCam.transform.position);
            Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
            laserLineRenderer.SetPositions(initLaserPositions);
            print("Not Played");
            tutorialMenu.SetActive(true);
            PlayerPrefs.SetInt("hasPlayedDarts", 1);
        }
    }

    private void OnTriggerDown(byte controller_id, float triggerValue)
    {
        if (!holdingDart)
        {
            SpawnObject();
        }
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
            case "ChangeDart":
                // dart = Instantiate(dartPrefab, new Vector3(100, 100, 100), controller.Orientation, dartHolder);
                dart.transform.parent = dartHolder;
                dartMenu.transform.position = mainCam.transform.position + (mainCam.transform.forward * 1.5f);
                dartMenu.transform.LookAt(mainCam.transform.position);
                dartMenu.SetActive(true);
                menu.SetActive(false);
                holdingDartMenu = true;
                menuAudio.Play();
                break;
            case "Red":
                if (colorObjSelected == 0)
                {
                    PlayerPrefs.SetInt("dartColorInt", 0);
                }
                else
                {
                    PlayerPrefs.SetInt("multiplayerAvatarDartInt", 0);
                }
                break;
            case "Yellow":
                if (colorObjSelected == 0)
                {
                    PlayerPrefs.SetInt("dartColorInt", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("multiplayerAvatarDartInt", 1);
                }
                break;
            case "Orange":
                if (colorObjSelected == 0)
                {
                    PlayerPrefs.SetInt("dartColorInt", 2);
                }
                else
                {
                    PlayerPrefs.SetInt("multiplayerAvatarDartInt", 2);
                }
                break;
            case "Blue":
                if (colorObjSelected == 0)
                {
                    PlayerPrefs.SetInt("dartColorInt", 3);
                }
                else
                {
                    PlayerPrefs.SetInt("multiplayerAvatarDartInt", 3);
                }
                break;
            case "Green":
                if (colorObjSelected == 0)
                {
                    PlayerPrefs.SetInt("dartColorInt", 4);
                }
                else
                {
                    PlayerPrefs.SetInt("multiplayerAvatarDartInt", 4);
                }
                break;
            case "DartColor":
                colorObjSelected = 0;
                break;
            case "MultiplayerAvatar":
                colorObjSelected = 1;
                break;
            case "Modifiers":
                modifierMenu.SetActive(true);
                menu.SetActive(false);
                menuAudio.Play();
                break;
            case "Tutorial":
                menu.SetActive(false);
                holding = holdState.none;
                tutorialMenu.SetActive(true);
                PlayerPrefs.SetInt("hasPlayedDarts", 0);
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
                PlayerPrefs.SetInt("hasPlayedDarts", 0);
                CheckNewUser();
                tutorialActive = true;
                tutorialHelpMenu.SetActive(false);
                menuAudio.Play();
                break;
            case "NoThanks":
                tutorialHelpMenu.SetActive(false);
                menuAudio.Play();
                break;
            case "ToggleMic":
                if (toggledMic == false)
                {
                    toggledMic = true;
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
                _realtime.GetComponent<Realtime>().Disconnect();
                multiplayerStatusText.text = ("Multiplayer Status:\n" + "<color='red'>Not Connected</color>");
                dartboardHolder = GameObject.Find("DartboardHolder");
                multiplayerStatusMenu.SetActive(false);
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
            case "DartSelector":
                objMenu.SetActive(false);
                holding = holdState.dart;
                objSelected = true;
                break;
            case "DartboardSelector":
                objMenu.SetActive(false);
                holding = holdState.dartboard;
                objSelected = true;
                dart = null;
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
            // Past this point holds the buttons for the multiplayer menu(s)
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
                if (networkConnected == false)
                {
                    multiplayerCodeText.text = ("<color='red'>No Internet Connection</color>");
                }
                else
                {
                    multiplayerCodeText.color = Color.white;
                    if (roomCode.Length < 18)
                    {
                        roomCode += objGameHit;
                        multiplayerCodeText.text = roomCode;
                        menuAudio.Play();
                    }
                }
                break;
            case "Delete":
                if (roomCode.Length > 0)
                {
                    roomCode = roomCode.Substring(0, roomCode.Length - 1);
                    multiplayerCodeText.text = roomCode;
                }
                menuAudio.Play();
                break;
            case "Join":
                MLNetworking.IsInternetConnected(ref networkConnected);
                if (networkConnected == false)
                {
                    multiplayerCodeText.text = ("<color='red'>No Internet Connection</color>");
                }
                else
                {
                    if (roomCode.Length < 1)
                    {
                        multiplayerCodeText.text = "Please enter a code";
                    }
                    else
                    {
                        _realtime = GameObject.Find("Realtime + VR Player");
                        // Connect to Realtime room
                        _realtime.GetComponent<Realtime>().Connect(roomCode + "Darts");
                        multiplayerStatusText.text = ("Multiplayer Status:\n" + "<color='yellow'>Connecting</color>");
                        multiplayerMenu.SetActive(false);
                        multiplayerStatusMenu.SetActive(true);
                        multiplayerMenuCodeText.text = ("<b>Room Code:</b>\n" + roomCode);
                        menuAudio.Play();
                    }
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
    private void OnTriggerUp(byte controller_id, float triggerValue)
    {
        if (holdingDart)
        {
            holdingDart = false;
            //var rigidbody = dart.transform.GetChild(0).gameObject.GetComponent<Rigidbody>();
            var rigidbody = dart.transform.GetComponent<Rigidbody>();
            if (!noGravity)
            {
                rigidbody.useGravity = true;
            }
            rigidbody.velocity = Vector3.zero;
            //rigidbody.AddForce(forcePerSecond, ForceMode.VelocityChange);
            rigidbody.velocity = forcePerSecond;
        }
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
        currentTutorialPage = GameObject.Find("/Menu/Canvas/Tutorial/" + currentPage);
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