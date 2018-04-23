using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Explosion_Sound explosionSound;

    private void OnEnable()
    {
        explosionSound = this;
    }

    public void PlayExplosionSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos);
    }
}
