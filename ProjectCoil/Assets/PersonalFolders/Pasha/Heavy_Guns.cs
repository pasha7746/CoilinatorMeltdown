using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Heavy_Guns : MonoBehaviour
{
    public List<GameObject> listOfRocketObjects;
    private Players myTarget;
    public GameObject debugRocket;
    public GameObject rocketCache;
    private Pool myPool;
   
    void Awake()
    {
        myTarget = FindObjectOfType<Players>();
        myPool = FindObjectOfType<Pool>();
    }

    // Use this for initialization
	void Start ()
	{
        
	   
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            FireRocket(1);
	    }
	}

    public void FireRocket(int ammountOfRockets)
    {
        rocketCache = myPool.Give_Missile();
    }
}
