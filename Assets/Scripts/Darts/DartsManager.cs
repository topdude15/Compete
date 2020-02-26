#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using MagicLeapTools;

public class DartsManager : MonoBehaviour
{
    private enum spawnState
    {
        none,
        dart,
        dartboard
    }
    // Control Input elements
    [Header("Control")]
    [SerializeField] private Pointer pointer;
    [SerializeField] private GameObject controlPointer, pointerCursor, control, controlObj;
    private MLInputController controller;

    // Hand Pose elements
    [Header("Hand Pose")]
    [SerializeField] private GameObject handCenter, clearProgress;
    [SerializeField] private Image clearProgressImg;
    private enum HandPoses { OpenHand, Fist, NoPose };
    private HandPoses pose = HandPoses.NoPose;
    private MLHand currentHand;
    private MLHandKeyPose[] _gestures;


    // Menu elements
    [Header("Menus")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject mainMenuCanvas, handMenu, helpMenu, tutorialMenu, multiplayerConfirmMenu, multiplayerCodeMenu, multiplayerActiveMenu, modifierMenu, dartColorMenu, dartLimitMenu, objMenu;
    [SerializeField] private GameObject[] tutorialPage;

    // Other elements
    [Header("Extra")]

    [SerializeField] private AudioSource menuAudio;
    [SerializeField] private GameObject mainCam, colorDartObj, transmissionObj, spatialAlignmentObj, tutorialRight, tutorialLeft, dartboardOutline, dartboardHolder;
    [SerializeField] private Transform dartHolder, dartPrefab;
    [SerializeField] private Text multiplayerCodeInputText, multiplayerCodeText, noGravityText, dartLimitText, showMeshText;
    private GameObject meshObjs, spatialMap, dart, meshOriginal, currentTutorialPage;
    private GameObject[] tutorialPages;
    private float clearTimer = 0.0f, helpTimer = 0.0f, menuMoveSpeed;
    private int totalObjs = 0, objLimit = 50, currentPage = 0;
    private spawnState spawning = spawnState.none;
    private bool allowHelp = true, joinedLobby = false, holdingDart = false, gravityEnabled = true, occlusionActive = true, forward;
    private string roomCode = "";
    private TransmissionObject dartMultiplayer, dartboardMultiplayer;
    private List<TransmissionObject> spawnedObjs;
    [SerializeField] private Material[] dartMats, meshMats;
    private Rigidbody dartRB;
    private Vector3 forcePerSecond;
    List<Vector3> Deltas = new List<Vector3>();

    void Start()
    {
        // Start MLInput, reference Control, and set listener functions
        MLInput.Start();
        controller = MLInput.GetController(0);
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnTriggerDown += OnTriggerDown;
        MLInput.OnTriggerUp += OnTriggerUp;
        MLInput.TriggerDownThreshold = 0.75f;
        MLInput.TriggerUpThreshold = 0.15f;
        // Start MLHands and start recognizing the OpenHand and Fist poses
        MLHands.Start();
        _gestures = new MLHandKeyPose[2];
        _gestures[0] = MLHandKeyPose.OpenHand;
        _gestures[1] = MLHandKeyPose.Fist;
        MLHands.KeyPoseManager.EnableKeyPoses(_gestures, true, false);

        // Set the currentHand variable used in hand recognition
        if (PlayerPrefs.GetString("gestureHand") == "right")
        {
            currentHand = MLHands.Right;
        }
        else
        {
            PlayerPrefs.SetString("gestureHand", "left");
            currentHand = MLHands.Left;
        }

        meshObjs = GameObject.Find("MeshObjects");
        spatialMap = GameObject.Find("MLSpatialMapper");
        meshOriginal = spatialMap.transform.GetChild(0).gameObject;

        currentTutorialPage = GameObject.Find("/[CONTENT]/Menu/MainMenuCanvas/Tutorial/0");

        menuMoveSpeed = Time.deltaTime * 2f;
    }

    void Update()
    {
        // Hand tracking updates each frame
        CheckGestures();

        // Use control to get forward value of Control position
        control.transform.position = controller.Position;
        control.transform.rotation = controller.Orientation;

        if (holdingDart)
        {
            print("holding");
            HoldingDart();
        }
        // If the user has not interacted with the game at all in 30 seconds, bring up the help menu
        helpTimer += Time.deltaTime;
        if (helpTimer > 30.0f && allowHelp)
        {
            helpMenu.transform.position = mainCam.transform.position + mainCam.transform.forward * 10f;
            helpMenu.SetActive(true);
        }

        if (spawning == spawnState.dartboard)
        {
            dartboardOutline.SetActive(true);
            dartboardOutline.transform.position = pointerCursor.transform.position;
            dartboardOutline.transform.rotation = Quaternion.LookRotation(-mainCam.transform.up, -mainCam.transform.forward);
        }

    }
    private void CheckGestures()
    {
        if (GetUserGesture.GetGesture(currentHand, MLHandKeyPose.OpenHand))
        {
            pose = HandPoses.OpenHand;
        }
        else if (GetUserGesture.GetGesture(currentHand, MLHandKeyPose.Fist))
        {
            pose = HandPoses.Fist;
        }
        else
        {
            pose = HandPoses.NoPose;
            // If no pose, make sure no hand content is being rendered
            clearProgress.SetActive(false);
            handMenu.SetActive(false);
        }
        if (pose != HandPoses.NoPose) ShowPoints();
        if (pose != HandPoses.Fist) clearTimer = 0.0f;
    }
    private void ShowPoints()
    {
        // Set handCenter to current hand center to show content
        handCenter.transform.position = currentHand.Middle.KeyPoints[0].Position;
        handCenter.transform.LookAt(mainCam.transform.position);
        // Functions for each hand pose
        if (pose == HandPoses.Fist)
        {
            handMenu.SetActive(false);
            clearProgress.SetActive(true);

            //  Count to 3 seconds for clear timer
            clearTimer += Time.deltaTime;
            float percentComplete = clearTimer / 3.0f;
            clearProgressImg.fillAmount = percentComplete;

            if (clearTimer > 3.0f)
            {
                ClearAllObjects();
                clearProgress.SetActive(false);
            }
        }
        else if (pose == HandPoses.OpenHand)
        {
            clearProgress.SetActive(false);
            handMenu.SetActive(true);
        }
    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        controlPointer.SetActive(true);
        dartboardOutline.SetActive(false);
        if (tutorialMenu.activeSelf) tutorialMenu.SetActive(false);

        if (button == MLInputControllerButton.Bumper)
        {
            spawning = spawnState.none;
            tutorialMenu.SetActive(false);
            multiplayerConfirmMenu.SetActive(false);
            multiplayerCodeMenu.SetActive(false);
            multiplayerActiveMenu.SetActive(false);
            modifierMenu.SetActive(false);
            mainMenu.SetActive(false);
            dartColorMenu.SetActive(false);

            if (objMenu.activeSelf)
            {
                objMenu.SetActive(false);
            }
            else
            {
                objMenu.transform.position = control.transform.position + control.transform.forward * 0.6f;
                objMenu.transform.rotation = new Quaternion(control.transform.rotation.x, control.transform.rotation.y, 0, control.transform.rotation.w);
                objMenu.SetActive(true);
            }
        }
        else
        {
            if (mainMenu.activeSelf)
            {
                mainMenu.SetActive(false);
            }
            else
            {
                mainMenu.SetActive(true);
            }
            tutorialMenu.SetActive(false);
            multiplayerConfirmMenu.SetActive(false);
            multiplayerCodeMenu.SetActive(false);
            multiplayerActiveMenu.SetActive(false);
            modifierMenu.SetActive(false);
            dartColorMenu.SetActive(false);
        }
        // Disable any spawning
        spawning = spawnState.none;
        // Do not allow the help menu to appear
        mainMenuCanvas.transform.position = mainCam.transform.position + mainCam.transform.forward * 1.0f;
        mainMenuCanvas.transform.LookAt(mainCam.transform.position);
        allowHelp = false;
        helpMenu.SetActive(false);
    }
    void OnTriggerDown(byte controller_id, float triggerValue)
    {
        // Do not allow the help menu to appear
        allowHelp = false;
        helpMenu.SetActive(false);
        if (spawning == spawnState.none)
        {
            string objGameHit = pointer.Target.gameObject.name;
            // If the user pulls the Trigger and something is selected, play the "Menu Click" sound
            if (objGameHit != null) menuAudio.Play();
            switch (objGameHit)
            {
                case "Home":
                    SceneManager.LoadScene("Main", LoadSceneMode.Single);
                    break;
                case "Tutorial":
                    PlayerPrefs.SetInt("hasPlayedDarts", 0);
                    CheckNewUser();
                    break;
                case "TutorialLeft":
                    SetTutorialPage(false);
                    break;
                case "TutorialRight":
                    SetTutorialPage(true);
                    break;
                // Multiplayer menu buttons
                case "Multiplayer":
                    if (!joinedLobby) multiplayerConfirmMenu.SetActive(true);
                    mainMenu.SetActive(false);
                    break;
                case "AcceptTerms":
                    multiplayerConfirmMenu.SetActive(false);
                    multiplayerCodeMenu.SetActive(true);
                    break;
                case "DeclineTerms":
                    multiplayerConfirmMenu.SetActive(false);
                    mainMenu.SetActive(true);
                    break;
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
                    // If a number is selected, add it to the roomCode and update the text accordingly
                    multiplayerCodeInputText.color = Color.white;
                    if (roomCode.Length < 18)
                    {
                        roomCode += objGameHit;
                        multiplayerCodeInputText.text = roomCode;
                    }
                    break;
                case "Delete":
                    if (roomCode.Length > 0)
                    {
                        roomCode = roomCode.Substring(0, roomCode.Length - 1);
                        multiplayerCodeInputText.text = roomCode;
                    }
                    break;
                case "Join":
                    ClearAllObjects();
                    joinedLobby = true;
                    if (roomCode.Length < 1)
                    {
                        multiplayerCodeInputText.text = "Please input a code!";
                    }
                    else
                    {
                        spatialAlignmentObj.SetActive(true);
                        transmissionObj.SetActive(true);
                        transmissionObj.GetComponent<Transmission>().privateKey = roomCode;
                        multiplayerCodeMenu.SetActive(false);
                        multiplayerActiveMenu.SetActive(true);
                        multiplayerCodeText.text = ("<b>Room Code:</b>\n" + roomCode);
                    }
                    break;
                case "Cancel":
                    multiplayerCodeMenu.SetActive(false);
                    mainMenu.SetActive(true);
                    break;
                case "LeaveRoom":
                    joinedLobby = false;
                    ClearAllObjects();
                    spatialAlignmentObj.SetActive(false);
                    transmissionObj.SetActive(false);
                    multiplayerActiveMenu.SetActive(false);
                    mainMenu.SetActive(true);
                    break;
                case "Settings":
                    mainMenu.SetActive(false);
                    modifierMenu.SetActive(true);
                    break;
                // Object selection menu
                case "DartSelector":
                    spawning = spawnState.dart;
                    objMenu.SetActive(false);
                    controlPointer.SetActive(false);
                    break;
                case "DartboardSelector":
                    spawning = spawnState.dartboard;
                    objMenu.SetActive(false);
                    break;
                // Dart Color menu buttons
                case "DartColor":
                    mainMenu.SetActive(false);
                    dartColorMenu.SetActive(true);
                    break;
                case "Red0":
                case "Yellow1":
                case "Orange2":
                case "Blue3":
                case "Green4":
                    string colorValue = Regex.Match(objGameHit, @"\d").Value;
                    int colorValueInt = int.Parse(colorValue);
                    PlayerPrefs.SetInt("dartColorInt", colorValueInt);
                    colorDartObj.GetComponentInChildren<MeshRenderer>().material = dartMats[colorValueInt];
                    break;
                case "CloseDartColor":
                    dartColorMenu.SetActive(false);
                    mainMenu.SetActive(true);
                    break;
                // Settings menu buttons
                case "NoGravity":
                    if (gravityEnabled)
                    {
                        gravityEnabled = false;
                        noGravityText.text = ("Enable Gravity");
                    }
                    else
                    {
                        gravityEnabled = true;
                        noGravityText.text = ("Disable Gravity");
                    }
                    break;
                case "ShowMesh":
                    if (occlusionActive)
                    {
                        foreach (Transform meshChild in meshObjs.transform)
                        {
                            meshChild.GetComponent<MeshRenderer>().material = meshMats[1];
                        }
                        meshOriginal.GetComponent<MeshRenderer>().material = meshMats[1];
                        showMeshText.text = "Hide Mesh";
                        occlusionActive = false;
                    }
                    else
                    {
                        foreach (Transform meshChild in meshObjs.transform)
                        {
                            meshChild.GetComponent<MeshRenderer>().material = meshMats[0];
                        }
                        meshOriginal.GetComponent<MeshRenderer>().material = meshMats[0];
                        showMeshText.text = "Show Mesh";
                        occlusionActive = true;
                    }
                    break;
            }
        }
        else
        {
            if (totalObjs < objLimit)
            {
                SpawnObject();
            }
            else
            {

                dartLimitMenu.SetActive(true);
            }
        }
    }
    void OnTriggerUp(byte controller_id, float triggerValue)
    {
        if (holdingDart)
        {
            holdingDart = false;
            if (gravityEnabled) dartRB.useGravity = true;
            dartRB.velocity = forcePerSecond;
        }
    }
    private void GetCount()
    {
        totalObjs = 0;
        foreach (Transform dartObj in dartHolder)
        {
            totalObjs += 1;
        }
        dartLimitText.text = "Dart Limit:\n" + totalObjs + " of 40";
    }
    private void ClearAllObjects()
    {
        foreach (Transform child in dartHolder) GameObject.Destroy(child.gameObject);
        totalObjs = 0;
        spawning = spawnState.none;
        GetCount();
    }
    private void CheckNewUser()
    {
        if (PlayerPrefs.GetInt("hasPlayedDarts") == 1)
        {
            tutorialMenu.SetActive(false);
        }
        else
        {
            mainMenuCanvas.transform.position = mainCam.transform.position + mainCam.transform.forward * 1.5f;
            mainMenuCanvas.transform.LookAt(mainCam.transform.position);
            mainMenu.SetActive(false);
            tutorialMenu.SetActive(true);
            PlayerPrefs.SetInt("hasPlayedDarts", 1);
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
        currentTutorialPage = GameObject.Find("/[CONTENT]/Menu/MainMenuCanvas/Tutorial/" + currentPage);
        currentTutorialPage.SetActive(true);

        tutorialRight.SetActive(true);
        tutorialLeft.SetActive(true);

        switch (currentPage)
        {
            case 0:
                tutorialLeft.SetActive(false);
                break;
            case 3:
                tutorialRight.SetActive(false);
                break;
        }
    }
    private void SpawnObject()
    {
        if (totalObjs < objLimit)
        {
            switch (spawning)
            {
                case spawnState.dart:
                    if (joinedLobby)
                    {
                        dartMultiplayer = Transmission.Spawn("DartMultiplayer", controller.Position, controller.Orientation, Vector3.one);
                    }
                    else
                    {
                        dart = Instantiate(dartPrefab.gameObject, controlObj.transform.position, controlObj.transform.rotation, dartHolder);
                        holdingDart = true;
                    }
                    ConfigureDart();
                    break;
                case spawnState.dartboard:
                    if (joinedLobby) {
                        if (dartboardMultiplayer == null) {
                            dartboardMultiplayer = Transmission.Spawn("DartboardMultiplayer", controlPointer.transform.position, Quaternion.LookRotation(-mainCam.transform.up, -mainCam.transform.forward), Vector3.one);
                        }
                        dartboardMultiplayer.transform.position = controlPointer.transform.position;
                    } else {
                        dartboardHolder.transform.position = dartboardHolder.transform.position;
                    }
                    break;
                default:
                    break;
            }
        }
    }
    private void HoldingDart()
    {
        Vector3 oldPosition;
        if (joinedLobby)
        {
            oldPosition = dartMultiplayer.transform.position;
        }
        else
        {
            oldPosition = dart.transform.position;
        }
        var newPosition = controlObj.transform.position;
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
        forcePerSecond = toAverage * 300;

        if (joinedLobby)
        {
            dartMultiplayer.transform.position = controller.Position;
            dartMultiplayer.transform.rotation = controller.Orientation;
        }
        else
        {
            dart.transform.position = controlObj.transform.position;
            dart.transform.rotation = controlObj.transform.rotation;
        }

    }
    private void ConfigureDart()
    {
        int dartColor = PlayerPrefs.GetInt("dartColorInt");
        if (joinedLobby)
        {
            dartMultiplayer.GetComponentInChildren<MeshRenderer>().material = dartMats[dartColor];
            dartRB = dartMultiplayer.GetComponent<Rigidbody>();
        }
        else
        {
            dart.GetComponentInChildren<MeshRenderer>().material = dartMats[dartColor];
            dartRB = dart.GetComponentInChildren<Rigidbody>();
        }
    }
}