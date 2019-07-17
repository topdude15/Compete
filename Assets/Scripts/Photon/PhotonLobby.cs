// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Photon.Realtime;
// using Photon.Pun;

// public class PhotonLobby : MonoBehaviourPunCallbacks {

// 	public static PhotonLobby lobby;

// 	//public GameObject battleButton;
// 	//public GameObject cancelButton;

// 	private void Awake() {
// 		lobby = this;
// 	}

// 	// Use this for initialization
// 	void Start () {
// 		PhotonNetwork.ConnectUsingSettings();
// 		//battleButton = GameObject.Find("JoinLobby");
// 		//cancelButton = GameObject.Find("ExitLobby");
// 	}
	
// 	public override void OnConnectedToMaster() {
// 		print("Player has connected to lobby");
// 		//battleButton.SetActive(true);
// 		PhotonNetwork.AutomaticallySyncScene = true;
// 	}
	
// 	public static void OnBattleButtonClicked() {
// 		//battleButton.SetActive(false);
// 		//cancelButton.SetActive(true);
// 		PhotonNetwork.JoinRandomRoom();
// 	}

// 	public override void OnJoinRandomFailed(short returnCode, string message) {
// 		print("Failed to join random room.  There may be no room available");
// 		CreateRoom();
// 	}

// 	void CreateRoom() {
// 		int randomRoomName = Random.Range(0, 10000);
// 		RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)MultiplayerSettings.multiplayerSettings.maxPlayers};
// 		PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
// 	}

// 	public override void OnCreateRoomFailed(short returnCode, string message) {
// 		print("Failed to create a room");
// 		CreateRoom();
// 	}

// 	public static void OnCancelButtonClicked() {
// 		//cancelButton.SetActive(false);
// 		//battleButton.SetActive(true);
// 		PhotonNetwork.LeaveRoom();
// 	}
// 	// Update is called once per frame
// 	// void Update () {
		
// 	// }
// }
