using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SettingsHandler : MonoBehaviour
{
    public void clearData(){
        string path = Application.persistentDataPath + "/WaterData.txt";

        PlayerPrefs.SetInt("currentWaterDaily", 0);
        PlayerPrefs.SetInt("waterDailyLimit", 0);

        if (File.Exists(path)){
            File.Delete(path);
       }

    }
}
