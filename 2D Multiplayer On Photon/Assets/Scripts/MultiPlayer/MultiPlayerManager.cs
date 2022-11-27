using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Data;

public class MultiPlayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _canvaslodingPanel;
    [Space(10)]
    [SerializeField] private TMP_InputField _nameNewRoom;
    [SerializeField] private Slider _maxAmountPlayerInRoom;
    [SerializeField] private TMP_Text _numberPlayer;
    [Space(10)]
    [SerializeField] private TMP_InputField _nameRoom;
    [Space(10)]
    [Header("Room Variabls")]
    [SerializeField] private ListItem _itemPrefab;
    [SerializeField] private Transform _content;
    private List<RoomInfo> _allRoomsInfo = new List<RoomInfo>();

    private DataAccount _data;
    private string _maxPlayer = "5";


    private void Start(){
        try{
            _data = GetComponent<DataAccount>();
        }catch (Exception){
            Debug.LogError("DataAccount is Null !!!");
        }

        StartCoroutine(LoadLobbyCoroutine());
    }
    private IEnumerator LoadLobbyCoroutine(){
        yield return new WaitForSeconds(1f);
        PhotonNetwork.NickName = _data.login;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(_data.region);
    }


    public override void OnConnectedToMaster(){
        Debug.Log("You are connected from the server: " + _data.region);
        _canvaslodingPanel.SetActive(false);
        if (!PhotonNetwork.InLobby){
            PhotonNetwork.JoinLobby();
        }
    }
    public override void OnDisconnected(DisconnectCause cause){
        Debug.Log("You are disconnected from the server");
    }


    private void Update(){
        _numberPlayer.text = Convert.ToString(_maxAmountPlayerInRoom.value) + "/" + _maxPlayer;
    }


    public void CreateRoom(){
        if (!PhotonNetwork.IsConnected){
            return;
        }

        RoomOptions roomOptions = new(){
            MaxPlayers = Convert.ToByte(_maxAmountPlayerInRoom.value)
        };

        Debug.Log("Name Room: " + _nameNewRoom.text);
        Debug.Log("Max Amount Players In Room: " + Convert.ToByte(_maxAmountPlayerInRoom.value));

        PhotonNetwork.CreateRoom(_nameNewRoom.text, roomOptions);
        Debug.Log("Room is Created !!!");
    }
    public override void OnCreatedRoom(){
        Debug.Log("Create room, name: " + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnCreateRoomFailed(short returnCode, string message){
        Debug.LogError("Failed to create a room");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        foreach (RoomInfo info in roomList){
            for (int i = 0; i < _allRoomsInfo.Count; i++){
                if(_allRoomsInfo[i].masterClientId == info.masterClientId){
                    return;
                }
            }
            ListItem listem = Instantiate(_itemPrefab, _content);
            if (listem != null){
                listem.SetInfo(info);
                _allRoomsInfo.Add(info);
            }
        }
    }


    public void JoinRoom(){
        PhotonNetwork.JoinRoom(_nameRoom.text);
    }
    public void JoinRandomRoom(){
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom(){
        Debug.Log("Join in Game Scene");
        PhotonNetwork.LoadLevel(Dictionary.nameSceneGame);
    }
}
