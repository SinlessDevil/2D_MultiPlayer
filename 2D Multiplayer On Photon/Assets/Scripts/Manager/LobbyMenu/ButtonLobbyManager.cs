using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLobbyManager : MonoBehaviour
{
    public static Action clickJoinRoom;
    public static Action clickJoinRandomRoom;
    public static Action clickCreateRoom;

    [Header("Button Join Room")]
    [SerializeField] private Button _buttonJoinRoom;
    [SerializeField] private Button _buttonJoinRandomRoom;
    [Space(10)]
    [Header("Button Create Room")]
    [SerializeField] private Button _buttonCreateRoom;

    private void Start()
    {
        AddAllListener();
    }

    private void AddAllListener()
    {
        //Button Join Room Listener
        _buttonJoinRoom.onClick.RemoveAllListeners();
        _buttonJoinRoom.onClick.AddListener(OnJoinRoomButtonClick);

        _buttonJoinRandomRoom.onClick.RemoveAllListeners();
        _buttonJoinRandomRoom.onClick.AddListener(OnJoinRandomRoomButtonClick);

        //Button Create Room Listener
        _buttonCreateRoom.onClick.RemoveAllListeners();
        _buttonCreateRoom.onClick.AddListener(OnCreateRoomButtonClick);
    }

    private void OnJoinRoomButtonClick(){
        clickJoinRoom?.Invoke();
    }
    private void OnJoinRandomRoomButtonClick(){
        clickJoinRandomRoom?.Invoke();
    }
    private void OnCreateRoomButtonClick(){
        clickCreateRoom?.Invoke();
    }
}
