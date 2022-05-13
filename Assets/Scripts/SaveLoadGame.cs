using UnityEngine;
using System;// para el "Serializable" 
using System.IO;// para FILE
using System.Runtime.Serialization.Formatters.Binary;// para BinaryFormatter

public class SaveLoadGame : MonoBehaviour
{
    public int highScore;
    public string highName = "";
    public string tempName = "";
    public static SaveLoadGame sharedSaveLoadGame;

    void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        if (sharedSaveLoadGame == null)
        {
            sharedSaveLoadGame = this;
            load();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        load();
    }

    public void save()
    {
        BinaryFormatter fb = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/DataGame");
        DataGame lv = new DataGame();
        lv.highScore = highScore;
        lv.highName = highName;

        fb.Serialize(file, lv);
        file.Close();
    }

    public void load()
    {
        BinaryFormatter fb = new BinaryFormatter();
        FileStream file;
        DataGame lv;
        if (File.Exists(Application.persistentDataPath + "/DataGame"))
        {
            file = File.Open(Application.persistentDataPath + "/DataGame", FileMode.Open);
            lv = (DataGame)fb.Deserialize(file);
            highScore = lv.highScore;
            highName = lv.highName;
        }
        else
        {//el archivo no existe, hay que crearlo.
            highScore = 1;//default value
            file = File.Create(Application.persistentDataPath + "/DataGame");
            lv = new DataGame();
            lv.highScore = highScore;
            lv.highName = highName;


            fb.Serialize(file, lv);
        }
        file.Close();
    }

    public void resetData()
    {
        BinaryFormatter fb = new BinaryFormatter();
        FileStream file;
        DataGame lv;
        //default value;
        highScore = 0;//default value
        highName = "";//default value

        file = File.Create(Application.persistentDataPath + "/DataGame");
        lv = new DataGame();
        lv.highScore = highScore;
        lv.highName = highName;

        fb.Serialize(file, lv);
        file.Close();

    }

    [Serializable]
    public class DataGame
    {
        public int highScore;
        public string highName;

    }


}
