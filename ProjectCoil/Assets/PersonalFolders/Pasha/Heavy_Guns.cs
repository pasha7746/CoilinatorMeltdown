using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

public class Heavy_Guns : MonoBehaviour
{
    public List<GameObject> listOfRocketObjects;
    public float launchForce;
    private Players myTarget;
    private GameObject rocketCache;
    
    private GameObject rocketCapCache;
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
            Shoot(3);
	    }
	}

    


    public void Shoot(int ammountOfRockets)
    {
        
        for (int i = 0; i < ammountOfRockets; i++)
        {
            rocketCapCache = listOfRocketObjects.Find((a) => a.activeInHierarchy);
            if (rocketCapCache!=null)
            {
                rocketCache = myPool.Give_Missile();
                rocketCache.transform.position = rocketCapCache.transform.position;
                rocketCache.transform.rotation = rocketCapCache.transform.rotation;
                rocketCache.transform.rotation = Quaternion.AngleAxis(-45, new Vector3(1,0,0));

                rocketCapCache.SetActive(false);
                rocketCache.SetActive(true);
                rocketCache.GetComponent<Missile>().Fly(launchForce);
               
            }
            else
            {
                Reload();
            }

            
        }
        
    }

    public void Reload()
    {

    }
}
