using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Co_OpNext : MonoBehaviour
{
    public GameObject PlayerMenu;
    public GameObject thisMenu;
    public Button button;

    public void OnEnable()
    {
        if (button != null)
        {
            button.onClick.AddListener(StartGame);
        }
    }

    private void StartGame()
    {
        if (PlayerMenu != null && thisMenu != null)
        {
            PlayerMenu.SetActive(true);
            thisMenu.SetActive(false);
        }
    }
}
