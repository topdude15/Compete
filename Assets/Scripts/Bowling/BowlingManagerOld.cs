#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using UnityEngine.XR;
using MagicLeapTools;

public class BowlingManagerOld : MonoBehaviour
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
    private enum spawnState
    {
        none,
        ball,
        ballMultiplayer,
        single,
        singleMultiplayer,
        tenPin,
        tenPinMultiplayer,
    }

    // Controller Input
    [SerializeField] private Pointer pointer;
    [SerializeField] private GameObject controlPointer, pointerCursor;
    private MLInputController controller;

    // Hand Input
    private enum HandPoses { OpenHand, Fist, NoPose };
    private HandPoses pose = HandPoses.NoPose;
    private MLHand currentHand;
    private Vector3[] pos;
    private MLHandKeyPose[] _gestures;

    private holdState holding = holdState.single;
    private spawnState spawning = spawnState.none;

    private Rigidbody ballRB;
    private MeshRenderer ballRenderer;

    [SerializeField] private GameObject mainCam, controlCube, deleteLoader, menuCanvas, handCenter, reachedPinLimit, swapHandButton, tutorialLeft, tutorialRight, tutorialLeftText, tutorialRightText, track, pinPlacement, startPoint, endPoint, transmissionObj, spatialAlignmentObj;

    [SerializeField] private GameObject menu, ballMenu, modifierMenu, tutorialMenu, multiplayerMenu, multiplayerConfirmMenu, helpMenu, tutorialHelpMenu, pinLimitMenu, multiplayerStatusMenu, handMenu, objMenu;
    [SerializeField] private GameObject[] tutorialPage;

    [SerializeField] private Text pinLimitText, multiplayerCodeText, multiplayerStatusText, multiplayerMenuCodeText, pinsFallenText, noGravityText, gestureHandText;

    private GameObject pinObj, pin, currentTutorialPage;
    public Material[] ballMats, meshMats;

    public Transform singlePrefab, tenPinPrefab, pinHolder, singleNoGravityPrefab, tenPinNoGravityPrefab, meshHolder;

    private Transform tenPinObj;

    private GameObject ball, mesh;
    private TransmissionObject ballMultiplayer;
    public List<TransmissionObject> spawnedPins;

    private Vector3 endPosition, forcePerSecond, trackStartPosition, trackEndPosition;

    List<Vector3> Deltas = new List<Vector3>();
    private int currentPage = 0, totalObjs = 0, objLimit = 100;
    private float timer = 0.0f, waitTime = 30.0f, menuMoveSpeed, deleteTimer = 0.0f;

    public int pinsFallen = 0;

    private string roomCode = "";

    public Image loadingImage;

    private TransmissionObject spawnedObj;

    [SerializeField] private Texture2D handLeft, handRight;

    private bool holdingBall = false, noGravity = false, occlusionActive = true, joinedLobby = false, helpAppeared = false, networkConnected, pinLimitAppeared = false, leftHand = true, setLocationPos = false, multiplayerBall = false;


    private Vector3 pinOrientation = new Vector3(-90, 0, 90), tenPinOrientation = new Vector3(0, 0, 0);
    // AUDIO VARIABLES

    public AudioSource menuAudio;

    // Use this for initialization
    void Start()
    {

        MLInput.Start();
        // If the user is new, open the tutorial menu
        CheckNewUser();

        // mesh = GameObject.Find("/MLSpatialMapper/Original").GetComponent<MeshRenderer>();

        // Get input from the Control, accessible via controller
        controller = MLInput.GetController(0);
        // When the Control's button(s) are pressed, run OnButtonDown
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnTriggerDown += OnTriggerDown;
        MLInput.OnTriggerUp += OnTriggerUp;
        MLInput.TriggerDownThreshold = 0.75f;
        MLInput.TriggerUpThreshold = 0.2f;

        MLHands.Start();
        _gestures = new MLHandKeyPose[2];
        _gestures[0] = MLHandKeyPose.OpenHand;
        _gestures[1] = MLHandKeyPose.Fist;
        MLHands.KeyPoseManager.EnableKeyPoses(_gestures, true, false);
        pos = new Vector3[1];

        menuMoveSpeed = Time.deltaTime * 2f;

        MLNetworking.IsInternetConnected(ref networkConnected);
        if (networkConnected == false)
        {
            multiplayerStatusText.text = ("<b>Multiplayer Status:</b>\n" + "<color='red'>No Internet</color>");
        }
        if (PlayerPrefs.GetString("gestureHand") == "right")
        {
            gestureHandText.text = ("Gestures:\nRight Hand");
            swapHandButton.GetComponent<MeshRenderer>().material.mainTexture = handRight;
            currentHand = MLHands.Right;
        }
        else
        {
            PlayerPrefs.SetString("gestureHand", "left");
            currentHand = MLHands.Left;
        }

        currentTutorialPage = GameObject.Find("/[CONTENT]/Menu/Canvas/Tutorial/0");

        mesh = GameObject.Find("MeshObjects");
        print(mesh.transform.name);
    }
    private void OnDisable()
    {
        MLInput.Stop();
        MLHands.Stop();
        MLInput.OnControllerButtonDown -= OnButtonDown;
    }

    private void OnEnable()
    {
        // MLInput.Start();
        // MLHands.Start();
        // MLNetworking.IsInternetConnected(ref networkConnected);
        // if (networkConnected == false)
        // {
        //     multiplayerStatusText.text = ("<b>Multiplayer Status:</b>\n" + "<color='red'>No Internet</color>");
        // }
        // else
        // {
        //     multiplayerStatusText.text = ("<b>Multiplayer Status:</b>\n" + "<color='red'>Not Connected</color>");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        CheckGestures();

        if (timer < waitTime)
        {
            PlayTimer();
        }

        if (holdingBall)
        {
            HoldingBall();
        }

        // Always keep the control GameObject at the Control's position
        controlCube.transform.position = controller.Position;
        controlCube.transform.rotation = controller.Orientation;

        Vector3 pos = mainCam.transform.position + mainCam.transform.forward * 1.0f;
        helpMenu.transform.position = Vector3.SlerpUnclamped(helpMenu.transform.position, pos, menuMoveSpeed);

        Quaternion rot = Quaternion.LookRotation(helpMenu.transform.position - mainCam.transform.position);
        helpMenu.transform.rotation = Quaternion.Slerp(helpMenu.transform.rotation, rot, menuMoveSpeed);
    }
    private void CheckGestures()
    {
        if (GetUserGesture.GetGesture(currentHand, MLHandKeyPose.OpenHand))
        {
            if (pinLimitMenu.activeSelf)
            {
                pinLimitMenu.SetActive(false);
            }
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
            deleteLoader.SetActive(false);
        }

        if (pose != HandPoses.NoPose) ShowPoints();
        if (pose != HandPoses.Fist) handMenu.SetActive(true);
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
                        spawnedObj = Transmission.Spawn("SingleMultiplayer", new Vector3(pointerCursor.transform.position.x, pointerCursor.transform.position.y + 0.1f, pointerCursor.transform.position.z), new Quaternion(0, 0, 0, 0), new Vector3(1.4f, 1.2f, 1.4f));
                        spawnedPins.Add(spawnedObj);
                        GetCount();
                    }
                    else
                    {
                        Instantiate(singlePrefab, new Vector3(pointerCursor.transform.position.x, pointerCursor.transform.position.y + 0.1f, pointerCursor.transform.position.z), new Quaternion(0, 0, 0, 0), pinHolder);
                    }
                }
                else if (holding == holdState.tenPin)
                {
                    if (totalObjs <= objLimit - 10)
                    {
                        if (joinedLobby)
                        {
                            spawnedObj = Transmission.Spawn("TenPinMultiplayer", pointerCursor.transform.position, Quaternion.Euler(tenPinOrientation), Vector3.one);
                            spawnedPins.Add(spawnedObj);
                            GetCount();
                        }
                        else
                        {
                            tenPinObj = Instantiate(tenPinPrefab, pointerCursor.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)), pinHolder);
                            Vector3 targetPos = new Vector3(mainCam.transform.position.x, tenPinObj.transform.position.y, mainCam.transform.position.z);
                            tenPinObj.LookAt(targetPos);
                        }
                    }

                }
                else if (holding == holdState.ball)
                {
                    if (joinedLobby)
                    {
                        if (!multiplayerBall)
                        {
                            multiplayerBall = true;
                        }
                        Rigidbody ballRB = ballMultiplayer.GetComponent<Rigidbody>();
                        ballRB.useGravity = false;
                    }
                    else
                    {
                        Rigidbody ballRB = ball.GetComponent<Rigidbody>();
                        ballRB.useGravity = false;
                    }
                }
            }
            else if (noGravity)
            {
                if (holding == holdState.single)
                {
                    if (joinedLobby)
                    {
                        spawnedObj = Transmission.Spawn("SingleMultiplayerNoGravity", pointerCursor.transform.position, Quaternion.Euler(pinOrientation), Vector3.one);
                        spawnedPins.Add(spawnedObj);
                        GetCount();
                    }
                    else
                    {
                        Instantiate(singleNoGravityPrefab, pointerCursor.transform.position, Quaternion.Euler(pinOrientation), pinHolder);
                    }
                }
                else if (holding == holdState.tenPin)
                {
                    if (joinedLobby)
                    {
                        spawnedObj = Transmission.Spawn("TenPinMultiplayerNoGravity", pointerCursor.transform.position, Quaternion.Euler(tenPinOrientation), Vector3.one);
                        spawnedPins.Add(spawnedObj);
                        GetCount();
                    }
                    else
                    {
                        Instantiate(tenPinNoGravityPrefab, pointerCursor.transform.position, Quaternion.Euler(tenPinOrientation), pinHolder);
                    }
                }
                else if (holding == holdState.ball)
                {
                    Rigidbody ballRB = ball.GetComponent<Rigidbody>();
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
        Rigidbody ballRB;
        // Stop the ball moving on its own while holding
        if (joinedLobby)
        {
            ballRB = ballMultiplayer.GetComponent<Rigidbody>();
        }
        else
        {
            ballRB = ball.GetComponent<Rigidbody>();
        }
        ballRB.velocity = Vector3.zero;

        // Reset the bowling ball and then get the bowling ball's previous and current position
        // bowlingBall.transform.rotation = Quaternion.identity;
        Vector3 oldPosition;
        if (joinedLobby)
        {
            oldPosition = ballMultiplayer.transform.position;
        }
        else
        {
            oldPosition = ball.transform.position;
        }
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
        var forcePerSecondAvg = toAverage * 50000;
        forcePerSecond = forcePerSecondAvg;
        if (joinedLobby)
        {
            ballMultiplayer.transform.position = controller.Position;
        }
        else
        {
            ball.transform.position = controller.Position;
        }
    }

    public void GetCount()
    {
        totalObjs = 0;
        if (joinedLobby)
        {
            if (spawnedPins.Count > 0)
            {
                foreach (TransmissionObject bowlObj in spawnedPins)
                {
                    if (bowlObj.name == "TenPinMultiplayer(Clone)")
                    {
                        totalObjs += 10;
                    }
                    else
                    {
                        totalObjs += 1;
                    }
                }
            }
        }
        else
        {
            foreach (Transform bowlObj in pinHolder)
            {
                if (bowlObj.childCount > 0)
                {
                    Transform objectstotal = bowlObj.GetComponentInChildren<Transform>();
                    totalObjs += objectstotal.childCount;
                }
                else
                {
                    totalObjs += 1;
                }
            }
        }
        pinLimitText.text = "<b>Pin Limit:</b>\n " + totalObjs + " of 100";
        pinsFallenText.text = ("<b>Pins Fallen:</b>\n" + pinsFallen + " of " + totalObjs);
    }

    private void ClearAllObjects()
    {
        if (joinedLobby)
        {
            if (spawnedPins.Count > 0)
            {
                foreach (TransmissionObject bowlObj in spawnedPins)
                {
                    Transmission.Destroy(bowlObj);
                }
            }
        }
        foreach (Transform child in pinHolder.transform)
        {
            if (child.GetComponent("TransmissionObject") != null)
            {
                Transmission.Destroy(child.gameObject);
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
        print("Controller button detected");

        controlPointer.SetActive(true);
        currentPage = 1;
        SetTutorialPage(false);

        if (tutorialMenu.activeSelf)
        {
            tutorialMenu.SetActive(false);
            PlayerPrefs.SetInt("hasPlayedBowling", 1);
        }
        if (pinLimitMenu.activeSelf)
        {
            pinLimitMenu.SetActive(false);
        }

        if (button == MLInputControllerButton.Bumper)
        {
            tutorialMenu.SetActive(false);
            multiplayerStatusMenu.SetActive(false);
            multiplayerConfirmMenu.SetActive(false);
            multiplayerMenu.SetActive(false);
            modifierMenu.SetActive(false);
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
            }
            else
            {

                Transmission.Spawn("10PinLowPoly", pinPlacement.transform.position, pinPlacement.transform.rotation, Vector3.one);

                holding = holdState.none;
            }
        }
        else if (holding == holdState.locationPoint)
        {
            if (setLocationPos)
            {
                holding = holdState.none;
            }
            else
            {
                InputTracking.Recenter();
                setLocationPos = true;
            }
        }

        SpawnObject();

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
            case "Multiplayer":
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
            case "BallColor":
                ballMenu.transform.position = mainCam.transform.position + (mainCam.transform.forward * 1.5f);
                ballMenu.transform.LookAt(mainCam.transform.position);
                ballMenu.SetActive(true);
                menu.SetActive(false);
                menuAudio.Play();
                break;
            case "Settings":
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
            case "LeaveRoom":
                joinedLobby = false;

                spatialAlignmentObj.SetActive(false);
                transmissionObj.SetActive(false);

                roomCode = "";
                multiplayerCodeText.text = "Please enter a code";
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
                    foreach (Transform child in mesh.transform)
                    {
                        var objectRender = child.GetComponent<MeshRenderer>();
                        foreach (Transform meshChild in mesh.transform)
                        {
                            meshChild.GetComponent<MeshRenderer>().material = meshMats[1];
                        }
                    }
                    // mesh.material = meshMats[1];
                    occlusionActive = false;
                }
                else
                {
                    foreach (Transform meshChild in mesh.transform)
                    {
                        meshChild.GetComponent<MeshRenderer>().material = meshMats[0];
                    }
                    //mesh.material = meshMats[0];
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
                    gestureHandText.text = ("Gestures:\nRight Hand");
                    currentHand = MLHands.Right;

                }
                else
                {
                    PlayerPrefs.SetString("gestureHand", "left");
                    swapHandButton.GetComponent<MeshRenderer>().material.mainTexture = handLeft;
                    gestureHandText.text = ("Gestures:\nLeft Hand");
                    currentHand = MLHands.Left;
                }
                break;
            case "SinglePinSelector":
                objMenu.SetActive(false);
                if (joinedLobby)
                {
                    spawning = spawnState.singleMultiplayer;
                }
                else
                {
                    spawning = spawnState.single;
                }
                holding = holdState.single;
                break;
            case "BowlingBallSelector":
                controlPointer.SetActive(false);
                if (joinedLobby)
                {
                    if (ballMultiplayer == null)
                    {
                        ballMultiplayer = Transmission.Spawn("BowlingBallMultiplayer", controller.Position, controller.Orientation, new Vector3(0.1f, 0.1f, 0.1f));
                    }
                }
                else
                {
                    if (ball == null)
                    {
                        // Spawn the ball away from the player and set the correct color
                        ball = Instantiate((GameObject)Resources.Load("BowlingBall"), new Vector3(15, 15, 15), Quaternion.Euler(tenPinOrientation));
                        ConfigureBall();
                    }
                }
                objMenu.SetActive(false);
                holding = holdState.ball;
                break;
            case "TenPinSelector":
                objMenu.SetActive(false);
                if (joinedLobby)
                {
                    spawning = spawnState.tenPinMultiplayer;
                }
                else
                {
                    spawning = spawnState.tenPin;
                }
                holding = holdState.tenPin;
                break;
            case "Red":
                PlayerPrefs.SetInt("ballColorInt", 0);
                ballRenderer.material = ballMats[0];
                ballMenu.SetActive(false);
                break;
            case "Orange":
                PlayerPrefs.SetInt("ballColorInt", 1);
                ballRenderer.material = ballMats[1];
                ballMenu.SetActive(false);
                break;
            case "Yellow":
                PlayerPrefs.SetInt("ballColorInt", 2);
                ballRenderer.material = ballMats[2];
                ballMenu.SetActive(false);
                break;
            case "Green":
                PlayerPrefs.SetInt("ballColorInt", 3);
                ballRenderer.material = ballMats[3];
                ballMenu.SetActive(false);
                break;
            case "Blue":
                PlayerPrefs.SetInt("ballColorInt", 4);
                ballRenderer.material = ballMats[4];
                ballMenu.SetActive(false);
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
                // MLNetworking.IsInternetConnected(ref networkConnected);
                // if (networkConnected == false)
                // {
                //     multiplayerCodeText.text = ("<color='red'>No Internet</color>");
                // }
                // else
                // {
                multiplayerCodeText.color = Color.white;
                if (roomCode.Length < 18)
                {
                    roomCode += objGameHit;
                    multiplayerCodeText.text = roomCode;
                    menuAudio.Play();
                }
                break;
            case "Delete":
                if (roomCode.Length > 0)
                {
                    roomCode = roomCode.Substring(0, roomCode.Length - 1);
                    multiplayerCodeText.text = roomCode;
                }
                break;
            case "Join":
                ClearAllObjects();
                if (!joinedLobby)
                {
                    multiplayerCodeText.color = Color.white;
                    if (roomCode.Length < 1)
                    {
                        multiplayerCodeText.text = "Please enter a code";
                    }
                    else
                    {
                        print("Joining lobby");

                        joinedLobby = true;

                        spatialAlignmentObj.SetActive(true);
                        transmissionObj.SetActive(true);
                        transmissionObj.GetComponent<Transmission>().privateKey = roomCode;

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
                roomCode = "Code";
                menuAudio.Play();
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
            Rigidbody ballRB;
            if (joinedLobby)
            {
                ballRB = ballMultiplayer.GetComponent<Rigidbody>();
            }
            else
            {
                ballRB = ball.GetComponent<Rigidbody>();
            }
            // Enable the rigidbody on the ball, then apply current forces to the ball
            ballRB.useGravity = true;
            ballRB.velocity = Vector3.zero;
            ballRB.AddForce(forcePerSecond);
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
    private void SetBallColor(int colorChoice)
    {
        // Set PlayerPref to save ball color over sessions 
        PlayerPrefs.SetInt("ballColorInt", colorChoice);
        ballMenu.SetActive(false);
    }
    private void ConfigureBall()
    {
        // Get the saved ball color
        int ballColor = PlayerPrefs.GetInt("ballColorInt");
        // Set global variables for ball MeshRenderer and Rigidbody for later access
        if (joinedLobby)
        {
            ballRenderer = ballMultiplayer.GetComponent<MeshRenderer>();
            ballRB = ballMultiplayer.GetComponent<Rigidbody>();
        }
        else
        {
            ballRenderer = ball.GetComponent<MeshRenderer>();
            ballRB = ball.GetComponent<Rigidbody>();
        }
        // Set ball color and disble ball gravity
        ballRenderer.material = ballMats[ballColor];
        ballRB.useGravity = false;
    }
    public void AnnounceNew()
    {
        print("Player connected...");
    }
}