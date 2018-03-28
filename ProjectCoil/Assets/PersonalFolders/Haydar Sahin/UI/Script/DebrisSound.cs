using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSound : MonoBehaviour
{
    #region auto
    public GameObject[] sounds;
    #endregion
    #region manual
    /*public GameObject sound1;
    public GameObject sound2;
    public GameObject sound3;
    public GameObject sound4;
    public GameObject sound5;
    public GameObject sound6;
    public GameObject sound7;
    public GameObject sound8;
    public GameObject sound9;
    public GameObject sound10;*/
    #endregion
    public bool hasImpacted = false;
    public float timer = 0.0f;
    public float minSoundTimer = 0.0f;
    public float maxSoundTimer = 1.0f;
    public float soundTimer1, soundTimer2, soundTimer3, soundTimer4;
    protected bool havePlayed = false;
    protected bool soundPlayed1 = false;
    protected bool soundPlayed2 = false;
    protected bool soundPlayed3 = false;
    protected bool soundPlayed4 = false;
    protected GameObject mySelf;
    private Coroutine timerCoroutine;


    public virtual void OnEnable()
    {
        mySelf = GetComponent<GameObject>();
        soundTimer1 = Random.Range(minSoundTimer, maxSoundTimer);
        soundTimer2 = Random.Range(minSoundTimer, maxSoundTimer);
        soundTimer3 = Random.Range(minSoundTimer, maxSoundTimer);
        soundTimer4 = Random.Range(minSoundTimer, maxSoundTimer);
        soundPlayed1 = soundPlayed2 = soundPlayed3 = soundPlayed4 = false;
        timer = 0.0f;
    }

    private void OnCollisionEnter(Collision other)
    {
        Timer();
    }

    public void Timer()
    {
        timerCoroutine = StartCoroutine(TimerRoutine());
    }

    public IEnumerator TimerRoutine()
    {
        while (hasImpacted == false)
        {
            timer += Time.deltaTime;
            if ((timer >= soundTimer1 && soundPlayed1 == false)||
                (timer >= soundTimer2 && soundPlayed2 == false)||
                (timer >= soundTimer3 && soundPlayed3 == false)||
                (timer >= soundTimer4 && soundPlayed4 == false))
            {
                if (timer > soundTimer1)
                {
                    soundPlayed1 = true;
                }
                if (timer > soundTimer2)
                {
                    soundPlayed2 = true;
                }
                if (timer > soundTimer3)
                {
                    soundPlayed3 = true;
                }
                if (timer > soundTimer4)
                {
                    soundPlayed4 = true;
                }
                Impact();
            }

            if (timer > soundTimer1 && timer > soundTimer2 && timer > soundTimer3 && timer > soundTimer4)
            {
                hasImpacted = true;
            }
        }

        yield return null;
    }

    protected void Impact()
    {
        int picker = Random.Range(0, sounds.Length - 1);
        #region picker Auto type test
        sounds[picker].SetActive(true);
        #endregion
    }

    private void SetCase()
    {
        
    }

    public virtual void OnDisable()
    {
    }
}
