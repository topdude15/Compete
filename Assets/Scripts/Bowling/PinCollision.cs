using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCollision : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody pinRB;
    private AudioSource pinAudio;
    private bool playedSound = false;
    void Start()
    {
        pinRB = this.GetComponent<Rigidbody>();
        pinAudio = this.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision col) {
        if (!playedSound) {
            if (col.gameObject.name == "BowlingBall(Clone)" || col.gameObject.name == "Single" || col.gameObject.name == "SingleNoGravity") {
                pinAudio.Play();
                print("Play sound");
                playedSound = true;
            }   
        }
    }
}
