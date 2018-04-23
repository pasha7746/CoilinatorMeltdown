using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Engine_Rumble_Sound : MonoBehaviour
{
    public AudioClip audioSounds;
    public static Ground_Engine_Rumble_Sound groundEngineRumbleSound;

    private void OnEnable()
    {
        groundEngineRumbleSound = this;
    }

    public void PlayGroundEngineRumbleSound(Vector3 pos)
    {
        Volume_Manager.volumeBoss.PlaySfx(audioSounds, pos);
    }
}
