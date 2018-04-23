using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Launch_Sound : MonoBehaviour
{
    public AudioClip audioSound;
    public static Rocket_Launch_Sound rocketLaunchSound;

    private void OnEnable()
    {
        rocketLaunchSound = this;
    }

    public void PlayRocketLauncherSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSound, pos);
    }
}
