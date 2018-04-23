using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_Volume_Slider : MonoBehaviour
{
    public Slider thisSlider;
    private void Start()
    {
        thisSlider.value = Volume_Manager.volumeBoss.MusicVolume;
    }
    public void SetMusicVolume(float volume)
    {
        Volume_Manager.volumeBoss.SetVolume(volume, Volume_Manager.AudioType.Music);
    }
}
