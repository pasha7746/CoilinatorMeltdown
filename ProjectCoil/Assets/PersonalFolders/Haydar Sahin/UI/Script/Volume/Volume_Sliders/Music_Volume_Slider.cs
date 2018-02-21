using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Volume_Slider : MonoBehaviour
{
    public void SetMusicVolume(float volume)
    {
        Volume_Manager.volumeBoss.SetVolume(volume, Volume_Manager.AudioType.Music);
    }
}
