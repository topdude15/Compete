using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTutorial : MonoBehaviour
{
    private GameObject _controller;
    private float rotateSpeed = 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        _controller = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        _controller.transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f, Space.World);
        //_controller.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
