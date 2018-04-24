﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Background_Music : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] music;

    // Use this for initialization
    void Start ()
	{
		Volume_Manager.volumeBoss.PlayMusic(music[0], 2);
    }

    private void OnEnable()
    {
        masterManager.mySpawnController.OnBarricadeComplete += Relax;
        Screen_Change.screenChange.OnTelepotFinised += BattleMusic;
    }

    private void BattleMusic()
    {
        Volume_Manager.volumeBoss.PlayMusic(music[0], 2);
    }

    private void Relax()
    {
        Volume_Manager.volumeBoss.PlayMusic(music[1], 2);
    }

    private void OnDisable()
    {
        masterManager.mySpawnController.OnBarricadeComplete -= Relax;
        Screen_Change.screenChange.OnTelepotFinised -= BattleMusic;
    }
}
