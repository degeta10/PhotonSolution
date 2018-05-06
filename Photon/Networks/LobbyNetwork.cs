using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyNetwork : MonoBehaviour
{

	private void Start ()
    {
        if (!PhotonNetwork.connected)
            PhotonNetwork.ConnectUsingSettings("0.1");
        else
            PhotonNetwork.Disconnect();
	}

    private void OnDisconnectedFromPhoton()
    {
        PhotonNetwork.Reconnect();
    }

    private void OnConnectedToMaster()
    {
        print("Connected to master.");
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.playerName = PlayerNetwork.Instance.PlayerName;
        //PhotonNetwork.autoCleanUpPlayerObjects = true;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    private void OnJoinedLobby()
    {
        print("Joined lobby.");

        if (!PhotonNetwork.inRoom)
            MainCanvasManager.Instance.LobbyCanvas.transform.SetAsLastSibling();
    }
}
