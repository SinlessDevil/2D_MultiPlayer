using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGameManager : MonoBehaviour
{
    public static Action clickLeftRoom;

    [Header("Button Game UI")]
    [SerializeField] private Button _buttonLeftRoom;

    private void Start()
    {
        AddAllListener();
    }

    private void AddAllListener()
    {
        //Button Join Room Listener
        _buttonLeftRoom.onClick.RemoveAllListeners();
        _buttonLeftRoom.onClick.AddListener(OnJoinRoomButtonClick);
    }

    private void OnJoinRoomButtonClick()
    {
        clickLeftRoom?.Invoke();
    }
}
