using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int lowPoints, medPoints, highPoints;
    public float decalSpawnOfset;
    public void Score_Low()
    {
        ScoreManager.AddScore(lowPoints);

        MasterManager.myScoreUIManager.Score_Low(lowPoints, transform.position+ (Vector3.up* decalSpawnOfset));
    }

    public void Score_Med()
    {
        ScoreManager.AddScore(medPoints);
        MasterManager.myScoreUIManager.Score_Med(medPoints, transform.position + (Vector3.up * decalSpawnOfset));
        
    }

    public void Score_High()
    {
        ScoreManager.AddScore(highPoints);
        MasterManager.myScoreUIManager.Score_High(highPoints, transform.position + (Vector3.up * decalSpawnOfset));

    }
}
