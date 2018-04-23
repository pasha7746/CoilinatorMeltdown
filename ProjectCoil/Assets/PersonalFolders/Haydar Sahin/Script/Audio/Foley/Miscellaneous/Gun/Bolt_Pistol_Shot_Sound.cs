using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt_Pistol_Shot_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Bolt_Pistol_Shot_Sound BoltPistolShotSound;

    private void OnEnable()
    {
        BoltPistolShotSound = this;
    }

    public void PlayPistolShotSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos);
    }
}
