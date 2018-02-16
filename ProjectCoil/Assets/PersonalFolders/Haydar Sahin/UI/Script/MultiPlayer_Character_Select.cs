using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ignoring until Pasha is here
/// </summary>
public class MultiPlayer_Character_Select : MonoBehaviour
{
    public event Action<GameObject> DoReady;
    public Class_Switch assault;
    public Button button;
    public GameObject ready;
    public GameObject player;
    public GameObject thisButton;
    public void OnEnable()
    {
        if (button != null)
        {
            button.onClick.AddListener(EventListener);
        }
    }

    private void EventListener()
    {
        assault.OnClassSwitch += StorePlayer;
    }

    private void StorePlayer()
    {
        if (DoReady != null && player != null)
        {
            DoReady(player);
            //ReadyUp();
        }
        //this one is for quick testing
        ReadyUp();
    }

    private void ReadyUp()
    {

        if (ready != null && thisButton != null)
        {
            ready.SetActive(true);
            thisButton.SetActive(false);
        }
    }
}
