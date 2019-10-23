using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCount : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _mainCam, _pinHolder;
    void Start()
    {
        _mainCam = GameObject.Find("Main Camera");
        BowlingManager bManager = _mainCam.GetComponent<BowlingManager>();

        _pinHolder = GameObject.Find("Pin Holder");
        transform.SetParent(_pinHolder.transform);

        bManager.GetCount();
    }
}
