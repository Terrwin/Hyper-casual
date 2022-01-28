using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Save : MonoBehaviour
{
    public int score;
    public int points;
    public List<int> colors = new List<int>();
    public int currentColor;
    public bool controll;
    public static Save instance;

    private void Start()
    {
        instance = this;
    }
    
    public void SaveScore()
    {
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat"); 
        SaveData data = new SaveData();
        data.maxScore = score;
        data.allPoints = points;
        data.colorsBuyed = colors;
        data.colorEnabled = currentColor;
        data.controllType = controll;
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            score = data.maxScore;
            points = data.allPoints;
            colors = data.colorsBuyed;
            currentColor = data.colorEnabled;
            controll = data.controllType;
        }
    }
}

[Serializable]
class SaveData
{
    public int maxScore;
    public int allPoints;
    public List<int> colorsBuyed;
    public int colorEnabled;
    public bool controllType;
}
