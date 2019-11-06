using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicLeapTools;

public class ObjectForceUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    private TransmissionObject _transmissionObj;
    void Start()
    {
        _transmissionObj = GetComponent<TransmissionObject>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(_transmissionObj.ShareTransformStatus());
    }
}
