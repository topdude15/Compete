using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class Controller : MonoBehaviour {

	// Use this for initialization
	public MLInputController _controller;
	public Timer bumperTimer = new Timer ();

	void Start () {
		MLInput.Start ();
		_controller = MLInput.GetController (MLInput.Hand.Left);
		MLInput.OnControllerButtonDown += OnButtonDown;
		MLInput.OnControllerButtonUp += OnButtonUp;
	}
	private void OnDestroy() {
		MLInput.Stop();
	}

	// Update is called once per frame
	void Update () {

	}
	void OnButtonDown (byte controller_id, MLInputControllerButton button) {
		if (button == MLInputControllerButton.Bumper) {
			bumperTimer.start ();
		}
	}

	void OnButtonUp (byte controller_id, MLInputControllerButton button) {
		if (button == MLInputControllerButton.Bumper) {
			bumperTimer.stop ();
		}
	}
	public void haptic_forceDown (MLInputControllerFeedbackIntensity force) {
		_controller.StartFeedbackPatternVibe (MLInputControllerFeedbackPatternVibe.ForceDown, force);
	}
	public void haptic_forceUp (MLInputControllerFeedbackIntensity force) {
		_controller.StartFeedbackPatternVibe (MLInputControllerFeedbackPatternVibe.ForceUp, force);
	}
	public void haptic_tick (MLInputControllerFeedbackIntensity force) {
		_controller.StartFeedbackPatternVibe (MLInputControllerFeedbackPatternVibe.Tick, force);
	}
	public void haptic_bump (MLInputControllerFeedbackIntensity force) {
		_controller.StartFeedbackPatternVibe (MLInputControllerFeedbackPatternVibe.Bump, force);
	}
}