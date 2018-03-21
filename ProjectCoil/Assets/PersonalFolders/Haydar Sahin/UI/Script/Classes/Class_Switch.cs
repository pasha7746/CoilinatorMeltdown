using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Class_Switch : MonoBehaviour
{
    public event Action OnClassSwitch;
    public GameObject nextClass;
    public GameObject thisClass;

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
        if (nextClass != null && thisClass != null)
        {
            if (OnClassSwitch != null)
            {
                OnClassSwitch();
            }
            nextClass.SetActive(true);
            thisClass.SetActive(false);
        }

        if (nextClass == null)
        {
            Debug.Log("Who's next?");
        }
        if (thisClass == null)
        {
            Debug.Log("Where am I?");
        }
        //SceneManager.LoadScene(1);
    }
}
