using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPinParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject pinParent = GameObject.Find("[CONTENT]/Pin Holder");
        transform.parent = pinParent.transform;

        GameObject manage = GameObject.Find("[LOGIC]/GameManager");
        // manage.GetComponent<BowlingManager>().GetCount();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
