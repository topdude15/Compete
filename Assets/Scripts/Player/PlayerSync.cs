using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerSync : RealtimeComponent
{
    private PlayerModel _model;
    private Realtime _realtimeObject;
    private RealtimeAvatarManager _avatarManager;

    void Start() {
        _realtimeObject = GameObject.Find("Realtime + VR Player").GetComponent<Realtime>();
        _avatarManager = GameObject.Find("Realtime + VR Player").GetComponent<RealtimeAvatarManager>();
        //print(_avatarManager.avatars.Count);
        foreach (KeyValuePair<int, RealtimeAvatar> avatar in _avatarManager.avatars) {
            print (avatar.Key);
        }
    }
    private PlayerModel model {
        set {
            _model = value;
        }
    }
}
