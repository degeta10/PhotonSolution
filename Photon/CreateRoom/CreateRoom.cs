﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour
{
    [SerializeField] private Text _roomName;
    private Text RoomName
    {
    get { return _roomName; }
    }

    public void OnClick_CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = false, IsOpen = true, MaxPlayers = 16, PlayerTtl = 2500, EmptyRoomTtl = 2500 };

        if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
        {
            print("Create room successfully sent.");
        }
        else
        {
            print("Create room failed to send.");
        }
    }

    private void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        print("Create room failed:" + codeAndMessage[1]);
    }

    private void OnCreatedRoom()
    {
        print("Room created successfully.");
    }
}
