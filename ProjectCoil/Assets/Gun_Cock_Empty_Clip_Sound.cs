using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Cock_Empty_Clip_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Gun_Cock_Empty_Clip_Sound gunCockEmptyClipSound;

    private void OnEnable()
    {
        gunCockEmptyClipSound = this;
    }

    public void PlayGunCockEmptyClipSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos);
    }
}
