using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    public GameObject thisMenu;
    public AudioClip buttonClick;
    public AudioClip resumeSound;
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
        Volume_Manager.volumeBoss.Play2DSfx(buttonClick);
        if (thisMenu != null)
        {
            thisMenu.SetActive(false);
            Volume_Manager.volumeBoss.Play2DSfx(resumeSound);
        }
        
        if (thisMenu == null)
        {
            Debug.Log("Where am I?");
        }
        //SceneManager.LoadScene(1);
    }
}
