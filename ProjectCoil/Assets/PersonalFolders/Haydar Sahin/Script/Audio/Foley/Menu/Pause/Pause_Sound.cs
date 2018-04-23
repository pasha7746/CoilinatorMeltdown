using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Pause_Sound pauseSound;

    private void OnEnable()
    {
        pauseSound = this;
    }

    public void PlayPauseSound()
    {
        Volume_Manager.volumeBoss.Play2DSfx(audioSounds);
    }
}
