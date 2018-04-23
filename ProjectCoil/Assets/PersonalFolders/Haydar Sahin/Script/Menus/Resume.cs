using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    public GameObject thisMenu;
    public Button button;

    // Use this for initialization
    public virtual void OnEnable()
    {
        button = this.GetComponent<Button>();
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
