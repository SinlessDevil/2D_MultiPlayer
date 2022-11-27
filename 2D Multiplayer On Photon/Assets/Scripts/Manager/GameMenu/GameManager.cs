using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _playerPrefab;
    private Vector3 _posSpawn;

    private void Start()
    {
        _posSpawn = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        PhotonNetwork.Instantiate(_playerPrefab.name, _posSpawn, Quaternion.identity);
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(Dictionary.nameSceneLobby);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player entered room", newPlayer.NickName);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player left room", otherPlayer.NickName);
    }
}
