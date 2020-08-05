using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Save : MonoBehaviour
{
    public int score;
    public int points;
    public static Save instance;

    private void Awake()
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
        }
    }
}

[Serializable]
class SaveData
{
    public int maxScore;
    public int allPoints;
}
