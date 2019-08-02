using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ConfigurePlayer : MonoBehaviour
{
    private PlayerManagerModel _model;
    private Realtime _realtimeObject;
    // Start is called before the first frame update
    void Start()
    {
        _realtimeObject = GameObject.Find("Realtime + VR Player").GetComponent<Realtime>();
    }

    // Update is called once per frame
    void Update()
    {
        int clientID = _realtimeObject.clientID;
        uint y = (uint) clientID;
        print(_model.players[y].username);
    }
}
