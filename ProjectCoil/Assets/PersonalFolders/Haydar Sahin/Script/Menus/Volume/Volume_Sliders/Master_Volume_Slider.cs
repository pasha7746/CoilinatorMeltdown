using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master_Volume_Slider : MonoBehaviour
{
    public Slider thisSlider;
    private void Start()
    {
        thisSlider.value = Volume_Manager.volumeBoss.masterVolume;
    }
    public void SetMasterVolume(float volume)
    {
        Volume_Manager.volumeBoss.SetVolume(volume,Volume_Manager.AudioType.Master);
    }
}
