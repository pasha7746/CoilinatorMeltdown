using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSound : MonoBehaviour
{
    public GameObject sound1;
    public GameObject sound2;
    public GameObject sound3;
    public GameObject sound4;
    public GameObject sound5;
    public GameObject sound6;
    public GameObject sound7;
    public GameObject sound8;
    public GameObject sound9;
    public GameObject sound10;
    public bool hasImpacted = false;
    public float timer = 0.0f;
    public float minSoundTimer = 0.0f;
    public float maxSoundTimer = 1.0f;
    public float soundTimer1, soundTimer2, soundTimer3, soundTimer4;
    protected bool havePlayed = false;
    protected int playedAmount = 0;
    protected GameObject mySelf;
    private Coroutine timerCoroutine;


    public virtual void OnEnable()
    {
        mySelf = GetComponent<GameObject>();
        soundTimer1 = Random.Range(minSoundTimer, maxSoundTimer);
        soundTimer2 = Random.Range(minSoundTimer, maxSoundTimer);
        soundTimer3 = Random.Range(minSoundTimer, maxSoundTimer);
        soundTimer4 = Random.Range(minSoundTimer, maxSoundTimer);
        timer = 0.0f;
    }

    public void Timer()
    {
        timerCoroutine = StartCoroutine(TimerRoutine());
    }

    public IEnumerator TimerRoutine()
    {
        while (true)
        {
            timer += Time.deltaTime;
            if (timer == soundTimer1 || timer == soundTimer2 || timer == soundTimer3 || timer == soundTimer4)
            {
                Impact();
            }
                yield return null;
        }

        yield return null;
    }

    protected void Impact()
    {
        int picker = Random.Range(0, 28);
        switch (picker)
        {
            case 0:
            case 10:
            case 20:
                sound1.SetActive(true);
                playedAmount++;
                break;
            case 1:
            case 11:
            case 21:
                sound2.SetActive(true);
                playedAmount++;
                break;
            case 2:
            case 12:
            case 22:
                sound3.SetActive(true);
                playedAmount++;
                break;
            case 3:
            case 13:
            case 23:
                sound4.SetActive(true);
                playedAmount++;
                break;
            case 4:
            case 14:
            case 24:
                sound5.SetActive(true);
                playedAmount++;
                break;
            case 5:
            case 15:
            case 25:
                sound6.SetActive(true);
                playedAmount++;
                break;
            case 6:
            case 16:
            case 26:
                sound7.SetActive(true);
                playedAmount++;
                break;
            case 7:
            case 17:
            case 27:
                sound8.SetActive(true);
                playedAmount++;
                break;
            case 8:
            case 18:
            case 28:
                sound9.SetActive(true);
                playedAmount++;
                break;
            case 9:
            case 19:
            default:
                if (sound10 != null)
                {
                    sound10.SetActive(true);
                    playedAmount++;
                    break;
                }
                else
                {
                    sound9.SetActive(true);
                    playedAmount++;
                    break;
                }
        }
    }

    public virtual void OnDisable()
    {
    }
}
