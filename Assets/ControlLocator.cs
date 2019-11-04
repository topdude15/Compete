using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicLeapTools;
using UnityEngine.XR.MagicLeap;

public class ControlLocator : MonoBehaviour
{
    private GameObject _controller;
    private MLInputController _control;
    private TransmissionObject _transmissionObj;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GameObject.Find("Controller");
        _control = MLInput.GetController(0);
        _transmissionObj = GetComponent<TransmissionObject>();
    }

    // Update is called once per frame
    void Update()
    {
        _transmissionObj.motionSource = _controller.transform;
    }
}
