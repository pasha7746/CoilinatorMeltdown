using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerClassSelect : MonoBehaviour
{
    public Class_Switch change;
    public Class_Switch change1;
    public Button button;
    public GameObject nextMenu;
    public GameObject thisMenu;
    public int presentClass = 0;
    public void OnEnable()
    {
        change.OnClassSwitch += PresentClassAdd;
        change1.OnClassSwitch += PresentClassAdd;
        if (button != null)
        {
            button.onClick.AddListener(StorePlayer);
        }
    }

    private void PresentClassAdd()
    {
        presentClass++;
        if (presentClass >= Enum.GetNames(typeof(CharacterClasses.Classes)).Length)
        {
            presentClass = 0;
        }
    }

    private void StorePlayer()
    {
        SaveClass();
        //this one is for quick testing
        //ReadyUp();
    }

    private void SaveClass()
    {
        Hand.leftHand = Hand.rightHand = (CharacterClasses.Classes)presentClass;
        ReadyUp();
    }
    private void ReadyUp()
    {
        if (nextMenu != null && thisMenu != null)
        {
            nextMenu.SetActive(true);
            thisMenu.SetActive(false);
        }
    }

    private void OnDisable()
    {
        change.OnClassSwitch -= StorePlayer;
        change1.OnClassSwitch -= StorePlayer;
    }
}
