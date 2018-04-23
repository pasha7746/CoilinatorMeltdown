using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScoreDisplay : MonoBehaviour
{
    private Text myText;

    void Awake()
    {
        myText = GetComponent<Text>();
    }

    // Use this for initialization
	void Start ()
	{
	    StartCoroutine(ScoreUpdater());
	}

    public IEnumerator ScoreUpdater()
    {
        while (true)
        {
            myText.text = "Score: "+ScoreManager.gameScore.ToString();
            yield return new WaitForSeconds(1f);
            yield return null;
        }

        yield return null;
    }

}
