using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MultiPlayer_Character_Select : MonoBehaviour
{
    public Class_Switch change;
    public Class_Switch change1;
    public Button button;
    public GameObject ready;
    public GameObject thisButton;
    public int presentClass = 0;
    public int playerNumber = 1;
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
        switch (playerNumber)
        {
            case 1:
                Hand.leftHand = (CharacterClasses.Classes)presentClass;
                ReadyUp();
                break;
            case 2:
                Hand.rightHand = (CharacterClasses.Classes)presentClass;
                ReadyUp();
                break;
        }
    }
    private void ReadyUp()
    {
        if (ready != null && thisButton != null)
        {
            ready.SetActive(true);
            thisButton.SetActive(false);
        }
    }

    private void OnDisable()
    {
        change.OnClassSwitch -= StorePlayer;
        change1.OnClassSwitch -= StorePlayer;
    }
}
