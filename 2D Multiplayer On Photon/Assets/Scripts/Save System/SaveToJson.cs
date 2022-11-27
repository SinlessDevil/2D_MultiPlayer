using Data;
using Data.Struct;
using UnityEngine;
using System;
using System.IO;

public class SaveToJson : MonoBehaviour
{
    #region TypePlatform
    public enum TypePlatform
    {
        PC,
        Android
    }
    public TypePlatform typePlatform;
    #endregion

    [Header("Save Config")]
    [SerializeField] private string savePath;
    [SerializeField] private string saveFileName = "dataAccount.json";

    private DataAccount _data;

    public static SaveToJson instance;

    private const float WAIT_TIME = 1f;

    private void Awake(){
        // Patern Singelton
        if(instance == null){
            instance = this;
        }

        // Switch Platfrom
        switch (typePlatform){
            case TypePlatform.PC:
                savePath = Path.Combine(Application.persistentDataPath, saveFileName);
                break;
            case TypePlatform.Android:
                savePath = Path.Combine(Application.dataPath, saveFileName);
                break;
        }
    }
    private void Start(){
        try{
            _data = GetComponent<DataAccount>();
        }catch (Exception){
            Debug.LogError("Component DataAccount is null");
            throw;
        }

        Invoke(nameof(LoadToFile), WAIT_TIME);
    }
    
    //Save and Load Methods
    public void SaveToFile(){
        AccountStruct gameData = new AccountStruct {
            login = this._data.login,
            password = this._data.password,
            region = this._data.region
        };

        string json = JsonUtility.ToJson(gameData, true);

        try{
            File.WriteAllText(savePath, json);
        }catch (Exception e){
            Debug.Log("{GameLog} => [SaveToJson] - (<color=red>Error</color>) - SaveToFile ->" + e.Message);
        }
    }
    public void LoadToFile(){
        if (!File.Exists(savePath)){
            Debug.Log("{GameLog} => [SaveToJson] - LoadToFile -> File is Not Found");
            return;
        }

        try{
            string json = File.ReadAllText(savePath);
            AccountStruct gameDaraFromJson = JsonUtility.FromJson<AccountStruct>(json);
            this._data.login = gameDaraFromJson.login;
            this._data.password = gameDaraFromJson.password;
            this._data.region = gameDaraFromJson.region;
        }
        catch (Exception e)
        {
            Debug.Log("{GameLog} => [SaveToJson] - (<color=red>Error</color>) - LoadToFile ->" + e.Message);
        }
    }
}

