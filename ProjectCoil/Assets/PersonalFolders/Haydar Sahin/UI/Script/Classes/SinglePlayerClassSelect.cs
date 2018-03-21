using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerClassSelect : MonoBehaviour
{
    
    public Class_Switch[] changes;
    public Button button;
    public GameObject nextMenu;
    public GameObject thisMenu;
    public int presentClass = 0;
    public void OnEnable()
    {
        if (changes != null)
        {
            switch (presentClass)
            {
                case 0:
                    changes[0].OnClassSwitch += PresentClassAdd;
                    changes[1].OnClassSwitch -= PresentClassAdd;
                    break;
                case 1:
                    changes[0].OnClassSwitch -= PresentClassAdd;
                    changes[1].OnClassSwitch += PresentClassAdd;
                    break;
            }
        }
        else
        {
            Debug.Log("What things am I changing though?");
        }
        if (button != null)
        {
            button.onClick.AddListener(StorePlayer);
        }
        else
        {
            Debug.Log("There is no button. Please button me up");
        }
    }

    private void PresentClassAdd()
    {
        presentClass++;
        changes[0].OnClassSwitch -= PresentClassAdd;
        changes[1].OnClassSwitch += PresentClassAdd;
        if (presentClass >= Enum.GetNames(typeof(CharacterClasses.Classes)).Length)
        {
            presentClass = 0;
            changes[0].OnClassSwitch += PresentClassAdd;
            changes[1].OnClassSwitch -= PresentClassAdd;
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

        if (nextMenu == null)
        {
            Debug.Log("Who's next?");
        }
        if (thisMenu == null)
        {
            Debug.Log("Where am I?");
        }
    }

    private void OnDisable()
    {
        if (changes != null)
        {
            changes[0].OnClassSwitch -= StorePlayer;
            changes[1].OnClassSwitch -= StorePlayer;
        }
        else
        {
            Debug.Log("What things am I changing though?");
        }
    }
}
