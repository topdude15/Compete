using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVelocity : MonoBehaviour {

	// private Rigidbody ballRB;
	private float velocity;
	// private AudioSource ballAudio;
	// private bool audioStarted = false;

	// Use this for initialization
	void Start () {
		// ballRB = this.gameObject.transform.GetComponent<Rigidbody>();
		// ballAudio = this.gameObject.transform.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// if (ballRB.velocity.magnitude >= 0.2f) {
		// 	if (audioStarted == false) {
		// 		print("Playing...");
		// 		ballAudio.Play();
		// 	}
		// } else {
		// 	print("Stopping...");
		// 	ballAudio.Stop();
		// 	audioStarted = false;
		//}
	}
}
