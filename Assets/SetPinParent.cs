using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class SetPinParent : MonoBehaviour
{
    // Start is called before the first frame update
    //
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Transform pinParent = GameObject.Find("Pin Holder").transform;

        // transform.parent = pinParent;

        transform.SetParent(pinParent, GetComponent<RealtimeView>().isOwnedLocally);
        StartCoroutine(Example());
        rb.isKinematic = false;
        // this.gameObject.GetComponent<RealtimeView>().RequestOwnership();
        // this.gameObject.GetComponent<RealtimeTransform>().RequestOwnership();
    }

    // Update is called once per frame
    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(0.5f);
        rb.isKinematic = false;
    }
}
