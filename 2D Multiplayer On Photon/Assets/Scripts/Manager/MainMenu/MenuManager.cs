using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Data;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputUserName;
    [SerializeField] private GameObject _emptyTextUsers;

    private DataAccount _data;

    private const float WAIT_TIME = 2f;

    private void Start(){
        _data = GetComponent<DataAccount>();
        StartCoroutine(LoadUserNameCoroutine());
    }

    private void OnEnable(){
        ButtonMenuManager.clickButtonPlay += LoadSceneLoading;
    }

    private void OnDisable(){
        ButtonMenuManager.clickButtonPlay -= LoadSceneLoading;
    }

    private IEnumerator LoadUserNameCoroutine(){
        yield return new WaitForSeconds(WAIT_TIME);
        _inputUserName.text = _data.login;
    }

    private void LoadSceneLoading(){
        if(_inputUserName.text == ""){
            _emptyTextUsers.SetActive(true);
            return;
        }
        //Save UserName
        _data.login = _inputUserName.text;
        SaveToJson.instance.SaveToFile();

        SceneManager.LoadScene(Dictionary.nameSceneLobby);
    }
}
