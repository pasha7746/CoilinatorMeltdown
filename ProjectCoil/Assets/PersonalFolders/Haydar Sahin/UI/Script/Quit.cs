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

        else
        {
            Debug.Log("There is no button. Please button me up");
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
