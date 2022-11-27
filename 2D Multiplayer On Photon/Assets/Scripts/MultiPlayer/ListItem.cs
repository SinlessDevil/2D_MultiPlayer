using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameRoom;
    [SerializeField] private TMP_Text _playerCount;

    public void SetInfo(RoomInfo info)
    {
        _nameRoom.text = info.Name;
        _playerCount.text = info.PlayerCount + "/" + info.MaxPlayers; 
    }

    public void JoinToListRoom()
    {
        PhotonNetwork.JoinRoom(_nameRoom.text);
    }
}
