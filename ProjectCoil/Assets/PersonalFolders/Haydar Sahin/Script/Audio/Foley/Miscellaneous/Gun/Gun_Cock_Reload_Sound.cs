using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Cock_Reload_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Gun_Cock_Reload_Sound gunCockReloadSound;

    private void OnEnable()
    {
        gunCockReloadSound = this;
    }

    public void PlayGunCockReloadSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos);
    }
}
