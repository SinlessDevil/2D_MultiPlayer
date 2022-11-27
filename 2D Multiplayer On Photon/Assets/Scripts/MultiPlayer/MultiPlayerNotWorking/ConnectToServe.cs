using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Data;
using System.Collections;
using System;

public class ConnectToServe : MonoBehaviourPunCallbacks
{
    private DataAccount _data;
    private void Start(){
        try{
            _data = GetComponent<DataAccount>();
        }catch (Exception){
            Debug.LogError("DataAccount is Null !!!");
        }

        StartCoroutine(LoadGameCoroutine());
    }

    private IEnumerator LoadGameCoroutine()
    {
        yield return new WaitForSeconds(1f);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(_data.region);
    }

    public override void OnConnectedToMaster()
    {
       // PhotonNetwork.JoinLobby();
        Debug.Log("You are connected from the server: " + _data.region);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("You are disconnected from the server");
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene(Dictionary.nameSceneLobby);
    }
}
