using UnityEngine;
using TMPro;
using Data;

public class SwitchRegion : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdownRegion;
    [Space(10)]
    [SerializeField] private DataAccount _data;

    private const float WAIT_TIME = 2f;

    private void Start()
    {
        Invoke(nameof(LoadCurrentRegion), WAIT_TIME);
    }

    public void OnEnable(){
        ButtonMenuManager.clickDropDownPanelRegion += Region;
    }

    public void OnDisable(){
        ButtonMenuManager.clickDropDownPanelRegion -= Region;
    }

    private void LoadCurrentRegion()
    {
        switch (_data.region)
        {
            case "ru":
                _dropdownRegion.value = 0;
                break;
            case "eu":
                _dropdownRegion.value = 1;
                break;
            case "asia":
                _dropdownRegion.value = 2;
                break;
        }
    }

    private void Region(){
        switch (_dropdownRegion.value){
            case 0:
                _data.region = "ru";
                break;
            case 1:
                _data.region = "eu";
                break;
            case 2:
                _data.region = "asia";
                break;
        }
        SaveToJson.instance.SaveToFile();
    }
}
