using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    public GameObject nextMenu;
    public GameObject thisMenu;
    public AudioClip sound;
    private Button button;

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
        Volume_Manager.volumeBoss.Play2DSfx(sound);
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
