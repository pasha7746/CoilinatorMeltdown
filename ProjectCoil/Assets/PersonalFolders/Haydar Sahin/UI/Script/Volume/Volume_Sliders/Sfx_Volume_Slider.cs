using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx_Volume_Slider : MonoBehaviour
{
    public void SetSfxVolume(float volume)
    {
        Volume_Manager.volumeBoss.SetVolume(volume, Volume_Manager.AudioType.Sfx);
    }
}
