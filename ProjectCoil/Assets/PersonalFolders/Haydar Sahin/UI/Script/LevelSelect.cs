using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button button;

    public string levelName;
    // Use this for initialization
    void OnEnable()
    {
        if (button != null)
        {
            button.onClick.AddListener(StartGame);
        }

        else
        {
            Debug.Log("There is no button. Please button me up");
        }
    }

    void StartGame()
    {
        if (levelName != null || levelName != " ")
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.Log("What Level?");
        }
    }
}
