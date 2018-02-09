using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Co_OpNext : MonoBehaviour
{
    public ToggleScript co_opToggle;
    public GameObject singlePlayerMenu;
    public GameObject twoPlayerMenu;
    public GameObject thisMenu;
    public Button button;
    private bool co_opEnabled = false;
    public void OnEnable()
    {
        if (button != null)
        {
            button.onClick.AddListener(StartGame);
        }
        co_opToggle.OnToggledOn += Co_OpMenuTwoScreen;
        co_opToggle.OnToggledOff += Co_OpMenuSingleScreen;
    }

    private void StartGame()
    {

        if (twoPlayerMenu != null && thisMenu != null && co_opEnabled)
        {
            twoPlayerMenu.SetActive(true);
            thisMenu.SetActive(false);
        }
        if (singlePlayerMenu != null && thisMenu != null && !co_opEnabled)
        {
            singlePlayerMenu.SetActive(true);
            thisMenu.SetActive(false);
        }
    }

    private void OnDisable()
    {
        co_opToggle.OnToggledOn -= Co_OpMenuTwoScreen;
        co_opToggle.OnToggledOff -= Co_OpMenuSingleScreen;
    }

    private void Co_OpMenuTwoScreen()
    {
        co_opEnabled = true;
    }
    private void Co_OpMenuSingleScreen()
    {
        co_opEnabled = false;
    }
}
