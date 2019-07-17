using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//
	}
	private void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "Ball") {
			print ("Holdstate: ball");
			BowlingManager.holding = BowlingManager.holdState.ball;
			BowlingManager.CloseMenu ();
		} else if (col.gameObject.name == "10Pin") {
			print ("Holdstate: tenPin");
			BowlingManager.holding = BowlingManager.holdState.tenPin;
			BowlingManager.CloseMenu ();
		} else if (col.gameObject.name == "Single") {
			print ("Holdstate: single");
			BowlingManager.holding = BowlingManager.holdState.single;
			BowlingManager.CloseMenu ();
		}
	}
}