using UnityEngine;
using TMPro;
using Data;

public class CreateAnAccount : MonoBehaviour
{
    [Header("InputField Join Panel")]
    [SerializeField] private TMP_InputField _inputLogin;
    [SerializeField] private TMP_InputField _inputPassword;
    [SerializeField] private TMP_InputField _inputRepeatPassword;
    [Space(10)]
    [Header("Data Account")]
    [SerializeField] private DataAccount _data;
    [Space(10)]
    [Header("Panel Object")]
    [SerializeField] private GameObject _panelJoin;
    [SerializeField] private GameObject _panelCreateAccount;
    [SerializeField] private GameObject _canvasJoinAndCreateMenu;
    [Header("Error Text")]
    [SerializeField] private GameObject _textEmptyField;
    [SerializeField] private GameObject _textErrorPasswordField;

    private void OnEnable()
    {
        ButtonMenuManager.clickButtonCreateAccount += CreateAccount;
        ButtonMenuManager.clickButtonActivePanelJoin += ActiveJoinPanel;
    }
    private void OnDisable()
    {
        ButtonMenuManager.clickButtonCreateAccount -= CreateAccount;
        ButtonMenuManager.clickButtonActivePanelJoin -= ActiveJoinPanel;
    }

    private void CreateAccount(){
        //Update Error
        _textEmptyField.SetActive(false);
        _textErrorPasswordField.SetActive(false);
        _inputLogin.transform.Find("Image_ErrorMark").gameObject.SetActive(false);
        _inputRepeatPassword.transform.Find("Image_ErrorMark").gameObject.SetActive(false);
        _inputPassword.transform.Find("Image_ErrorMark").gameObject.SetActive(false);
        //Checking for an empty field
        CheckLoginIsNull = _inputLogin.text;
        CheckPasswordIsNull = _inputPassword.text;
        CheckReapeatPasswordIsNull = _inputRepeatPassword.text;

        if (_inputLogin.text == "" || _inputPassword.text == "" || _inputRepeatPassword.text == ""){
            _textEmptyField.SetActive(true);
            return;
        }else{
            _textEmptyField.SetActive(false);
        }
        //Checking password verification and RepeatPassword
        if(_inputPassword.text != _inputRepeatPassword.text){
            Debug.Log(_inputPassword.text);
            Debug.Log(_inputRepeatPassword.text);
            _textErrorPasswordField.SetActive(true);
            _inputRepeatPassword.transform.Find("Image_ErrorMark").gameObject.SetActive(true);
            _inputPassword.transform.Find("Image_ErrorMark").gameObject.SetActive(true);
            return;
        }
        //Create Account
        _data.login = this._inputLogin.text;
        _data.password = this._inputPassword.text;
        SaveToJson.instance.SaveToFile();
        //Loked Canvas Join/Create Menu
        _canvasJoinAndCreateMenu.SetActive(false);
    }
    private void ActiveJoinPanel(){
        _panelJoin.SetActive(true);
        _panelCreateAccount.SetActive(false);
    }

    public string CheckLoginIsNull{
        get{
            return _inputLogin.text;
        }set{
            if (_inputLogin.text == "")
            {
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
    public string CheckReapeatPasswordIsNull{
        get{
            return _inputRepeatPassword.text;
        }set{
            if (_inputRepeatPassword.text == "")
            {
                _inputRepeatPassword.transform.Find("Image_ErrorMark").gameObject.SetActive(true);
                return;
            }else{
                _inputRepeatPassword.transform.Find("Image_ErrorMark").gameObject.SetActive(false);
                _inputRepeatPassword.text = value;
            }
        }
    }
}