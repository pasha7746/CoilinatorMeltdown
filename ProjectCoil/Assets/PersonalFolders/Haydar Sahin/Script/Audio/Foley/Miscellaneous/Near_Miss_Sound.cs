using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Near_Miss_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Near_Miss_Sound nearMissSound;

    private void OnEnable()
    {
        nearMissSound = this;
    }

    public void PlayNearMissSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos);
    }
}
