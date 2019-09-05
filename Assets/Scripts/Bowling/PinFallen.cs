using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinFallen : MonoBehaviour
{

    private bool pinFallen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.x > 0 || transform.rotation.x < -160) {
            pinFallen = true;
        }
    }
}
