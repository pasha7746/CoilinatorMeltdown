using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSound : MonoBehaviour
{
    #region auto
    public AudioClip[] audioSounds;
    #endregion
    public float minSoundTimer = 0.0f;
    public float maxSoundTimer = 1.0f;
    private Coroutine timerCoroutine;
    public int callCheck = 0;
    public static DebrisSound debrisSound;

    private void OnEnable()
    {
        debrisSound = this;
    }

    /// <summary>
    /// call for random sound
    /// </summary>
    public void Timer(Vector3 pos)
    {
        callCheck++;
        float soundTimer1 = Random.Range(minSoundTimer, maxSoundTimer);
        float soundTimer2 = Random.Range(minSoundTimer, maxSoundTimer);
        float soundTimer3 = Random.Range(minSoundTimer, maxSoundTimer);
        float soundTimer4 = Random.Range(minSoundTimer, maxSoundTimer);
        bool soundPlayed1 = false;
        bool soundPlayed2 = false;
        bool soundPlayed3 = false;
        bool soundPlayed4 = false;
        bool hasImpacted = false;
        float timer = 0.0f;
        timerCoroutine = StartCoroutine(TimerRoutine(pos, timer, soundTimer1, soundTimer2, soundTimer3,
            soundTimer4, soundPlayed1, soundPlayed2, soundPlayed3, soundPlayed4, hasImpacted));
    }

    public IEnumerator TimerRoutine(Vector3 pos, float timer, float soundTimer1, float soundTimer2,
        float soundTimer3, float soundTimer4, bool soundPlayed1, bool soundPlayed2, bool soundPlayed3,
        bool soundPlayed4, bool hasImpacted)
    {
        while (hasImpacted == false)
        {
            timer += Time.deltaTime;
            if (timer >= soundTimer1 && soundPlayed1 == false)
            {
                soundPlayed1 = true;
                Impact(pos);
            }
            if (timer >= soundTimer2 && soundPlayed2 == false)
            {
                soundPlayed2 = true;
                Impact(pos);
            }
            if (timer >= soundTimer3 && soundPlayed3 == false)
            {
                soundPlayed3 = true;
                Impact(pos);
            }
            if (timer >= soundTimer4 && soundPlayed4 == false)
            {
                soundPlayed4 = true;
                Impact(pos);
            }

            if (timer > soundTimer1 && timer > soundTimer2 && timer > soundTimer3 && timer > soundTimer4)
            {
                hasImpacted = true;
            }
        }

        yield return null;
    }

    protected void Impact(Vector3 pos)
    {
        int picker = Random.Range(0, audioSounds.Length - 1);
        #region picker Auto type test
        print(picker);
        Volume_Manager.volumeBoss.PlaySfx(audioSounds[picker], pos);
        //sounds[picker].SetActive(true);
        #endregion
    }
}
