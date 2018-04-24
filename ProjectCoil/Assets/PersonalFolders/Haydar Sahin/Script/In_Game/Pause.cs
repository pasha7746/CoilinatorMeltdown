using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject UIRig;
    public GameObject gameRig;
    public Pause_Menu pauseMenu;

    public static Pause pause;
	// Use this for initialization
	void Start ()
	{
	    Time.timeScale = 1;
	    gameRig.SetActive(true);
	    UIRig.SetActive(false);
	}

    public void PauseGame()
    {
        gameRig.SetActive(false);
        UIRig.SetActive(true);
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
