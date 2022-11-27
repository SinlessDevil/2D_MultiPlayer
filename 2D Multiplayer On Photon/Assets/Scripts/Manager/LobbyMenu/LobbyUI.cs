using UnityEngine;


public class LobbyUI : MonoBehaviour
{
    private MultiPlayerManager _multiplayer;

    private void Start(){
        try{
            _multiplayer = GetComponent<MultiPlayerManager>();
        }catch (System.Exception){
            Debug.LogError("Component Multiplayer is null");
            throw;
        }
    }

    public void OnEnable()
    {
        ButtonLobbyManager.clickCreateRoom += OnClickCreateRoom;
        ButtonLobbyManager.clickJoinRoom += OnClickJoinRoom;
        ButtonLobbyManager.clickJoinRandomRoom += OnClickJoinRandomRoom;
    }
    public void OnDisable()
    {
        ButtonLobbyManager.clickCreateRoom -= OnClickCreateRoom;
        ButtonLobbyManager.clickJoinRoom -= OnClickJoinRoom;
        ButtonLobbyManager.clickJoinRandomRoom -= OnClickJoinRandomRoom;
    }

    private void OnClickCreateRoom(){
        _multiplayer.CreateRoom();
    }
    private void OnClickJoinRoom(){
        _multiplayer.JoinRoom();
    }
    private void OnClickJoinRandomRoom(){
        _multiplayer.JoinRandomRoom();
    }
}
