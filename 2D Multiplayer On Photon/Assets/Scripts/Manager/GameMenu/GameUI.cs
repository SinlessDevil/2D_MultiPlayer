using UnityEngine;

public class GameUI : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        try{
            _gameManager = GetComponent<GameManager>();
        }catch (System.Exception){
            Debug.LogError("Component Multiplayer is null");
            throw;
        }
    }

    public void OnEnable(){
        ButtonGameManager.clickLeftRoom += OnClickLeftRoom;
    }
    public void OnDisable(){
        ButtonGameManager.clickLeftRoom += OnClickLeftRoom;
    }

    private void OnClickLeftRoom(){
        _gameManager.Leave();
    }
}
