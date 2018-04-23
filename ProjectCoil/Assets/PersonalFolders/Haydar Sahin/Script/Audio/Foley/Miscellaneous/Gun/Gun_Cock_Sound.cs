using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Cock_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Gun_Cock_Sound gunCockSound;

    private void OnEnable()
    {
        gunCockSound = this;
    }

    public void PlayGunCockSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos);
    }
}
