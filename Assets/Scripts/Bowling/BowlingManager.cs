#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MagicLeapTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class BowlingManager : MonoBehaviour
{
    private enum spawnState
    {
        none,
        bowlingBall,
        singlePin,
        tenPin
    }
    // Control Input elements
    [Header("Control")]
    [SerializeField] private Pointer pointer;
    [SerializeField] private GameObject controlPointer, pointerCursor, control, controlObj;
    private MLInputController controller;

    // Hand Pose elements
    [Header("Hand Pose")]
    [SerializeField] private Image clearProgressImg;
    [SerializeField] private GameObject handCenter, clearProgress;
    private enum HandPoses { OpenHand, Fist, NoPose };
    private HandPoses pose = HandPoses.NoPose;
    private MLHand currentHand;
    private MLHandKeyPose[] _gestures;

    [Header("Menus")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject handMenu, helpMenu, tutorialMenu, multiplayerConfirmMenu, multiplayerCodeMenu, multiplayerActiveMenu, modifierMenu, pinLimitMenu, ballColorMenu, ballWeightMenu, objMenu, mainMenuCanvas;
    [SerializeField] private GameObject[] tutorialPage;

    [Header("Extra")]
    [SerializeField] private AudioSource menuAudio;
    [SerializeField] private GameObject mainCam, transmissionObj, spatialAlignmentObj, tutorialRight, tutorialLeft, increaseButton, decreaseButton, bowlingBallSelectorObj, ballColorObj;
    [SerializeField] private Transform pinHolder, singlePinPrefab, tenPinPrefab, ballPrefab;
    [SerializeField] private Text multiplayerCodeInputText, multiplayerCodeText, noGravityText, pinLimitText, showMeshText, ballWeightText;
    private GameObject ball, meshObjs, spatialMap, meshOriginal, currentTutorialPage, tenPinObj;
    private GameObject[] tutorialPages;
    private float clearTimer = 0.0f, helpTimer = 0.0f;
    private int totalObjs = 0, objLimit = 100, currentPage = 0;

    private spawnState spawning = spawnState.none;
    private bool holdingBall = false, allowHelp = true, joinedLobby = false, gravityEnabled = true, occlusionActive = true;
    private string roomCode = "";
    private TransmissionObject ballMultiplayer, pinMultiplayer;
    [SerializeField] private Material[] ballMats, meshMats;
    private Rigidbody ballRB;
    private Vector3 forcePerSecond, tenPinOrientation = new Vector3(0, 0, 0);
    List<Vector3> Deltas = new List<Vector3>();
    private List<TransmissionObject> spawnedPins;
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

        int currentWeight = PlayerPrefs.GetInt("ballWeight");
        if (currentWeight > 16 || currentWeight < 6)
        {
            PlayerPrefs.SetInt("ballWeight", 10);
        }
        ballWeightText.text = ("<b>" + PlayerPrefs.GetInt("ballWeight") + " lbs</b>");

        int colorValueInt = PlayerPrefs.GetInt("ballColorInt");
        ballColorObj.GetComponent<MeshRenderer>().material = ballMats[colorValueInt];
        bowlingBallSelectorObj.GetComponent<MeshRenderer>().material = ballMats[colorValueInt];

        currentTutorialPage = GameObject.Find("/[CONTENT]/Menu/MainMenuCanvas/Tutorial/0");
    }
    void Update()
    {
        // Hand tracking updates each frame
        CheckGestures();

        // Use control to get forward value of Control position
        control.transform.position = controller.Position;
        control.transform.rotation = controller.Orientation;

        if (holdingBall)
        {
            HoldingBall();
        }
        // If the user has not interacted with the game at all in 30 seconds, bring up the help menu
        helpTimer += Time.deltaTime;
        if (helpTimer > 30.0f && allowHelp)
        {
            helpMenu.transform.position = mainCam.transform.position + mainCam.transform.forward * 10f;
            helpMenu.SetActive(true);
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
                // ClearAllObjects();
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
        objMenu.SetActive(false);
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
            ballColorMenu.SetActive(false);
            ballWeightMenu.SetActive(false);

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
            ballColorMenu.SetActive(false);
            ballWeightMenu.SetActive(false);
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
                    PlayerPrefs.SetInt("hasPlayedBowling", 0);
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
                case "SinglePinSelector":
                    spawning = spawnState.singlePin;
                    objMenu.SetActive(false);
                    break;
                case "TenPinSelector":
                    spawning = spawnState.tenPin;
                    objMenu.SetActive(false);
                    break;
                case "BowlingBallSelector":
                    spawning = spawnState.bowlingBall;
                    objMenu.SetActive(false);
                    controlPointer.SetActive(false);
                    break;
                case "BallColor":
                    mainMenu.SetActive(false);
                    ballColorMenu.SetActive(true);
                    break;
                case "Red0":
                case "Yellow1":
                case "Orange2":
                case "Blue3":
                case "Green4":
                    string colorValue = Regex.Match(objGameHit, @"\d").Value;
                    int colorValueInt = int.Parse(colorValue);
                    PlayerPrefs.SetInt("ballColorInt", colorValueInt);

                    ballColorObj.GetComponent<MeshRenderer>().material = ballMats[colorValueInt];
                    bowlingBallSelectorObj.GetComponent<MeshRenderer>().material = ballMats[colorValueInt];
                    break;
                case "CloseBallColor":
                    ballColorMenu.SetActive(false);
                    modifierMenu.SetActive(true);
                    break;
                case "BallWeight":
                    modifierMenu.SetActive(false);
                    ballWeightMenu.SetActive(true);
                    break;
                case "CloseBallWeight":
                    ballWeightMenu.SetActive(false);
                    mainMenu.SetActive(true);
                    break;
                case "Increase":
                    UpdateBallWeight(true);
                    break;
                case "Decrease":
                    UpdateBallWeight(false);
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

                pinLimitMenu.SetActive(true);
            }
        }
    }
    void OnTriggerUp(byte controller_id, float triggerValue)
    {
        if (holdingBall)
        {
            holdingBall = false;
            if (gravityEnabled) ballRB.useGravity = true;
            ballRB.velocity = Vector3.zero;
            ballRB.velocity = forcePerSecond;
        }
    }
    private void GetCount()
    {
        totalObjs = 0;
        foreach (Transform pinObj in pinHolder)
        {
            if (pinObj.childCount > 0)
            {
                Transform objectsTotal = pinObj.GetComponentInChildren<Transform>();
                totalObjs += objectsTotal.childCount;
            }
            else
            {
                totalObjs += 1;
            }
        }
        pinLimitText.text = "Pin Limit:\n" + totalObjs + " of 100";
    }
    private void ClearAllObjects()
    {
        foreach (Transform child in pinHolder) GameObject.Destroy(child.gameObject);
        totalObjs = 0;
        spawning = spawnState.none;
        GetCount();
    }
    private void CheckNewUser()
    {
        if (PlayerPrefs.GetInt("hasPlayedBowling") == 1)
        {
            tutorialMenu.SetActive(false);
        }
        else
        {
            mainMenuCanvas.transform.position = mainCam.transform.position + mainCam.transform.forward * 1.5f;
            mainMenuCanvas.transform.LookAt(mainCam.transform.position);
            mainMenu.SetActive(false);
            tutorialMenu.SetActive(true);
            PlayerPrefs.SetInt("hasPlayedBowling", 1);
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
                case spawnState.bowlingBall:
                    if (joinedLobby && ballMultiplayer == null) ballMultiplayer = Transmission.Spawn("BallMultiplayer", controller.Position, controller.Orientation, Vector3.one);
                    if (ball == null) ball = Instantiate(ballPrefab.gameObject, controller.Position, controller.Orientation);
                    holdingBall = true;
                    ConfigureBall();
                    break;
                case spawnState.singlePin:
                    if (joinedLobby)
                    {
                        pinMultiplayer = Transmission.Spawn("SingleMultiplayer", new Vector3(pointerCursor.transform.position.x, pointerCursor.transform.position.y + 0.1f, pointerCursor.transform.position.z), new Quaternion(0, 0, 0, 0), new Vector3(1.4f, 1.2f, 1.4f));
                        spawnedPins.Add(pinMultiplayer);
                        GetCount();
                    }
                    else
                    {
                        Instantiate(singlePinPrefab, new Vector3(pointerCursor.transform.position.x, pointerCursor.transform.position.y + 0.1f, pointerCursor.transform.position.z), new Quaternion(0, 0, 0, 0), pinHolder);
                    }
                    break;
                case spawnState.tenPin:
                    if (joinedLobby)
                    {
                        pinMultiplayer = Transmission.Spawn("TenPinMultiplayer", new Vector3(pointerCursor.transform.position.x, pointerCursor.transform.position.y + 0.1f, pointerCursor.transform.position.z), Quaternion.Euler(tenPinOrientation), Vector3.one);
                        spawnedPins.Add(pinMultiplayer);
                        GetCount();
                    }
                    else
                    {
                        // tenPinObj = Instantiate(tenPinPrefab, pointerCursor.transform.position, Quaternion.Euler(new Vector3(0,0,0), pinHolder));
                        // Vector3 targetPos = new Vector3(mainCam.transform.position.x, tenPinObj.transform.position.y, mainCam.transform.position.z);
                        // tenPinObj.LookAt(targetPos);
                    }
                    break;
                default:
                    break;
            }
        }
    }
    private void HoldingBall()
    {
        Vector3 oldPosition;
        if (joinedLobby)
        {
            oldPosition = ballMultiplayer.transform.position;
        }
        else
        {
            oldPosition = ball.transform.position;
        }
        ballRB.velocity = Vector3.zero;

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

        int currentWeight = PlayerPrefs.GetInt("ballWeight");
        forcePerSecond = toAverage * (950 / currentWeight);

        if (joinedLobby)
        {
            ballMultiplayer.transform.position = controller.Position;
            ballMultiplayer.transform.rotation = controller.Orientation;
        }
        else
        {
            ball.transform.position = controlObj.transform.position;
            ball.transform.rotation = controlObj.transform.rotation;
        }

    }
    private void ConfigureBall()
    {
        int ballColor = PlayerPrefs.GetInt("ballColorInt");
        if (joinedLobby)
        {
            ballMultiplayer.GetComponent<MeshRenderer>().material = ballMats[ballColor];
            ballRB = ballMultiplayer.GetComponent<Rigidbody>();
        }
        else
        {
            ball.GetComponent<MeshRenderer>().material = ballMats[ballColor];
            ballRB = ball.GetComponentInChildren<Rigidbody>();
        }
    }
    private void UpdateBallWeight(bool increase)
    {
        int currentWeight = PlayerPrefs.GetInt("ballWeight");
        if (increase)
        {
            if (currentWeight >= 6 && currentWeight < 16)
            {
                currentWeight += 1;
            }
        }
        else
        {
            if (currentWeight <= 16 && currentWeight > 6)
            {
                currentWeight -= 1;
            }
        }
        increaseButton.SetActive(true);
        decreaseButton.SetActive(true);
        if (currentWeight == 6) decreaseButton.SetActive(false);
        if (currentWeight == 16) increaseButton.SetActive(false);
        PlayerPrefs.SetInt("ballWeight", currentWeight);
        ballWeightText.text = ("<b>" + currentWeight + " lbs</b>");
    }
}