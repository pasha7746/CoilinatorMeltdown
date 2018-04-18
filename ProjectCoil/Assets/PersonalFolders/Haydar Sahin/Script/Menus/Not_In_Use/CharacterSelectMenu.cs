using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectMenu : MonoBehaviour
{
    public GameObject[] menuIconsThatAreEnabled;
    public GameObject[] menuIconsThatAreDisabled;
    public MultiPlayer_Character_Select[] players;
    public GameObject[] player1Classes;
    public GameObject[] player2Classes;
    public MultiPlayer_Character_Select player1;
    public MultiPlayer_Character_Select player2;
    public GameObject[] ready;
    public GameObject thisMenu;
    public GameObject levelSelectrMenu;
    private void OnEnable()
    {
        foreach (GameObject go in menuIconsThatAreEnabled)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in menuIconsThatAreDisabled)
        {
            go.SetActive(false);
        }

        if (player1.presentClass == 0)
        {
            player1Classes[0].SetActive(true);
            player1Classes[1].SetActive(false);
        }
        if (player1.presentClass == 1)
        {
            player1Classes[0].SetActive(false);
            player1Classes[1].SetActive(true);
        }
        if (player2.presentClass == 0)
        {
            player2Classes[0].SetActive(true);
            player2Classes[1].SetActive(false);
        }
        if (player2.presentClass == 1)
        {
            player2Classes[0].SetActive(false);
            player2Classes[1].SetActive(true);
        }
    }

    // Update is called once per frame
	void Update ()
    {
        if (ready[0].activeInHierarchy == true && ready[1].activeInHierarchy == true)
        {
            
            if (levelSelectrMenu != null && thisMenu != null)
            {
                levelSelectrMenu.SetActive(true);
                thisMenu.SetActive(false);
            }
        }
	}
}
