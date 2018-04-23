using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    public static int gameScore;
    public static int highScore;


    public static void AddScore(int score)
    {
        gameScore += score;
    }




}
