using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject UIRig;
    public GameObject gameRig;
    public GameObject pauseMenu;

    private PauseMenuAnchor myAnchor;
   // public static Pause pause;
    public bool isPaused;
    public float pasueMenuSpawnDistance;
    private bool noPauseMenu;

	// Use this for initialization
	void Start ()
	{
	    isPaused = false;
	    Time.timeScale = 1;
	    if (gameRig == null)
	    {
            print("No pause menu prefab");
            return;
	    }
	    gameRig.SetActive(true);
	    UIRig.SetActive(false);
	    myAnchor = MasterManager.player.GetComponentInChildren<PauseMenuAnchor>();
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
       if(!gameRig) return;
        if (isPaused == false)
        {
            isPaused = true;
            gameRig.SetActive(false);
            pauseMenu.transform.position = myAnchor.transform.position;
            pauseMenu.transform.rotation = myAnchor.transform.rotation;   
            //pauseMenu.transform.LookAt(vrCamTemp.transform.position);
            
            UIRig.SetActive(true);
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            gameRig.SetActive(true);
            UIRig.SetActive(false);
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

   
}
