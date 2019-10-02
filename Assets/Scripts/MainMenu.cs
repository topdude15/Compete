using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private GameObject _cam;
	private GameObject menu;

	// Use this for initialization
	void Start () {
		_cam = GameObject.Find ("/Main Camera");
		menu = GameObject.Find ("/Menu");
		menu.transform.position = _cam.transform.position + _cam.transform.forward * 1.0f;
		menu.transform.rotation = _cam.transform.rotation;
		StartCoroutine(SetMenu());
	}
	IEnumerator SetMenu()
    {
        yield return new WaitForSeconds(0.001f);
		menu.transform.position = _cam.transform.position + _cam.transform.forward * 1.0f;
		menu.transform.LookAt(_cam.transform.position);
    }

	// Update is called once per frame
	void Update () {
		// float speed = Time.deltaTime * 5f;

		// Vector3 pos = _cam.transform.position + _cam.transform.forward * 1.0f;
		// menu.transform.position = Vector3.SlerpUnclamped (menu.transform.position, pos, speed);

		// Quaternion rot = Quaternion.LookRotation (menu.transform.position - _cam.transform.position);
		// menu.transform.rotation = Quaternion.Slerp (menu.transform.rotation, rot, speed);
	}
}