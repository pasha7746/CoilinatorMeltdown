using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectMenuSinglePlayer : MonoBehaviour
{
    public GameObject[] menuIconsThatAreEnabled;
    public GameObject[] player1Classes;
    public SinglePlayerClassSelect player1;
    private void OnEnable()
    {
        if (menuIconsThatAreEnabled == null)
        {
            Debug.Log("Please Give my things that should always start active");
        }
        else
        {
            foreach (GameObject go in menuIconsThatAreEnabled)
            {
                go.SetActive(true);
            }
        }

        if (player1 != null && player1Classes != null)
        {
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
        }

        if (player1 == null)
        {
            Debug.Log("Wheres the player select");
        }

        if (player1Classes == null)
        {
            Debug.Log("What classes am I");
        }
    }
}
