using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Resume_Sound resumeSound;

    private void OnEnable()
    {
        resumeSound = this;
    }

    public void PlayResumeSound()
    {
        Volume_Manager.volumeBoss.Play2DSfx(audioSounds);
    }
}
