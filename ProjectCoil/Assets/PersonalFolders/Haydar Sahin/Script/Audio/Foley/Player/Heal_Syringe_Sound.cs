using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Syringe_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Heal_Syringe_Sound healSyringeSound;

    private void OnEnable()
    {
        healSyringeSound = this;
    }

    public void PlayHealSyringeSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos);
    }
}
