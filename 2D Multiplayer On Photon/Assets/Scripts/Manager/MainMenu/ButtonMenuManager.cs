using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ButtonMenuManager : MonoBehaviour
{
    public static Action clickButtonPlay;
    public static Action clickButtonJoin;
    public static Action clickButtonActivePanelCreate;
    public static Action clickButtonCreateAccount;
    public static Action clickButtonActivePanelJoin;

    public static Action clickDropDownPanelRegion;

    [Header("Button MainMenu UI")]
    [SerializeField] private Button _buttonPlay;
    [Space]
    [SerializeField] private TMP_Dropdown _dropDownMenuRegion;
    [Space(10)]
    [Header("Button join in Account UI")]
    [SerializeField] private Button _buttonJoin;
    [SerializeField] private Button _buttonActivePanelCreate;
    [Space(10)]
    [Header("Button Create Account UI")]
    [SerializeField] private Button _buttonCreateAccount;
    [SerializeField] private Button _buttonActivePanelJoin;

    private void Start()
    {
        AddAllListener();
    }

    private void AddAllListener()
    {
        //Menu Button Add Listener
        _buttonPlay.onClick.RemoveAllListeners();
        _buttonPlay.onClick.AddListener(OnPlayGameButtonClick);
        //Join and Create Panel Add Listener
        _buttonJoin.onClick.RemoveAllListeners();
        _buttonJoin.onClick.AddListener(OnJoinInGameButtonClick);

        _buttonActivePanelCreate.onClick.RemoveAllListeners();
        _buttonActivePanelCreate.onClick.AddListener(OnActivePanelJoinButtonClick);

        _buttonCreateAccount.onClick.RemoveAllListeners();
        _buttonCreateAccount.onClick.AddListener(OnCreateAccountButtonClick);

        _buttonActivePanelJoin.onClick.RemoveAllListeners();
        _buttonActivePanelJoin.onClick.AddListener(OnActivePanelCreateAccountButtonClick);

        _dropDownMenuRegion.onValueChanged.RemoveAllListeners();
        _dropDownMenuRegion.onValueChanged.AddListener(OnSwitchRegionDropDownClick);
    }

    private void OnPlayGameButtonClick()
    {
        clickButtonPlay?.Invoke();
    }

    private void OnJoinInGameButtonClick()
    {
        clickButtonJoin?.Invoke();
    }

    private void OnActivePanelJoinButtonClick()
    {
        clickButtonActivePanelCreate?.Invoke();
    }

    private void OnCreateAccountButtonClick()
    {
        clickButtonCreateAccount?.Invoke();
    }

    private void OnActivePanelCreateAccountButtonClick()
    {
        clickButtonActivePanelJoin?.Invoke();
    }

    private void OnSwitchRegionDropDownClick(int index)
    {
        clickDropDownPanelRegion?.Invoke();
    }
}