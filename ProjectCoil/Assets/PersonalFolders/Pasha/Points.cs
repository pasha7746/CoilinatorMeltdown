using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int lowPoints, medPoints, highPoints;

    public void Score_Low()
    {
        ScoreManager.AddScore(lowPoints);
    }

    public void Score_Med()
    {
        ScoreManager.AddScore(medPoints);

    }

    public void Score_High()
    {
        ScoreManager.AddScore(highPoints);

    }
}
