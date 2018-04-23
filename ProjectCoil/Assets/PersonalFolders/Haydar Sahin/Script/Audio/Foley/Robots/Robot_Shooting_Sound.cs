using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Shooting_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Robot_Shooting_Sound robotShootingSound;

    private void OnEnable()
    {
        robotShootingSound = this;
    }

    public void PlayRobotShootingSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos);
    }
}
