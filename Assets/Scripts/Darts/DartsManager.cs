#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using MagicLeapTools;

public class DartsManager : MonoBehaviour
{
    private enum holdState
    {
        none,
        dart,
        dartboard
    }
    private enum spawnState
    {
        none,
        dart,
        dartMultiplayer,
        dartboard,
        dartboardMultiplayer
    }

    // Input
    private enum HandPoses { OpenHand, Fist, NoPose };
    private HandPoses pose = HandPoses.NoPose;
    private Vector3[] pos;
    private MLHandKeyPose[] _gestures;

    private MLInputController controller;
    [SerializeField] private Pointer pointer;
    [SerializeField] private GameObject controlPointer;
    private MLHand currentHand;

    private holdState holding = holdState.none;
    private spawnState spawning = spawnState.none;

    private Rigidbody dartRB;
    private MeshRenderer dartRenderer;

    [SerializeField] private GameObject menu, modifierMenu, tutorialMenu, dartMenu, multiplayerMenu, multiplayerConfirmMenu, helpMenu, tutorialHelpMenu, deleteMenu, multiplayerStatusMenu, objMenu, handMenu, dartLimitMenu;
    [SerializeField] private GameObject mainCam, control, dartPrefab, dartboardHolder, dartboardOutline, deleteLoader, menuCanvas, handCenter, toggleMicButton, dartSelector, dartboardSelector, swapHandButton, tutorialLeft, tutorialRight, tutorialLeftText, tutorialRightText, controlOrientationObj;
    private GameObject  _realtime, currentTutorialPage;
    [SerializeField] private GameObject[] tutorialPage;

    [SerializeField] private Text dartLimitText, multiplayerCodeText, multiplayerStatusText, multiplayerMenuCodeText, connectedPlayersText, noGravityText, gestureHandText;

    [SerializeField] private Transform dartHolder, meshHolder;

    private GameObject dart, dartboard;
    private TransmissionObject dartMultiplayer, dartboardMultiplayer;

    [SerializeField] private Material[] dartMats, meshMats;
    [SerializeField] private MeshRenderer mesh;

    private string roomCode = "";
    private Vector3 endPosition, forcePerSecond;
    private float  totalObjs = 0, objLimit = 40, timeOfFirstHomePress, timer = 0.0f, waitTime = 30.0f, menuMoveSpeed, connectedPlayers, deleteTimer = 0.0f, bumperTest, colorObjSelected = 0;
    [SerializeField] private Image loadingImage;
    [SerializeField] private Texture2D emptyCircle, check, handLeft, handRight;

    private int currentPage = 0;

    private bool holdingDart = false, noGravity = false, occlusionActive = true, realtimeDartboard = false, helpAppeared = false, networkConnected, objSelected = false, dartLimitAppeared, leftHand = true, joinedLobby = true;
    public static bool lockedDartboard = false;
    List<Vector3> Deltas = new List<Vector3>();

    public AudioSource menuAudio;

    // Use this for initialization
    void Start()
    {
        CheckNewUser();

        MLInput.Start();

        controller = MLInput.GetController(0);
        MLInput.OnControllerButtonDown += OnButtonDown;

        MLInput.OnTriggerDown += OnTriggerDown;
        MLInput.TriggerDownThreshold = 0.75f;

        MLInput.OnTriggerUp += OnTriggerUp;
        MLInput.TriggerUpThreshold = 0.2f;


        MLHands.Start();
        _gestures = new MLHandKeyPose[2];
        _gestures[0] = MLHandKeyPose.OpenHand;
        _gestures[1] = MLHandKeyPose.Fist;
        MLHands.KeyPoseManager.EnableKeyPoses(_gestures, true, false);
        pos = new Vector3[1];

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
            currentHand = MLHands.Right;
        }

        currentTutorialPage = GameObject.Find("/[CONTENT]/Menu/Canvas/Tutorial/0");
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
    void Update()
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

        control.transform.position = controller.Position;
        control.transform.rotation = controller.Orientation;

        menuMoveSpeed = Time.deltaTime * 2f;

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
        Vector3 camPos = mainCam.transform.position + mainCam.transform.forward * 1.0f;
        helpMenu.transform.position = Vector3.SlerpUnclamped(helpMenu.transform.position, camPos, menuMoveSpeed);

        Quaternion rot = Quaternion.LookRotation(helpMenu.transform.position - mainCam.transform.position);
        helpMenu.transform.rotation = Quaternion.Slerp(helpMenu.transform.rotation, rot, menuMoveSpeed);

