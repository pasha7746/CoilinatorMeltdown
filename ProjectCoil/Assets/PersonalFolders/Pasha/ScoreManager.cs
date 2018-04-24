using System;
using System.Collections;
using System.Collections.Generic;
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

    //public static void ScoreUI(int points, Vector3 pos)
    //{
    //    if (OnSpawnDecal != null) OnSpawnDecal(points, pos);
    //}



}
