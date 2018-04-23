using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Button_Sound buttonSound;

    private void OnEnable()
    {
        buttonSound = this;
    }

    public void PlayButtonSound()
    {
        Volume_Manager.volumeBoss.Play2DSfx(audioSounds);
    }
}
