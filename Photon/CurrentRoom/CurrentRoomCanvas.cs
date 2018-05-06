using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    
    public void OnClickStartSync()
    {
        if (!PhotonNetwork.isMasterClient)
            return;
        PhotonNetwork.room.IsVisible = true;
        PhotonNetwork.LoadLevel(1);
    }

}
