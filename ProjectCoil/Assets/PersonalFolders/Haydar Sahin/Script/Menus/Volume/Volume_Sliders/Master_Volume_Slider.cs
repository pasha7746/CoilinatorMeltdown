using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master_Volume_Slider : MonoBehaviour
{
    private Slider thisSlider;
    private void Start()
    {
        thisSlider = GetComponentInChildren<Slider>();
        thisSlider.value = Volume_Manager.volumeBoss.masterVolume;
        print(thisSlider.value);
    }
    public void SetMasterVolume(float volume)
    {
        Volume_Manager.volumeBoss.SetVolume(volume,Volume_Manager.AudioType.Master);
    }
}
