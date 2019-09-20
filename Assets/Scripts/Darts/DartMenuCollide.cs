using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartMenuCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print("Hello There general Kenobi");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider col) {
		print("This is it, bois" + col.gameObject.name);
		print("OOooof");
		if (col.gameObject.name == "Dart") {
			print("HoldState: Dart");
			DartsManager.holding = DartsManager.holdState.dart;
			DartsManager.CloseMenu();
		} else if (col.gameObject.name == "Dartboard") {
			print("Holdstate: Dartboard");
			DartsManager.holding = DartsManager.holdState.dartboard;
			DartsManager.CloseMenu();
			DartsManager.lockedDartboard = false;
		}
	}
}
