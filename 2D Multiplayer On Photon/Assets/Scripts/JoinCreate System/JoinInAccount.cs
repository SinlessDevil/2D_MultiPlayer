using UnityEngine;
using TMPro;
using Data;

public class JoinInAccount : MonoBehaviour
{
    [Header("InputField Join Panel")]
    [SerializeField] private TMP_InputField _inputLogin;
    [SerializeField] private TMP_InputField _inputPassword;
    [Space(10)]
    [Header("Data Account")]
    [SerializeField] private DataAccount _data;
    [Space(10)]
    [Header("Panel Object")]
    [SerializeField] private GameObject _panelJoin;
    [SerializeField] private GameObject _panelCreateAccount;
    [SerializeField] private GameObject _CanvasJoinAndCreateMenu;
    [Space(10)]
    [Header("Error Text")]
    [SerializeField] private GameObject _textEmptyField;
    [SerializeField] private GameObject _textWordField;

    private void OnEnable()
    {
        ButtonMenuManager.clickButtonJoin += Join;
        ButtonMenuManager.clickButtonActivePanelCreate += ActiveCreatePanel;
    }
    private void OnDisable()
    {
        ButtonMenuManager.clickButtonJoin -= Join;
        ButtonMenuManager.clickButtonActivePanelCreate -= ActiveCreatePanel;
    }

    private void Join(){
        //Update Error
        _textEmptyField.SetActive(false);
        _textWordField.SetActive(false);
        _inputLogin.transform.Find("Image_ErrorMark").gameObject.SetActive(false);
        _inputPassword.transform.Find("Image_ErrorMark").gameObject.SetActive(false);

        //Checking for an empty field
        CheckLoginIsNull = _inputLogin.text;
        CheckPasswordIsNull = _inputPassword.text;

        if (_inputLogin.text == "" || _inputPassword.text == ""){
            _textEmptyField.SetActive(true);
            return;
        }else{
            _textEmptyField.SetActive(false);
        }
        //Checking the validity of the field
        if(_data.login != _inputLogin.text || _data.password != _inputPassword.text){
            _textWordField.SetActive(true);
            _inputLogin.transform.Find("Image_ErrorMark").gameObject.SetActive(true);
            _inputPassword.transform.Find("Image_ErrorMark").gameObject.SetActive(true);
            return;
        }

        //Loked Canvas Join/Create Menu
        _CanvasJoinAndCreateMenu.SetActive(false);
    }
    private void ActiveCreatePanel(){
        _panelCreateAccount.SetActive(true);
        _panelJoin.SetActive(false);
    }

    public string CheckLoginIsNull{
        get{
            return _inputLogin.text;
        }
        set{
            if(_inputLogin.text == ""){
                _inputLogin.transform.Find("Image_ErrorMark").gameObject.SetActive(true);
                return;
            }else{
                _inputLogin.transform.Find("Image_ErrorMark").gameObject.SetActive(false);
                _inputLogin.text = value;
            }           
        }
    }
    public string CheckPasswordIsNull{
        get{
            return _inputPassword.text;
        }
        set{
            if (_inputPassword.text == ""){
                _inputPassword.transform.Find("Image_ErrorMark").gameObject.SetActive(true);
                return;
            }else{
                _inputPassword.transform.Find("Image_ErrorMark").gameObject.SetActive(false);
                _inputPassword.text = value;
            }
        }
    }
}
