using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class SetPinParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        Transform pinParent = GameObject.Find("Pin Holder").transform;

        // transform.parent = pinParent;

        transform.SetParent(pinParent, GetComponent<RealtimeView>().isOwnedLocally);

        GetComponent<RealtimeTransform>().ParentTransform = pinParent;
          
    }

    // Update is called once per frame
}
