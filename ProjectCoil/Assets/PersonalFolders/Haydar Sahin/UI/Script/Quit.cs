using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public Button button;
    private void OnEnable()
    {
        if (button != null)
        {
            button.onClick.AddListener(QuitGame);
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
