using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.SceneManagement;

public class MeshingMenu : MonoBehaviour {

	// private MLInputController controller;
	public GameObject _cam, menu, welcomeMenu, meshingMenu, meshObj;
	private MLInputController controller;
	private float timer;
	private CanvasGroup welcomeCanvas;
	public Material[] meshMats;
	private bool getTime = false, setMenu = false;
	public MeshRenderer mesh;
	// Use this for initialization
	void Start () {
        
		print("yee");
		MLInput.Start();
		
		controller = MLInput.GetController(MLInput.Hand.Left);

		// MLInput.OnControllerButtonDown += OnButtonDown;

		menu.transform.position = _cam.transform.position + _cam.transform.forward * 1.5f;
		menu.transform.rotation = _cam.transform.rotation;

		welcomeCanvas = welcomeMenu.GetComponent<CanvasGroup>();
	}

	private void OnDestroy() {
		// Stop Magic Leap controller input
		MLInput.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//print(timer);

		if (welcomeCanvas.alpha < 1 && getTime == false) {
			welcomeCanvas.alpha += 0.3f * Time.deltaTime;
		} else if (welcomeCanvas.alpha >= 1) {
			if (getTime == false) {
				print("timer yeet");
				getTime = true;
				timer = 0.0f;
			} else {
				// if (timer > 5.0f) {
				// 	print(timer);
				// 	welcomeCanvas.alpha -= 0.3f * Time.deltaTime;
				// }
			}
		}

		if (getTime && welcomeCanvas.alpha >= 0) {
			if (timer > 5.0f) {
				welcomeCanvas.alpha -= 0.3f * Time.deltaTime;
			}
		}

		if (getTime && welcomeCanvas.alpha <= 0) {
			if (setMenu == false) {
				setMenu = true;
                meshObj.SetActive(true);
				meshingMenu.SetActive(true);
				welcomeMenu.SetActive(false);
				menu.transform.position = _cam.transform.position + _cam.transform.forward * 2.5f;
				menu.transform.rotation = _cam.transform.rotation;
			}
		}

		float speed = Time.deltaTime * 1.5f;

		Vector3 pos = _cam.transform.position + _cam.transform.forward * 1.0f;
		menu.transform.position = Vector3.SlerpUnclamped (menu.transform.position, pos, speed);

		Quaternion rot = Quaternion.LookRotation (menu.transform.position - _cam.transform.position);
		menu.transform.rotation = Quaternion.Slerp (menu.transform.rotation, rot, speed);

		if (controller.TriggerValue >= 0.9f) {
			SceneManager.LoadScene("Main", LoadSceneMode.Single);
		}
	}
}
