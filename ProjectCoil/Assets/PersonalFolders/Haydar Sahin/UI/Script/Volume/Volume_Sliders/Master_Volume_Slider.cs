using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Volume_Slider : MonoBehaviour
{
    public void SetMasterVolume(float volume)
    {
        Volume_Manager.volumeBoss.SetVolume(volume,Volume_Manager.AudioType.Master);
    }
}
