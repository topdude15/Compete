using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.SceneManagement;

public class MeshingMenu : MonoBehaviour {

	// private MLInputController controller;
	public GameObject _cam, menu;
	private MLInputController controller;

	// Use this for initialization
	void Start () {
		print("yee");
		MLInput.Start();
		
		controller = MLInput.GetController(MLInput.Hand.Left);

		// MLInput.OnControllerButtonDown += OnButtonDown;

		menu.transform.position = _cam.transform.position + _cam.transform.forward * 2.5f;
		menu.transform.rotation = _cam.transform.rotation;
	}

	private void OnDestroy() {
		// Stop Magic Leap controller input
		MLInput.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		float speed = Time.deltaTime * 1f;

		Vector3 pos = _cam.transform.position + _cam.transform.forward * 1.0f;
		menu.transform.position = Vector3.SlerpUnclamped (menu.transform.position, pos, speed);

		Quaternion rot = Quaternion.LookRotation (menu.transform.position - _cam.transform.position);
		menu.transform.rotation = Quaternion.Slerp (menu.transform.rotation, rot, speed);

		if (controller.TriggerValue >= 0.9f) {
			SceneManager.LoadScene("Main", LoadSceneMode.Single);
		}
	}
	// void OnButtonDown(byte controller_id, MLInputControllerButton button) {
	// 	print("yeet");
	// 	if (button == MLInputControllerButton.HomeTap) {
	// 		SceneManager.LoadScene("Main", LoadSceneMode.Single);
	// 	}
	// }
}
