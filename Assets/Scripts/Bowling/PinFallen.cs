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
        if (!pinFallen)
        {
            if (Vector3.Angle(transform.up, Vector3.up) > 135 || Vector3.Angle(transform.up, Vector3.up) < 45 || Vector3.Angle(transform.forward, Vector3.forward) > 135 || Vector3.Angle(transform.forward, Vector3.forward) < 45) {
                pinFallen = true;
                bManager.pinsFallen += 1;
                bManager.UpdateFallen();
            }
        }
    }
}
