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
    [SerializeField] private GameObject handMenu, helpMenu;

    // Other elements
    [Header("Extra")]
    [SerializeField] private GameObject mainCam;

    private float clearTimer = 0.0f, menuMoveSpeed;

    void Start()
    {
        MLInput.Start();

        // Start MLHands and start recognizing the OpenHand and Fist poses
        MLHands.Start();
        _gestures = new MLHandKeyPose[2];
        _gestures[0] = MLHandKeyPose.OpenHand;
        _gestures[1] = MLHandKeyPose.Fist;
        MLHands.KeyPoseManager.EnableKeyPoses(_gestures, true, false);

        if (PlayerPrefs.GetString("gestureHand") == "right")
        {
            currentHand = MLHands.Right;
        }
        else
        {
            PlayerPrefs.SetString("gestureHand", "left");
            currentHand = MLHands.Left;
        }

        menuMoveSpeed = Time.deltaTime * 2f;
    }

    void Update()
    {
        CheckGestures();

        controlObj.transform.position = controller.Position;
        controlObj.transform.rotation = controller.Orientation;

        if (helpMenu.activeSelf)
        {
            Vector3 pos = mainCam.transform.position + mainCam.transform.forward * 1.0f;
            helpMenu.transform.position = Vector3.SlerpUnclamped(helpMenu.transform.position, pos, menuMoveSpeed);

            Quaternion rot = Quaternion.LookRotation(helpMenu.transform.position - mainCam.transform.position);
            helpMenu.transform.rotation = Quaternion.Slerp(helpMenu.transform.rotation, rot, menuMoveSpeed);
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
            clearProgress.SetActive(false);
            handCenter.SetActive(false);
        }
        if (pose != HandPoses.NoPose) ShowPoints();
        if (pose != HandPoses.Fist) handMenu.SetActive(true);
    }
    private void ShowPoints()
    {
        // Set handCenter to current hand center to show content
        handCenter.SetActive(true);
        handCenter.transform.position = currentHand.Middle.KeyPoints[0].Position;
        handCenter.transform.LookAt(mainCam.transform.position);
        // Functions for each hand pose
        if (pose == HandPoses.Fist)
        {
            handMenu.SetActive(false);
            clearProgress.SetActive(true);

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

    }
}