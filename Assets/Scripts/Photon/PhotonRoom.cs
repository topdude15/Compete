// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Photon.Pun;
// using Photon.Realtime;
// using UnityEngine.SceneManagement;

// public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks {

// 	public static PhotonRoom room;
// 	private PhotonView PV;

// 	public bool isGameLoaded;
// 	public int currentScene;

// 	Player[] photonPlayers;
// 	public int playersInRoom;
// 	public int myNumberInRoom;

// 	public int playersInGame;

// 	private bool readyToCount;
// 	private bool readyToStart;
// 	public float startingTime;
// 	private float lessThanMaxPlayers;
// 	private float atMaxPlayers;
// 	private float timeToStart;

// 	private void Awake() {
// 		if (PhotonRoom.room == null) {
// 			PhotonRoom.room = this;
// 		} else {
// 			if (PhotonRoom.room != this) {
// 				Destroy(PhotonRoom.room.gameObject);
// 				PhotonRoom.room = this;
// 			}
// 		}
// 		DontDestroyOnLoad(this.gameObject);
// 	}

// 	public override void OnEnable() {
// 		base.OnEnable();
// 		PhotonNetwork.AddCallbackTarget(this);
// 		//SceneManager.sceneLoaded += OnSceneFinishedLoading;
// 	}

// 	public override void OnDisable() {
// 		base.OnDisable();
// 		PhotonNetwork.RemoveCallbackTarget(this);
// 	//	SceneManager.sceneLoaded += OnSceneFinishedLoading; 	
// 	}


// 	// Use this for initialization
// 	void Start () {
// 		PV = GetComponent<PhotonView>();
// 		readyToCount = false;
// 		readyToStart = false;
// 		lessThanMaxPlayers = startingTime;
// 		atMaxPlayers = 6;
// 		timeToStart = startingTime;
// 	}
	
// 	// Update is called once per frame
// 	void Update () {
		
// 	}
// 		// public override void OnJoinRoom() {
// 		// 	base.OnJoinRoom();
// 		// 	print("you are now in a room");
// 		// 	photonPlayers = PhotonNetwork.PlayerList;
// 		// 	playersInRoom = photonPlayers.Length;
// 		// 	myNumberInRoom = playersInRoom;
// 		// 	PhotonNetwork.NickName = myNumberInRoom.ToString();
// 		// 	if (MultiplayerSettings.multiplayerSettings.delayStart) {
// 		// 		// If delayed start
// 		// 		if (playersInRoom > 1) {
// 		// 			readyToCount = true;
// 		// 		}
// 		// 		if (playersInRoom) {

// 		// 		}
// 		// 	}

// 		// }
// }
