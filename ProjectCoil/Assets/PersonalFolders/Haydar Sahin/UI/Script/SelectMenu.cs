using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    public GameObject nextMenu;
    public GameObject thisMenu;

    public Button button;

	// Use this for initialization
	public virtual void OnEnable()
    {
        if (button != null)
        {
            button.onClick.AddListener(StartGame);
        }
	}

    public void StartGame()
    {
        if (nextMenu != null && thisMenu != null)
        {
            nextMenu.SetActive(true);
            thisMenu.SetActive(false);
        }
        //SceneManager.LoadScene(1);
    }
}
