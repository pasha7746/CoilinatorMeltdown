using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bool isLeft;

    public Vector3 velocity;
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 rotA;
    private Vector3 rotB;
    public Vector3 rotVelocity;
    public float doubleTapDelay;
    private Coroutine doubleTapToDropRoutine;
    private int sideButtonState;
    private bool doubleTaped;
    private bool isTapedIn;
    public event Action OnTriggerButtonLeft, OnTriggerButtonRight;
    public event Action OnSideTapLeft, OnSideTapRight;
    public event Action OnSideDoubeTapLeft, OnSideDoubleTapRight;


    // Use this for initialization
    void Start ()
	{
	    posA = transform.position;
	    rotA = transform.rotation.eulerAngles;
	}

    // Update is called once per frame
    void Update ()
    {
        CalculateRotationVelocity();
        CalculateMovementVelocity();

        if (isLeft)
        {
            LeftInput();
        }
        else
        {
            RightInput();
        }



    }

    public void LeftInput()
    {
        if (Input.GetButtonDown("TriggerButLeft"))
        {
            if (OnTriggerButtonLeft != null) OnTriggerButtonLeft();
        }
        sideButtonState = (int)Input.GetAxis("SideButtonLeft");
        if (sideButtonState == 1)
        {
            if (!isTapedIn)
            {
                if (doubleTapToDropRoutine == null)
                {
                    doubleTapToDropRoutine = StartCoroutine(DoubleTapToDropCounter());
                }
                else if (doubleTaped)
                {
                    doubleTaped = false;
                    StopCoroutine(doubleTapToDropRoutine);
                    doubleTapToDropRoutine = null;
                    if (OnSideDoubeTapLeft != null) OnSideDoubeTapLeft();
                }
                
                    if (OnSideTapLeft != null) OnSideTapLeft();

                
            }
            isTapedIn = true;
        }
        else
        {
            if (isTapedIn)
            {
                if (doubleTapToDropRoutine != null)
                {
                    doubleTaped = true;
                }
                else
                {
                    doubleTaped = false;
                }
            }
            isTapedIn = false;

        }

    }

    public void RightInput()
    {
        if (Input.GetButtonDown("TriggerButRight"))
        {
            if (OnTriggerButtonRight != null) OnTriggerButtonRight();
        }
        sideButtonState = (int)Input.GetAxis("SideButtonRight");

        if (sideButtonState == 1)
        {
            if (!isTapedIn)
            {
                if (doubleTapToDropRoutine == null)
                {
                    doubleTapToDropRoutine = StartCoroutine(DoubleTapToDropCounter());
                }
                else if (doubleTaped)
                {
                    doubleTaped = false;
                    StopCoroutine(doubleTapToDropRoutine);
                    doubleTapToDropRoutine = null;
                    if (OnSideDoubleTapRight != null) OnSideDoubleTapRight();
                }
               
                if (OnSideTapRight != null) OnSideTapRight();
                
            }
            isTapedIn = true;
        }
        else
        {
            if (isTapedIn)
            {
                if (doubleTapToDropRoutine != null)
                {
                    doubleTaped = true;
                }
                else
                {
                    doubleTaped = false;
                }
            }
            isTapedIn = false;

        }
    }



    public void CalculateMovementVelocity()
    {
        posB = transform.position;
        velocity = -((posA - posB) / Time.deltaTime);
        posA = posB;
    }

    public void CalculateRotationVelocity()
    {
        rotB = transform.rotation.eulerAngles;
        rotVelocity = -((rotA - rotB) / Time.deltaTime);
        


        rotA = rotB;
    }
    public IEnumerator DoubleTapToDropCounter()
    {

        yield return new WaitForSeconds(doubleTapDelay);
        doubleTapToDropRoutine = null;
        yield return null;
    }
}
