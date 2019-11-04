using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class RequestPrivileges : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PrivilegeRequester _privilegeRequester = GetComponent<PrivilegeRequester>();
        if (_privilegeRequester == null) {
            // Handle missing privilege requester
        }
        _privilegeRequester.Privileges = new[]
        {
            MLRuntimeRequestPrivilegeId.PwFoundObjRead,
            MLRuntimeRequestPrivilegeId.LocalAreaNetwork
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
