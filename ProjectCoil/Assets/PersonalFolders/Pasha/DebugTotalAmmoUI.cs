using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTotalAmmoUI : MonoBehaviour
{
    private Text myText;

    void Awake()
    {
        myText = GetComponent<Text>();

    }

    public void UpdateUI()
    {
        if (myText != null) myText.text = MasterManager.player.maxAmmo + " / " + MasterManager.player.totalAmmo;
    }

}
