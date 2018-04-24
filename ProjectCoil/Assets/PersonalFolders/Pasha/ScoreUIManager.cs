using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    public float referenceDistance;
   [System.Serializable]
    public struct ScoreTypes
    {
        public float rate;
        public int fontSize;
        
    }

    public ScoreTypes lowScore, medScore, highScore;


    //yes yes its copy paste same method...yes i know i could use a switch with enums...
    public void Score_Low(int score, Vector3 pos)
    {
        GameObject scorePrefab=  MasterManager.myPool.Give_ScoreUI();
        ScoreUI tempUI = scorePrefab.GetComponent<ScoreUI>();

        tempUI.fontSize = lowScore.fontSize;
        tempUI.rate = lowScore.rate;

        tempUI.score = score;
        scorePrefab.transform.LookAt(MasterManager.player.transform.position);
        scorePrefab.transform.position = pos;
        scorePrefab.SetActive(true);

    }
    public void Score_Med(int score, Vector3 pos)
    {
        GameObject scorePrefab = MasterManager.myPool.Give_ScoreUI();
        ScoreUI tempUI = scorePrefab.GetComponent<ScoreUI>();

        tempUI.fontSize = medScore.fontSize;
        tempUI.rate = medScore.rate;

        tempUI.score = score;
        scorePrefab.transform.LookAt(MasterManager.player.transform.position);

        scorePrefab.transform.position = pos;
        scorePrefab.SetActive(true);

    }
    public void Score_High(int score, Vector3 pos)
    {
        GameObject scorePrefab = MasterManager.myPool.Give_ScoreUI();
        ScoreUI tempUI = scorePrefab.GetComponent<ScoreUI>();

        tempUI.fontSize = highScore.fontSize;
        tempUI.rate = highScore.rate;

        tempUI.score = score;
        scorePrefab.transform.LookAt(MasterManager.player.transform.position);

        scorePrefab.transform.position = pos;
        scorePrefab.SetActive(true);

    }
}
