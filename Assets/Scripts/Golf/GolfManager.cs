using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.MagicLeap;

public class GolfManager : MonoBehaviour {

	private MLInputController controller;
	public GameObject mainCam, orientationCube, control, menu, ballMenu, tutorialMenu, clubHolder, putter;
	public LineRenderer laserLineRenderer;
	private Controller checkController;
	// Use this for initialization
	void Start () {
		MLInput.Start();

		controller = MLInput.GetController(MLInput.Hand.Left);
		MLInput.OnControllerButtonDown += OnButtonDown;

		Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
		laserLineRenderer.SetPositions(initLaserPositions);

	}

	private void OnDestroy() {
		MLInput.Stop();
	}

	
	// Update is called once per frame
	void Update () {
		clubHolder.transform.position = controller.Position;
		clubHolder.transform.rotation = controller.Orientation;
	}
	void OnButtonDown(byte controller_id, MLInputControllerButton button) {

	}
}
