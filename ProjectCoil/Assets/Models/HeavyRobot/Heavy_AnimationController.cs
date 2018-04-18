using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Heavy_AnimationController : MonoBehaviour
{
    private Animator myAnimator;
    public event Action OnDeathAnimDone; 


    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public enum States
    {
        Stop,
        MoveForwards,
        Shoot,
        Death
    }

    public bool isShooting;
    public bool isMoving;

    // Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    public void Play(States animation)
    {
        switch (animation)
        {
            case States.MoveForwards:
                MoveForward();
                break;
            case States.Shoot:
                Shoot(0);
                break;
            case States.Death:
                Death();
                break;
            case States.Stop:
                Stop();
                break;
            default:
                throw new ArgumentOutOfRangeException("animation", animation, null);
        }
    }

    public void MoveForward()
    {
        isMoving = true;
        myAnimator.SetBool("isMoving", true);
    }

    public void Stop()
    {
        isMoving = false;
        myAnimator.SetBool("isMoving", false);
    }

    public void Shoot(int index)
    {
        if (index == 0)
        {
            
            isShooting = true;
            myAnimator.SetTrigger("TriggerShoot");
        }
        else
        {
            isShooting = false;
        }
    }

    public void Death()
    {
        myAnimator.SetTrigger("TriggerOnDeath");
    }

    public void DeathAnimationDone()
    {
        if (OnDeathAnimDone != null) OnDeathAnimDone();
    }

}
