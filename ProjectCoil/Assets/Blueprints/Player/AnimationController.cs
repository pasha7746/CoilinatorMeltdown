using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator myAnimation;
    public bool isReloading;
    public bool isFiring;

    public enum State
    {
        Reload,
        Fire
    }


    void Awake()
    {
        myAnimation = GetComponent<Animator>();
        
    }

    // Use this for initialization
	void Start ()
	{
	    isReloading = false;

    }
	
    public void Play(State selectAnimation)
    {
        switch (selectAnimation)
        {
            case State.Reload:
                Reload(0);
                break;
            case State.Fire:
                Fire(0);
                break;
            default:
                throw new ArgumentOutOfRangeException("selectAnimation", selectAnimation, null);
        }


    }
    

    public void Reload(int index)
    {
       
        if (index==1)
        {
            myAnimation.SetBool("isReloading", false);
            isReloading = false;
        }
        else
        {
            myAnimation.SetBool("isReloading", true);
            isReloading = true;
        }

    }

    public void Fire(int index)
    {
        if (index == 0)
        {
            isFiring = true;
            myAnimation.SetTrigger("TriggerShoot");
        }
        else
        {
            isFiring = false;
        }
    }

}
