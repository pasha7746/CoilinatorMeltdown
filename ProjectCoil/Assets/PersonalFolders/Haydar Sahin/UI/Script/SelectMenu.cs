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
        else
        {
            Debug.Log("There is no button. Please button me up");
        }
	}

    public void StartGame()
    {
        if (nextMenu != null && thisMenu != null)
        {
            nextMenu.SetActive(true);
            thisMenu.SetActive(false);
        }

        if (nextMenu == null)
        {
            Debug.Log("Who's next?");
        }
        if (thisMenu == null)
        {
            Debug.Log("Where am I?");
        }
        //SceneManager.LoadScene(1);
    }
}
