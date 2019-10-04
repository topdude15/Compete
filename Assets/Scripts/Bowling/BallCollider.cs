using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollider : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource ballSource;
    void Start()
    {
        ballSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "Single(Clone)" || col.gameObject.name == "Single" || col.gameObject.name == "SingleNoGravity(Clone)") {
            ballSource.Play();
        }
    }
}
