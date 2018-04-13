using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator myAnimation;
    public bool isReloading;

    public enum State
    {
        Reload,
        Fire
    }


    void Awake()
    {
        myAnimation = GetComponentInChildren<Animator>();
        
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
                Reload();
                break;
            case State.Fire:
                Fire();
                break;
            default:
                throw new ArgumentOutOfRangeException("selectAnimation", selectAnimation, null);
        }


    }

    public void Reload()
    {
        myAnimation.GetCurrentAnimatorStateInfo(0).IsName("Reload");
        if (isReloading)
        {
            myAnimation.SetBool("isReloading" , false);
        }
        else
        {
            myAnimation.SetBool("isReloading", true);
        }

        isReloading = !isReloading;
        
    }

    public void Fire()
    {
        myAnimation.SetTrigger("TriggerShoot");
    }

}
