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
    }

    void StartGame()
    {
        if (levelName != null || levelName != " ")
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
