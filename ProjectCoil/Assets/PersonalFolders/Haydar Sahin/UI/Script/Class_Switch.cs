using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ignoring until Pasha is here
/// </summary>
public class Class_Switch : MonoBehaviour
{
    public event Action OnClassSwitch;
    public GameObject nextClass;
    public GameObject thisClass;

    public Button button;

    // Use this for initialization
    public virtual void OnEnable()
    {
        if (OnClassSwitch != null)
        {
            OnClassSwitch();
        }
        if (button != null)
        {
            button.onClick.AddListener(StartGame);
        }
    }

    public void StartGame()
    {
        if (nextClass != null && thisClass != null)
        {
            nextClass.SetActive(true);
            thisClass.SetActive(false);
        }
        //SceneManager.LoadScene(1);
    }
}
