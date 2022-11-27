using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class CreateNewRoom : MonoBehaviourPunCallbacks
{
    [Header("UI Join Variables")]
    [SerializeField] private TMP_InputField _nameActiveRoom;
    [Space(10)]
    [Header("UI Create Room Variables")]
    [SerializeField] private TMP_InputField _createNameRoom;
    [SerializeField] private Slider _amountPlayers;
    [SerializeField] private TMP_Text _numberPlayer;
    [Space(10)]
    [Header("Room Variabls")]
    [SerializeField] private ListItem _itemPrefab;
    [SerializeField] private Transform _content;

    private string _maxPlayer = "5";

    public override void OnEnable(){
        ButtonLobbyManager.clickCreateRoom += CreateRoom;
        ButtonLobbyManager.clickJoinRoom += JoinRoom;
    }
    public override void OnDisable(){
        ButtonLobbyManager.clickCreateRoom -= CreateRoom;
        ButtonLobbyManager.clickJoinRoom -= JoinRoom;
    }

    private void Update(){
        _numberPlayer.text = Convert.ToString(_amountPlayers.value) + "/" + _maxPlayer;
    }


    private void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_nameActiveRoom.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(Dictionary.nameSceneGame);
    }


    private void CreateRoom(){
        if (!PhotonNetwork.IsConnected){
            return;
        }

        RoomOptions roomOptions = new()
        {
            MaxPlayers = Convert.ToByte(_amountPlayers.value)
        };
        PhotonNetwork.CreateRoom(_createNameRoom.text, roomOptions, TypedLobby.Default);
    }
    public override void OnCreatedRoom(){
        Debug.Log("Create room, name: " + PhotonNetwork.CurrentRoom.Name);
    }


    public override void OnCreateRoomFailed(short returnCode, string message){
        Debug.LogError("Failed to create a room");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        foreach (RoomInfo info in roomList){
            ListItem listem = Instantiate(_itemPrefab, _content);
            if(listem != null){
                listem.SetInfo(info);
            }
        }
    }
}