        if (holding == holdState.dartboard) {
            dartboardOutline.SetActive(true);

            dartboardOutline.transform.position = endPosition;
            dartboardOutline.transform.rotation = Quaternion.LookRotation(-mainCam.transform.up, -mainCam.transform.forward);
        }
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
                helpAppeared = true;
            }
        }
    }

    private void CheckGestures()
    {
        if (GetUserGesture.GetGesture(currentHand, MLHandKeyPose.OpenHand))
        {
            pose = HandPoses.OpenHand;
            helpAppeared = true;
        }
        else if (GetUserGesture.GetGesture(currentHand, MLHandKeyPose.Fist))
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
                pos[0] = currentHand.Middle.KeyPoints[0].Position;
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
            pos[0] = currentHand.Middle.KeyPoints[0].Position;
            handCenter.transform.position = pos[0];
            handCenter.transform.LookAt(mainCam.transform.position);
        }
    }

    private void HoldingDart()
    {
        Vector3 oldPosition;
        if (joinedLobby) {
            oldPosition = dartMultiplayer.transform.position;
        } else {
            oldPosition = dart.transform.position;
        }
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

        if (joinedLobby) {
            dartMultiplayer.transform.position = controlOrientationObj.transform.position;
            dartMultiplayer.transform.rotation = controlOrientationObj.transform.rotation;
        } else {
            dart.transform.position = controlOrientationObj.transform.position;
            dart.transform.rotation = controlOrientationObj.transform.rotation;
        }
    }

    private void SpawnObject() {
        switch (spawning) {
            case spawnState.dart:
                dart = Instantiate((GameObject)Instantiate(Resources.Load("Dart")), controller.Position, controller.Orientation, dartHolder);
                ConfigureDart();
                break;
            case spawnState.dartMultiplayer:
                dartMultiplayer = Transmission.Spawn("DartMultiplayer", controller.Position, controller.Orientation, Vector3.one);
                ConfigureDart();
                break;
            case spawnState.dartboard:
                dartboard = Instantiate((GameObject)Instantiate(Resources.Load("Dartboard"), pointer.transform.position, controller.Orientation));
                break;
            case spawnState.dartboardMultiplayer:
                dartboardMultiplayer = Transmission.Spawn("DartboardMultiplayer", pointer.transform.position, controller.Orientation, Vector3.one);
                break;
            default:
            // Do I need to set dart = null if nothing selected?
                break;
        }
        GetCount();
    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        if (tutorialMenu.activeSelf) {
            tutorialMenu.SetActive(false);
        }
        currentPage = 1;
        SetTutorialPage(false);
        if (button == MLInputControllerButton.Bumper)
        {
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
                objMenu.SetActive(false);
            }
            else
            {
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
            tutorialMenu.SetActive(false);
        }
        else
        {
            menuCanvas.transform.position = mainCam.transform.position + mainCam.transform.forward * 1.5f;
            menuCanvas.transform.LookAt(mainCam.transform.position);

            tutorialMenu.SetActive(true);
            PlayerPrefs.SetInt("hasPlayedDarts", 1);
        }
    }

    private void OnTriggerDown(byte controller_id, float triggerValue)
    {
        if (!holdingDart)
        {
            if (totalObjs < objLimit) {
                SpawnObject();
            } else if (!dartLimitAppeared) {
                dartLimitAppeared = true;
                helpMenu.transform.position = mainCam.transform.position + mainCam.transform.forward * 8.0f;
                helpMenu.transform.rotation = mainCam.transform.rotation;
                dartLimitMenu.SetActive(true);
            }
        }
        string objGameHit = pointer.Target.gameObject.name;
        switch (objGameHit)
        {
            case "Home":
                MLInput.Stop();
                MLHands.Stop();
                menu.SetActive(false);

                MLInput.OnControllerButtonDown -= OnButtonDown;
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
                menuAudio.Play();
                break;
            case "JoinLobby":
                if (joinedLobby)
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
                dart.transform.parent = dartHolder;
                dartMenu.transform.position = mainCam.transform.position + (mainCam.transform.forward * 1.5f);
                dartMenu.transform.LookAt(mainCam.transform.position);
                dartMenu.SetActive(true);
                menu.SetActive(false);
                menuAudio.Play();
                break;
            case "Red":
                SetDartColor(0);
                break;
            case "Yellow":
                SetDartColor(1);
                break;
            case "Orange":
                SetDartColor(2);
                break;
            case "Blue":
                SetDartColor(3);
                break;
            case "Green":
                SetDartColor(4);
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
                tutorialHelpMenu.SetActive(false);
                menuAudio.Play();
                break;
            case "NoThanks":
                tutorialHelpMenu.SetActive(false);
                menuAudio.Play();
                break;
            case "LeaveRoom":
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
                    currentHand = MLHands.Right;
                }
                else
                {
                    PlayerPrefs.SetString("gestureHand", "left");
                    swapHandButton.GetComponent<MeshRenderer>().material.mainTexture = handLeft;
                    gestureHandText.text = ("Gestures:\n Left Hand");
                    currentHand = MLHands.Left;
                }
                break;
            case "DartSelector":
                objMenu.SetActive(false);
                if (joinedLobby) {
                    spawning = spawnState.dartMultiplayer;
                } else  {
                    spawning = spawnState.dart;
                }
                holding = holdState.dart;
                break;
            case "DartboardSelector":
                objMenu.SetActive(false);
                if (joinedLobby) {
                    spawning = spawnState.dartboardMultiplayer;
                } else {
                    spawning = spawnState.dartboard;
                }
                holding = holdState.dartboard;
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
            var rigidbody = dart.transform.GetComponent<Rigidbody>();
            if (!noGravity)
            {
                rigidbody.useGravity = true;
            }
            rigidbody.velocity = Vector3.zero;
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
    private void SetDartColor(int colorChoice) {
        PlayerPrefs.SetInt("dartColorInt", colorChoice);
        dartMenu.SetActive(false);
    }
    private void ConfigureDart() {
        int dartColor = PlayerPrefs.GetInt("dartColorInt");
        if (joinedLobby) {
            dartRenderer = dartMultiplayer.GetComponent<MeshRenderer>();
            dartRB = dartMultiplayer.GetComponent<Rigidbody>();
        } else {
            dartRenderer = dart.GetComponent<MeshRenderer>();
            dartRB = dart.GetComponent<Rigidbody>();
        }
        dartRenderer.material = dartMats[dartColor];
        dartRB.useGravity = false;
    }
}