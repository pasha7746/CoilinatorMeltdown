using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    public GameObject thisMenu;
    public Button button;
    public GameObject UIRig;
    public GameObject gameRig;

    // Use this for initialization
    public virtual void OnEnable()
    {
        button = GetComponent<Button>();
        Time.timeScale = 0;
        gameRig.SetActive(false);
        UIRig.SetActive(true);
        if (button != null)
        {
            button.onClick.AddListener(StartGame);
        }
    }

    public void StartGame()
    {
        Button_Sound.buttonSound.PlayButtonSound();
        if (thisMenu != null)
        {
            Time.timeScale = 1;
            gameRig.SetActive(true);
            UIRig.SetActive(false);
            thisMenu.SetActive(false);
            Resume_Sound.resumeSound.PlayResumeSound();
        }
        
        if (thisMenu == null)
        {
            Debug.Log("Where am I?");
        }
        //SceneManager.LoadScene(1);
    }
}
