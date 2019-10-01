using System.Collections;
using System.Collections.Generic;
using Normal.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

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
    public GameObject mainCam, control, dartPrefab, dartboardHolder, dartboardOutline, menu, modifierMenu, tutorialMenu, dartMenu, multiplayerMenu, dartboard, deleteLoader, menuCanvas, handCenter, multiplayerConfirmMenu, helpMenu, tutorialHelpMenu, deleteMenu, multiplayerStatusMenu, localPlayer, toggleMicButton, objMenu, dartSelector, dartboardSelector, handMenu;
    public Text dartLimitText, multiplayerCodeText, multiplayerStatusText, multiplayerMenuCodeText, connectedPlayersText, noGravityText;
    public Transform dartHolder, meshHolder;
    public static GameObject menuControl;
    private GameObject dart, _realtime;
    public Material transparent, activeMat;
    public Material[] dartMats, meshMats;
    public LineRenderer laserLineRenderer;
    public MeshRenderer mesh;
    private string roomCode = "";
    private Vector3 endPosition, forcePerSecond;
    private float timeHold = 3.0f, totalObjs = 0, objLimit = 20, timeHomePress = 0.01f, timeOfFirstHomePress, timer = 0.0f, waitTime = 30.0f, menuMoveSpeed, connectedPlayers, deleteTimer = 0.0f, bumperTest;
    private Controller checkController;
    [SerializeField] private GameObject dartRealtime = null, dartboardRealtime = null;
    public Image loadingImage;
    public Texture2D emptyCircle, check;

    public Realtime _realtimeObject;
    private PlayerManagerModel _playerManager;

    private bool setHand = false, holdingDart = false, tutorialActive = true, noGravity = false, dartMenuOpened = false, holdingDartMenu = true, tutorialBumperPressed, tutorialHomePressed, movingDartboard = true, settingsOpened = false, occlusionActive = true, tutorialMenuOpened = false, firstHomePressed = false, multiplayerMenuOpen = false, pickedNumber = true, deletedCharacter = false, joinedLobby = false, realtimeDartboard = false, helpAppeared = false, initializedRealtimePlayer = false, micActive = true, getLocalPlayer = false, toggledMic = false, networkConnected, objSelected = false, buttonLock = false;
    private static bool menuClosed = false, menuOpened = false;
    public static bool lockedDartboard = false;
    List<Vector3> Deltas = new List<Vector3>();

    public AudioSource menuAudio;

    // Use this for initialization
    void Start()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);

        print("Buttonz");
        CheckNewUser();
        MLInput.Start();
        print("Checking input..." + MLInput.IsStarted);

        print("Getting controller..");
        controller = MLInput.GetController(MLInput.Hand.Left);
        MLInput.OnControllerButtonDown += OnDartsButtonDown;
        MLInput.OnControllerButtonUp += OnDartsButtonUp;

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
            if ((controller.Touch1Active || controller.TriggerValue >= 0.2f || tutorialBumperPressed || tutorialHomePressed) && tutorialMenuOpened == false)
            {
                laserLineRenderer.material = activeMat;
                CheckNewUser();
            }
        }
        if (controller.Touch1Active)
        {
            if (menuClosed == false)
            {
                menuControl.SetActive(true);
            }
            if (setHand == false)
            {
                setHand = true;

                menuControl.transform.position = controller.Position;
                menuControl.transform.rotation = mainCam.transform.rotation;
            }
        }

        if (controller.Touch1Active == false)
        {
            menuClosed = false;
            setHand = false;
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
    }
    private void CheckGestures()
    {
        if (GetUserGesture.GetGesture(MLHands.Left, MLHandKeyPose.OpenHand))
        {
            pose = HandPoses.OpenHand;
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

        // Set the origin of the line to the controller's position, because the first position does not dynamically change
        laserLineRenderer.SetPosition(0, controller.Position);
        if (Physics.Raycast(controller.Position, heading, out rayHit, 10.0f))
        {
            endPosition = controller.Position + (control.transform.forward * rayHit.distance);
            laserLineRenderer.SetPosition(1, endPosition);

            if (settingsOpened && controller.TriggerValue <= 0.2f)
            {
                settingsOpened = false;
            }

            if (rayHit.transform.gameObject.name == "Home" && controller.TriggerValue >= 0.9f)
            {
                MLInput.Stop();
                MLHands.Stop();
                MLInput.OnControllerButtonDown -= OnDartsButtonDown;
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
                menuAudio.Play();
            }
            else if (rayHit.transform.gameObject.name == "JoinLobby" && controller.TriggerValue >= 0.9f)
            {
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
            }
            else if (rayHit.transform.gameObject.name == "AcceptTerms" && controller.TriggerValue >= 0.9f && multiplayerMenuOpen == false)
            {
                multiplayerMenu.SetActive(true);
                multiplayerMenuOpen = true;
                multiplayerConfirmMenu.SetActive(false);
                menuAudio.Play();
            }
            else if (rayHit.transform.gameObject.name == "CancelTerms" && controller.TriggerValue >= 0.9f)
            {
                multiplayerConfirmMenu.SetActive(false);
                menuOpened = true;
                menu.SetActive(true);
                menuAudio.Play();
            }
            else if (rayHit.transform.gameObject.name == "ChangeDart" && controller.TriggerValue >= 0.9f)
            {
                dart = Instantiate(dartPrefab, new Vector3(100, 100, 100), controller.Orientation, dartHolder);
                dart.transform.parent = dartHolder;
                dartMenu.transform.position = mainCam.transform.position + (mainCam.transform.forward * 1.5f);
                dartMenu.transform.LookAt(mainCam.transform.position);
                dartMenu.SetActive(true);
                menuClosed = true;
                menu.SetActive(false);
                dartMenuOpened = true;
                holdingDartMenu = true;
                menuAudio.Play();
            }
            else if (rayHit.transform.gameObject.name == "Modifiers" && controller.TriggerValue >= 0.9f)
            {
                modifierMenu.SetActive(true);
                menu.SetActive(false);
                menuClosed = true;
                settingsOpened = true;
                menuAudio.Play();
            }
            else if (rayHit.transform.gameObject.name == "Tutorial" && controller.TriggerValue >= 0.9f)
            {
                menuClosed = true;
                menuOpened = false;
                menu.SetActive(false);
                holding = holdState.none;
                tutorialActive = true;
                tutorialMenuOpened = true;
                tutorialMenu.SetActive(true);
                tutorialBumperPressed = false;
                tutorialHomePressed = false;
                laserLineRenderer.material = transparent;
                PlayerPrefs.SetInt("hasPlayedDarts", 0);
                CheckNewUser();
                menuAudio.Play();
            }
            else if (rayHit.transform.gameObject.name == "YesPlease" && controller.TriggerValue >= 0.9f)
            {
                PlayerPrefs.SetInt("hasPlayedDarts", 0);
                CheckNewUser();
                tutorialMenuOpened = true;
                tutorialActive = true;
                tutorialHelpMenu.SetActive(false);
                menuAudio.Play();
            }
            else if (rayHit.transform.gameObject.name == "NoThanks" && controller.TriggerValue >= 0.9f)
            {
                tutorialHelpMenu.SetActive(false);
                menuAudio.Play();
            }
            else if (rayHit.transform.gameObject.name == "ToggleMic" && controller.TriggerValue >= 0.9f)
            {
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
            }
            else if (rayHit.transform.gameObject.name == "LeaveRoom" && controller.TriggerValue >= 0.9f)
            {
                joinedLobby = false;
                _realtime.GetComponent<Realtime>().Disconnect();
                multiplayerStatusText.text = ("Multiplayer Status:\n" + "<color='red'>Not Connected</color>");
                multiplayerStatusMenu.SetActive(false);
                menuOpened = false;
            }
            else if (rayHit.transform.gameObject.name == "NoGravity" && controller.TriggerValue >= 0.9f)
            {
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
                    // modifierMenu.SetActive (false);
                    // menuClosed = true;
                    // menuOpened = false;
                }
                menuAudio.Play();
            }
            else if (rayHit.transform.gameObject.name == "DartSelector")
            {
                GameObject selector = GameObject.Find("DartSelector");
                if (selector.transform.localScale.x < 4)
                {
                    Vector3 localObjScale = selector.transform.localScale;
                    localObjScale.x += Time.deltaTime * 5.0f;
                    localObjScale.y += Time.deltaTime * 5.0f;
                    localObjScale.z += Time.deltaTime * 5.0f;
                    selector.transform.localScale = localObjScale;
                }
                if (controller.TriggerValue >= 0.9f)
                {
                    objMenu.SetActive(false);
                    holding = holdState.dart;
                    objSelected = true;
                }
            }
            else if (rayHit.transform.gameObject.name == "DartboardSelector")
            {
                GameObject selector = GameObject.Find("DartboardSelector");
                if (selector.transform.localScale.x < 4)
                {
                    Vector3 localObjScale = selector.transform.localScale;
                    localObjScale.x += Time.deltaTime * 5.0f;
                    localObjScale.y += Time.deltaTime * 5.0f;
                    localObjScale.z += Time.deltaTime * 5.0f;
                    selector.transform.localScale = localObjScale;
                }
                if (controller.TriggerValue >= 0.9f)
                {
                    objMenu.SetActive(false);
                    holding = holdState.dartboard;
                    objSelected = true;
                    dart = null;
                }
            }
            else if (rayHit.transform.gameObject.name == "ShowMesh" && controller.TriggerValue >= 0.9f)
            {
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
                    menuClosed = true;
                }
                menuAudio.Play();
            }
            if (!holdingDartMenu)
            {
                DartColorLoader.GetDartColor(rayHit.transform.gameObject.name, controller, dartMenu, dartMenuOpened, holdingDartMenu, dart, dartMats);
            }
            else if (holdingDartMenu && controller.TriggerValue <= 0.2f)
            {
                holdingDartMenu = false;
            }
            if (dartSelector.transform.localScale.x > 3.33f && rayHit.transform.gameObject.name != "DartSelector")
            {
                Vector3 localObjScale = dartSelector.transform.localScale;
                localObjScale.x -= Time.deltaTime * 5.0f;
                localObjScale.y -= Time.deltaTime * 5.0f;
                localObjScale.z -= Time.deltaTime * 5.0f;
                dartSelector.transform.localScale = localObjScale;
            }
            if (dartboardSelector.transform.localScale.x > 3.33f && rayHit.transform.gameObject.name != "DartboardSelector")
            {
                Vector3 localObjScale = dartboardSelector.transform.localScale;
                localObjScale.x -= Time.deltaTime * 5.0f;
                localObjScale.y -= Time.deltaTime * 5.0f;
                localObjScale.z -= Time.deltaTime * 5.0f;
                dartboardSelector.transform.localScale = localObjScale;
            }
            if (multiplayerMenuOpen == true)
            {
                if ((rayHit.transform.gameObject.name == "0" || rayHit.transform.gameObject.name == "1" || rayHit.transform.gameObject.name == "2" || rayHit.transform.gameObject.name == "3" || rayHit.transform.gameObject.name == "4" || rayHit.transform.gameObject.name == "5" || rayHit.transform.gameObject.name == "6" || rayHit.transform.gameObject.name == "7" || rayHit.transform.gameObject.name == "8" || rayHit.transform.gameObject.name == "9") && controller.TriggerValue >= 0.9f && pickedNumber == false && roomCode.Length < 18)
                {
                    pickedNumber = true;
                    roomCode += rayHit.transform.gameObject.name;
                    multiplayerCodeText.text = roomCode;
                    menuAudio.Play();

                }
                else if (rayHit.transform.gameObject.name == "Delete" && controller.TriggerValue >= 0.9f && deletedCharacter == false)
                {
                    deletedCharacter = true;
                    if (roomCode.Length > 0)
                    {
                        roomCode = roomCode.Substring(0, roomCode.Length - 1);
                        multiplayerCodeText.text = roomCode;
                    }
                    menuAudio.Play();
                }
                else if (controller.TriggerValue <= 0.2f)
                {
                    pickedNumber = false;
                    deletedCharacter = false;
                }
                else if (rayHit.transform.gameObject.name == "Join" && controller.TriggerValue >= 0.9f && joinedLobby == false)
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
                        _realtime.GetComponent<Realtime>().Connect(roomCode + "Darts");
                        multiplayerStatusText.text = ("Multiplayer Status:\n" + "<color='yellow'>Connecting</color>");
                        multiplayerMenu.SetActive(false);
                        multiplayerMenuOpen = false;
                        multiplayerStatusMenu.SetActive(true);
                        multiplayerMenuCodeText.text = ("<b>Room Code:</b>\n" + roomCode);
                        menuAudio.Play();
                    }
                }
                else if (rayHit.transform.gameObject.name == "Cancel" && controller.TriggerValue >= 0.9f)
                {
                    multiplayerMenu.SetActive(false);
                    multiplayerMenuOpen = false;
                    menu.SetActive(true);
                    menuOpened = true;
                    roomCode = "";
                    menuAudio.Play();
                }

            }
        }
        else
        {
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
        if (holding == holdState.dart)
        {
            if (controller.TriggerValue >= 0.9f)
            {
                if (holdingDart)
                {
                    HoldingDart();
                }
                else
                {
                    SpawnObject();
                    holdingDart = true;
                }
            }
            else if (controller.TriggerValue <= 0.2f && holdingDart)
            {
                holdingDart = false;
                var rigidbody = dart.transform.GetChild(0).gameObject.GetComponent<Rigidbody>();
                if (!noGravity)
                {
                    rigidbody.useGravity = true;
                }
                rigidbody.velocity = Vector3.zero;
                rigidbody.velocity = forcePerSecond;
            }
        }
        else if (holding == holdState.dartboard)
        {
            if (!objSelected)
            {
                // Only triggers if Realtime is connected
                if (_realtimeObject.connected && realtimeDartboard == false)
                {
                    realtimeDartboard = true;
                    dartboardHolder = Realtime.Instantiate(dartboardRealtime.name, endPosition, new Quaternion(0, 0, 0, 0), true, false, true, null);
                    dartboard = dartboardHolder.transform.GetChild(0).gameObject;
                    var dartboardCollider = dartboard.GetComponent<MeshCollider>();
                    dartboardCollider.enabled = false;
                    dartboardHolder.GetComponent<RealtimeView>().RequestOwnership();
                    dartboardHolder.GetComponent<RealtimeTransform>().RequestOwnership();
                }

                dartboardOutline.SetActive(true);
                //dartboardHolder.SetActive (true);

                dartboardOutline.transform.position = endPosition;
                dartboardOutline.transform.rotation = Quaternion.LookRotation(-mainCam.transform.up, -mainCam.transform.forward);

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
        else if (holding == holdState.none && tutorialMenuOpened == false)
        {
            laserLineRenderer.material = activeMat;
        }
    }
    private void HoldingDart()
    {
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
        var forcePerSecondAvg = toAverage * 250;
        forcePerSecond = forcePerSecondAvg;
        dart.transform.position = controller.Position;
        dart.transform.rotation = controller.Orientation;
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
                            dart = Realtime.Instantiate(dartRealtime.name, controller.Position, controller.Orientation, true, false, true, null);
                            dart.transform.parent = dartHolder;
                            dart.GetComponent<RealtimeView>().RequestOwnership();
                            dart.GetComponent<RealtimeTransform>().RequestOwnership();
                            Transform dartChild = dart.gameObject.transform.GetChild(0);
                            Renderer dartRender = dartChild.GetComponent<Renderer>();
                            Rigidbody dartRB = dartChild.GetComponent<Rigidbody>();
                            dartRB.useGravity = false;
                            dartRender.material = dartMats[PlayerPrefs.GetInt("dartColorInt", 0)];
                        }
                        else
                        {
                            dart = Instantiate(dartPrefab, controller.Position, controller.Orientation, dartHolder);
                            dart.transform.parent = dartHolder;
                            Transform dartChild = dart.gameObject.transform.GetChild(0);
                            Renderer dartRender = dartChild.GetComponent<Renderer>();
                            Rigidbody dartRB = dartChild.GetComponent<Rigidbody>();
                            dartRB.useGravity = false;
                            dartRender.material = dartMats[PlayerPrefs.GetInt("dartColorInt", 0)];
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
                            dart = Realtime.Instantiate(dartRealtime.name, controller.Position, controller.Orientation, true, false, true, null);
                            dart.transform.parent = dartHolder;
                            Transform dartChild = dart.gameObject.transform.GetChild(0);
                            Renderer dartRender = dartChild.GetComponent<Renderer>();
                            Rigidbody dartRB = dartChild.GetComponent<Rigidbody>();
                            dartRB.useGravity = false;
                            dartRender.material = dartMats[PlayerPrefs.GetInt("dartColorInt", 0)];
                        }
                        else
                        {
                            dart = Instantiate(dartPrefab, controller.Position, controller.Orientation, dartHolder);
                            dart.transform.parent = dartHolder;
                            Transform dartChild = dart.gameObject.transform.GetChild(0);
                            Renderer dartRender = dartChild.GetComponent<Renderer>();
                            Rigidbody dartRB = dartChild.GetComponent<Rigidbody>();
                            dartRB.useGravity = false;
                            dartRender.material = dartMats[PlayerPrefs.GetInt("dartColorInt", 0)];
                        }
                    }
                }
            }
        }
        else
        {
            dart = null;
        }
        // Recount the total number of darts currently in the game to ensure that there are never too many on screen (by objLimit)
        GetCount();
    }

    void OnDartsButtonDown(byte controller_id, MLInputControllerButton button)
    {
        if (!buttonLock)
        {
            buttonLock = true;

            if (button == MLInputControllerButton.Bumper)
            {
                print("yee");
                holding = holdState.none;
                dartboardOutline.SetActive(false);

                if (tutorialActive)
                {
                    tutorialBumperPressed = true;
                }

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
                    objMenu.SetActive(true);
                }
            }
            else if (button == MLInputControllerButton.HomeTap)
            {
				print("gay");
                holding = holdState.none;
                dartboardOutline.SetActive(false);
                if (tutorialActive)
                {
                    tutorialHomePressed = true;
                }
                if (menuOpened)
                {
                    menuOpened = false;
                    menu.SetActive(false);
                    modifierMenu.SetActive(false);
                    multiplayerConfirmMenu.SetActive(false);
                    multiplayerMenuOpen = false;
                    multiplayerStatusMenu.SetActive(false);
                    multiplayerMenu.SetActive(false);
                }
                else
                {
                    laserLineRenderer.material = activeMat;
                    menuOpened = true;
                    menu.SetActive(true);
                    //CenterCam();
                    modifierMenu.SetActive(false);
                }
            }

            menuCanvas.transform.position = mainCam.transform.position + mainCam.transform.forward * 1.0f;
            menuCanvas.transform.LookAt(mainCam.transform.position);

            holding = holdState.none;
        }

    }
    void OnDartsButtonUp(byte controller_id, MLInputControllerButton button)
    {
        buttonLock = false;
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
    public static void CloseMenu()
    {
        print("Close the menu");
        menuClosed = true;
        menuControl.SetActive(false);
    }
    private void GetCount()
    {
        totalObjs = 0;
        foreach (Transform dartObj in dartHolder)
        {
            Transform objectstotal = dartObj.GetComponentInChildren<Transform>();
            totalObjs += objectstotal.childCount;
        }
        dartLimitText.text = "Dart Limit:\n " + totalObjs + " of 20";
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
            menuCanvas.transform.position = mainCam.transform.position + mainCam.transform.forward * 1.0f;
            menuCanvas.transform.LookAt(mainCam.transform.position);
            Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
            laserLineRenderer.SetPositions(initLaserPositions);
            print("Not Played");
            tutorialMenu.SetActive(true);
            PlayerPrefs.SetInt("hasPlayedDarts", 1);
        }
    }
    private void CenterCam()
    {
        while (!tutorialMenuOpened)
        {
            float speed = Time.deltaTime * 5f;

            Vector3 pos = mainCam.transform.position + mainCam.transform.forward * 1.0f;
            menu.transform.position = Vector3.SlerpUnclamped(menu.transform.position, pos, speed);

            Quaternion rot = Quaternion.LookRotation(menu.transform.position - mainCam.transform.position);
            menu.transform.rotation = Quaternion.Slerp(menu.transform.rotation, rot, speed);
        }
    }
}