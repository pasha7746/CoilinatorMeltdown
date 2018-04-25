using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    private Button button;
    public string levelName;
    // Use this for initialization
    void OnEnable()
    {

        button = this.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(StartGame);
        }
    }

    void StartGame()
    {
        Button_Sound.buttonSound.PlayButtonSound();
        if (levelName != null || levelName != " ")
        {
            if (levelName == GameState.mainLevelName)
            {
                GameState.isInGame = true;
                ScoreManager.gameScore = 0;
            }
            else
            {
                GameState.isInGame = false;
            }

            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.Log("What Level?");
        }
    }
}
