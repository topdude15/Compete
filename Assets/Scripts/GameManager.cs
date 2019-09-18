using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.MagicLeap;
public class GameManager : MonoBehaviour {

	private MLInputController controller;
	public LineRenderer laserLineRenderer;
	public GameObject control, mainMenu, privacyPolicyMenu, joinLobby, exitLobby, quitMenu, mainCam;
	private bool pressedExit = false, allowUpdate = true, pressedContinue = false;
	private PrivilegeRequester _privilegeRequester;
	// Use this for initialization

	void Awake() {
        /* TODO: REIMPLEMENT PRIVILEDGE REQUESTER WHEN READDING MULTIPLAYER FUNCTIONALITY
		ALSO MAKE SURE TO REATTACH "PrivilegeRequester" ML SCRIPT TO CAMERA
        _privilegeRequester = GetComponent<PrivilegeRequester>();
        if (_privilegeRequester == null)
            {
                // Handle if the Privilege Requester is missing from the scene
            }
        // Could have also been set via the editor. 
        _privilegeRequester.Privileges = new[] { 
            MLRuntimeRequestPrivilegeId.AudioCaptureMic
        };
        _privilegeRequester.OnPrivilegesDone += HandlePrivilegesDone;
        */
    } 
	void Start () {
		// Start Magic Leap controller input
		MLInput.Start();
		controller = MLInput.GetController(MLInput.Hand.Left);

		// Get the "Controller" GameObject to track bumper hold timer and other controller values
		control = GameObject.Find("Controller");

		// Initialize both line points at Vector3.Zero
		Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
		laserLineRenderer.SetPositions(initLaserPositions);

    }
	private void OnDestroy() {
		// Stop Magic Leap controller input
		MLInput.Stop();
		if (_privilegeRequester != null) {         
            _privilegeRequester.OnPrivilegesDone -= HandlePrivilegesDone;
        }
    }
	
	private void OnDisable() {
		MLInput.Stop();
	}
	private void OnApplicationPause(bool pause) {
		print("Quitting");
		MLInput.Stop();
		SceneManager.UnloadSceneAsync("Main");
	}
	
	// Update is called once per frame
	void Update () {
		if (allowUpdate) {
			// Always set the control GameObject's position to the controller's position in order to maintain tracking accuracy
			control.transform.position = controller.Position;
			control.transform.rotation = controller.Orientation;

			// In the main scene, SetLine is always called because there will be no other selected options
			SetLine();

			if (controller.TriggerValue < 0.2f && pressedContinue) {
				pressedContinue = false;
			}
		}
	}

	void HandlePrivilegesDone(MLResult result) {
        if (!result.IsOk) {
            // Handle if Privileges are not granted
        }
		// Requested priviledges have been granted
     } 
	private void SetLine() {
		// Initialize variables for use 
		RaycastHit rayHit;
		Vector3 heading = control.transform.forward;

		// Set the origin of the line to the controller's position.  Occurs every frame
		laserLineRenderer.SetPosition(0, controller.Position);

		if (Physics.Raycast (controller.Position, heading, out rayHit, 10.0f)) {
			// If the ray hits an object, set the line's end position to the distance between the controller and that point
			Vector3 endPosition = controller.Position + (control.transform.forward * rayHit.distance);
			laserLineRenderer.SetPosition(1, endPosition);

			if (rayHit.collider.name == "BowlingPin" && controller.TriggerValue >= 0.9f) {
				// If the bowling pin is being pointed at and the trigger is held, load the bowling scene
				SceneManager.LoadScene("Bowling", LoadSceneMode.Single);
                //SceneManager.UnloadSceneAsync("Main");
			} else if (rayHit.collider.name == "Dartboard" && controller.TriggerValue >= 0.9f) {
				// If the dartboard is being pointed at and the trigger is held, load the darts scene
				if (!pressedContinue) {
					SceneManager.LoadScene("Darts", LoadSceneMode.Single);
				}
               // SceneManager.UnloadSceneAsync("Main");
            }  else if (rayHit.collider.name == "Golf" && controller.TriggerValue >= 0.9f) {
				SceneManager.LoadScene("Golf", LoadSceneMode.Single);
			} else if (rayHit.collider.name == "PrivacyPolicy" && controller.TriggerValue >= 0.9f) {
				mainMenu.SetActive(false);
				privacyPolicyMenu.SetActive(true);
			} else if (rayHit.collider.name == "ClosePrivacyPolicy" && controller.TriggerValue >= 0.9f) {
				mainMenu.SetActive(true);
				privacyPolicyMenu.SetActive(false);
			} else if (rayHit.collider.name == "ExitGame" && controller.TriggerValue >= 0.9f) {
				//Application.Quit();
				pressedExit = true;
				quitMenu.SetActive(true);
				mainMenu.SetActive(false);
			} else if (rayHit.collider.name == "JoinLobby" && controller.TriggerValue >= 0.9f) {
				//PhotonLobby.OnBattleButtonClicked();
			} else if (rayHit.collider.name == "ExitLobby" && controller.TriggerValue >= 0.9f) {
				//PhotonLobby.OnCancelButtonClicked();
			} else if ((rayHit.collider.name == "ConfirmExit" || rayHit.collider.name == "LeaveGame") && controller.TriggerValue >= 0.9f) {
				if (pressedExit == false) {
					print("Stopping Input services and quitting application");
					allowUpdate = false;
					//MLInput.Stop();
					Application.Quit();
				}
			} else if ((rayHit.collider.name == "StayInGame" || rayHit.collider.name == "ContinuePlaying") && controller.TriggerValue >= 0.9f) {
				if (pressedExit == false) {
					pressedContinue = true;
					quitMenu.SetActive(false);
					mainMenu.SetActive(true);
				}
			} else if (pressedExit == true && controller.TriggerValue <= 0.2f) {
				pressedExit = false;
			}
		} else {
			// If no object is hit, make the length of the line 3 meters out from the controller
			Vector3 endPosition = controller.Position + (control.transform.forward * 3.0f);
			laserLineRenderer.SetPosition(1, endPosition);
		}
	}
    //private void CenterCam()
    //{
    //    while (!tutorialMenuOpened)
    //    {
    //        float speed = Time.deltaTime * 5f;

    //        Vector3 pos = mainCam.transform.position + mainCam.transform.forward * 1.0f;
    //        menu.transform.position = Vector3.SlerpUnclamped(menu.transform.position, pos, speed);

    //        Quaternion rot = Quaternion.LookRotation(menu.transform.position - mainCam.transform.position);
    //        menu.transform.rotation = Quaternion.Slerp(menu.transform.rotation, rot, speed);
    //    }
    //}

}
