using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject UIRig;
    public GameObject gameRig;
    public GameObject pauseMenu;
    public static Pause pause;
    public bool isPaused;
	// Use this for initialization
	void Start ()
	{
	    isPaused = false;
	    Time.timeScale = 1;
	    gameRig.SetActive(true);
	    UIRig.SetActive(false);
	}

    private void Update()
    {
        if (Input.GetButtonDown("MenuRight"))
        {
            PauseGame();
        }
        if (Input.GetButtonDown("MenuLeft"))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (isPaused == false)
        {
            isPaused = true;
            gameRig.SetActive(false);
            UIRig.SetActive(true);
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
