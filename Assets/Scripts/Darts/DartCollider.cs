using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartCollider : MonoBehaviour {

	private Rigidbody dartRB;
	private AudioSource dartAudio;
	// Use this for initialization
	void Start () {
		dartRB = this.GetComponent<Rigidbody>();
		dartAudio = this.GetComponent<AudioSource>();
	}
	
	private void OnCollisionEnter(Collision other) {
		dartRB.velocity = Vector3.zero;
		dartRB.isKinematic = true;
		dartAudio.Play();
		print("Playsound");
	}
}
