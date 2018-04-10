﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    private Button button;
    public AudioClip sound;
    private void OnEnable()
    {
        button = this.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(QuitGame);
        }
    }

    private void QuitGame()
    {
        Volume_Manager.volumeBoss.Play2DSfx(sound);
        Application.Quit();
    }
}
