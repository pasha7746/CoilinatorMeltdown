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
    public float pasueMenuSpawnDistance;

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
            SteamVR_Camera vrCamTemp = UIRig.GetComponentInChildren<SteamVR_Camera>();  //this thing has some trouble getting the direction right

            StartCoroutine(LateUpdateOneFrame(vrCamTemp.transform.position + (vrCamTemp.transform.forward * pasueMenuSpawnDistance)));
                
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

    public IEnumerator LateUpdateOneFrame(Vector3 pos)
    {
        yield return new WaitForFixedUpdate();
        
        pauseMenu.transform.position = pos;

        yield return null;
    }
}
