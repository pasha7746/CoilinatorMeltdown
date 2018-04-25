using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class ScoreManager
{
    public static int gameScore;
    public static int highScore;
   // public static event Action<int, Vector3> OnSpawnDecal;

    public static void AddScore(int score)
    {
        gameScore += score;
    }

    public static void RunHighScoreCheck()
    {
        if (gameScore > highScore)
        {
            highScore = gameScore;
            SaveScore();
        }
    }
    public static void SaveScore()
    {
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile.sv");
        bf.Serialize(file, highScore);
        file.Close();
    }
    public static void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile.sv"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile.sv", FileMode.Open);
            highScore = (int)bf.Deserialize(file);
            file.Close();
        }
    }

}
