using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinFallen : MonoBehaviour
{
    BowlingManager bManager;
    private bool pinFallen = false;
    // Start is called before the first frame update
    void Start()
    {
        bManager = GameObject.Find("Main Camera").GetComponent<BowlingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.rotation.x > -20 && transform.rotation.x < -160) && pinFallen == false) {
            pinFallen = true;
            bManager.pinsFallen += 1;
            print(bManager.pinsFallen);
        }
    }
}
