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
            if (Mathf.Abs(Vector3.Angle(transform.up, Vector3.up)) >= 100 || Mathf.Abs(Vector3.Angle(transform.up, Vector3.up)) <= 80 || Mathf.Abs(Vector3.Angle(transform.forward, Vector3.forward)) >= 100 || Mathf.Abs(Vector3.Angle(transform.forward, Vector3.forward)) <= 80) {
                pinFallen = true;
                bManager.pinsFallen += 1;
                bManager.UpdateFallen();
            }
        }
    }
}
