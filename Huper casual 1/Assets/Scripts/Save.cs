using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Save : MonoBehaviour
{
    public int score;
    public static Save instance;

    private void Start()
    {
        instance = this;
    }
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath 
            + "/MySaveData.dat"); 
        SaveData data = new SaveData();
        data.maxScore = score;
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath 
            + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
            File.Open(Application.persistentDataPath 
            + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            score = data.maxScore;
        }
    }
}

[Serializable]
class SaveData
{
    public int maxScore;
}
