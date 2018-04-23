using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Turning_Sound : MonoBehaviour
{

    public AudioClip audioSounds;
    public static Gear_Turning_Sound gearTurningSound;

    private void OnEnable()
    {
        gearTurningSound = this;
    }

    public void PlayGearTurningSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos); ;
    }
}
