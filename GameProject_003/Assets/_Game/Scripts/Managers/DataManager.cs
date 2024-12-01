using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public bool isLoaded = false;
    [Header("Data References")]
    public Data dataSaved;
    private const string DATA_SAVED = "DataSaved";
    private Data dataBackup;

    private void OnApplicationPause(bool pause) { SaveData(); }
    private void OnApplicationQuit() { SaveData(); }

    public void LoadData()
    {
        try
        {
            isLoaded = true;

            if (PlayerPrefs.HasKey(DATA_SAVED)) dataSaved = JsonUtility.FromJson<Data>(PlayerPrefs.GetString(DATA_SAVED));

            if (dataSaved.isNew)
            {
                dataSaved = new Data();
                dataSaved.isNew = false;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Load Data Error:" + ex);
        }
    }


    public void SaveData()
    {
        try
        {
            if (!isLoaded) return;

            if (dataSaved == null)
            {
                if (dataBackup != null)
                {
                    dataSaved = dataBackup;
                }
                else
                {
                    dataSaved = new Data();
                    Debug.LogError("dataSaved null, backup fail. Reset data");
                }

            }

            dataBackup = dataSaved;

            PlayerPrefs.SetString(DATA_SAVED, JsonUtility.ToJson(dataSaved));
            PlayerPrefs.Save();
        }
        catch (Exception ex)
        {
            Debug.LogError("Save Data Error:" + ex);
        }
    }

    [System.Serializable]
    public class Data
    {
        [Header("Basic Infor")]
        public bool isNew = true;
        public int currentLevel = 0;

        [Header("Sound")]
        public bool musicOn;
        public bool soundOn;
        public bool vibrationOn;

        public Data()
        {
            isNew = true;
            currentLevel = 1;

            musicOn = true;
            soundOn = true;
            vibrationOn = true;
        }
    }
}
