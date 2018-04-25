using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreForPause : MonoBehaviour
{
    public Text myScoreUI;
    public Text myHighScoreUI;

    void OnEnable()
    {
        myScoreUI.text = ScoreManager.gameScore.ToString();
        ScoreManager.RunHighScoreCheck();
        myHighScoreUI.text = ScoreManager.highScore.ToString();
    }


}
