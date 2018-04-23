using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Teleport_Sound teleportSound;

    private void OnEnable()
    {
        teleportSound = this;
    }

    public void PlayTeleportSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos);
    }
}
