using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitDetector : MonoBehaviour {

	private Vector3 objectSize;

	private void Update () {
		// Slowly increase the size of the ball while active
		objectSize.x += BowlingManager.growSpeed;
		objectSize.y += BowlingManager.growSpeed;
		objectSize.z += BowlingManager.growSpeed;
	}
	// Use this for initialization
	private void OnTriggerEnter (Collider col) {
		print (this.gameObject.name);
		//BowlingManager.ballColor = this.gameObject.name;

		objectSize = this.gameObject.transform.localScale;

	}
	private void OnTriggerExit (Collider col) {
		//BowlingManager.ballColor = "N/A";
	}
}