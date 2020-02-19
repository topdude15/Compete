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
    [SerializeField] private GameObject controlPointer, pointerCursor, controlObj;
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
    [SerializeField] private GameObject handMenu, helpMenu, multiplayerConfirmMenu, multiplayerCodeMenu, multiplayerActiveMenu, dartColorMenu;

    // Other elements
    [Header("Extra")]

    [SerializeField] private AudioSource menuAudio;
    [SerializeField] private GameObject mainCam, colorDartObj, transmissionObj, spatialAlignmentObj, meshOriginal;
    [SerializeField] private Transform dartHolder;
    [SerializeField] private Text multiplayerCodeInputText, multiplayerCodeText, noGravityText;
    private GameObject meshObjs, spatialMap, spawnedObj;
    private float clearTimer = 0.0f, helpTimer = 0.0f, menuMoveSpeed;
    private int totalObjs = 0, objLimit = 50;
    private spawnState spawning = spawnState.none;
    private bool allowHelp = true, joinedLobby = true, holdingDart = false, gravityEnabled = true, occlusionActive = true;
    private string roomCode = "";
    private TransmissionObject spawnedObjMultiplayer;
    private List<TransmissionObject> spawnedObjs;
    private Material[] dartMats, meshMats;
    private Rigidbody dartRB;

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

        menuMoveSpeed = Time.deltaTime * 2f;
    }

    void Update()
    {
        // Hand tracking updates each frame
        CheckGestures();

        // Use controlObj to get forward value of Control position
        controlObj.transform.position = controller.Position;
        controlObj.transform.rotation = controller.Orientation;

        // Bring the help menu smoothly in front of the user if it's active
        if (helpMenu.activeSelf)
        {
            Vector3 pos = mainCam.transform.position + mainCam.transform.forward * 1.0f;
            helpMenu.transform.position = Vector3.SlerpUnclamped(helpMenu.transform.position, pos, menuMoveSpeed);

            Quaternion rot = Quaternion.LookRotation(helpMenu.transform.position - mainCam.transform.position);
            helpMenu.transform.rotation = Quaternion.Slerp(helpMenu.transform.rotation, rot, menuMoveSpeed);
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
    private void ClearAllObjects()
    {
        // TODO: Destroy all user-generated content (darts)
    }
    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        // Disable any spawning
        spawning = spawnState.none;
        // Do not allow the help menu to appear
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
                // Dart Color menu buttons
                case "DartColor":
                    mainMenu.SetActive(false);
                    dartColorMenu.SetActive(true);
                    break;
                case "Red0":
                case "Orange1":
                case "Yellow2":
                case "Green3":
                case "Blue4":
                    string colorValue = Regex.Match(objGameHit, @"\d").Value;
                    int colorValueInt = int.Parse(colorValue);
                    PlayerPrefs.SetInt("dartColorInt", colorValueInt);
                    colorDartObj.GetComponent<MeshRenderer>().material = dartMats[colorValueInt];
                    break;
                // Settings menu buttons
                case "NoGravity":
                    if (gravityEnabled)
                    {
                        gravityEnabled = false;
                        noGravityText.text = ("Disable Gravity");
                    }
                    else
                    {
                        gravityEnabled = true;
                        noGravityText.text = ("Enable Gravity");
                    }
                    break;
                case "ShowMesh":
                    if (occlusionActive) {

                    } else {
                        
                    }
                    break;
            }
        }
        else
        {
            SpawnObject();
        }
    }
    void OnTriggerUp(byte controller_id, float triggerValue)
    {
        // TODO: Detect when the user has released the Trigger
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
                        spawnedObjMultiplayer = Transmission.Spawn("DartMultiplayer", controller.Position, controller.Orientation, Vector3.one);
                    }
                    else
                    {
                        spawnedObj = Instantiate((GameObject)Instantiate(Resources.Load("NewDart")), controller.Position, controller.Orientation, dartHolder);
                    }
                    ConfigureDart();
                    break;
                case spawnState.dartboard:
                    break;
                default:
                    break;
            }
        }
    }
    private void ConfigureDart()
    {
        int dartColor = PlayerPrefs.GetInt("dartColorInt");
        MeshRenderer dartMeshRender;
        if (joinedLobby)
        {
            dartMeshRender = spawnedObjMultiplayer.GetComponent<MeshRenderer>();
            dartRB = spawnedObjMultiplayer.GetComponent<Rigidbody>();
        }
        else
        {
            dartMeshRender = spawnedObj.GetComponent<MeshRenderer>();
            dartRB = spawnedObj.GetComponent<Rigidbody>();
        }
        dartMeshRender.material = dartMats[dartColor];
    }
}