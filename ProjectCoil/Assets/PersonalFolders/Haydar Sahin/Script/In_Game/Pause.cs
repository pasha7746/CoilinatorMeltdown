using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject UIRig;
    public GameObject gameRig;

    public Pause_Menu pauseMenu;
    
	// Use this for initialization
	void Start ()
	{
	    Time.timeScale = 1;
	    gameRig.SetActive(true);
	    UIRig.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            PauseGame();
	    }
	}

    public void PauseGame()
    {
        gameRig.SetActive(false);
        UIRig.SetActive(true);
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
