using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_Drone_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Flying_Drone_Sound flyingDroneSound;

    private void OnEnable()
    {
        flyingDroneSound = this;
    }

    public void PlayFlyingDroneSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos);
    }
}
