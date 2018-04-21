using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class Heavy_Guns : MonoBehaviour
{
    public List<GameObject> listOfRocketObjects;
    public float launchForce;
    private Players myTarget;
    private GameObject rocketCache;
    
    private GameObject rocketCapCache;
    private Pool myPool;
    private Coroutine shootCoroutine;
    public event Action OnReload;
    public event Action OnShoot;
    public event Action OnReloadComplete; 
    public float reloadRate;
    public Coroutine reloadCoroutine;
    private bool isReloading;

    void Awake()
    {
        myTarget = FindObjectOfType<Players>();
        myPool = FindObjectOfType<Pool>();

    }

    // Use this for initialization
	void Start ()
	{
	    OnReload += Reload;

	}
	
	// Update is called once per frame
	void Update ()
	{
	   // if (Input.GetKeyDown(KeyCode.Space))
	    {
            Shoot(6);
	    }
	}

    public IEnumerator ShootRoutine(int ammountOfRockets)
    {
        for (int i = 0; i < ammountOfRockets; i++)
        {
            if(isReloading) continue;
            rocketCapCache = listOfRocketObjects.Find((a) => a.activeInHierarchy);
            if (rocketCapCache != null)
            {
                rocketCache = myPool.Give_Missile();
                rocketCache.transform.position = rocketCapCache.transform.position;
                rocketCache.transform.rotation = rocketCapCache.transform.rotation;
               // rocketCache.transform.rotation = Quaternion.AngleAxis(-45, new Vector3(1, 0, 0));

                rocketCapCache.SetActive(false);
                rocketCache.SetActive(true);
                rocketCache.GetComponent<Missile>().Fly(launchForce);
                if (OnShoot != null) OnShoot();
            }
            else
            {
                if (OnReload != null) OnReload();
                yield return null;
            }

            yield return new WaitForSeconds(Random.Range(0.2f,2));
        }

        shootCoroutine = null;
        yield return null;
    }



    public void Shoot(int ammountOfRockets)
    {
        if(shootCoroutine!=null || reloadCoroutine!=null) return;
        shootCoroutine = StartCoroutine(ShootRoutine(ammountOfRockets));

    }

    public void Reload()
    {
        if(reloadCoroutine!=null) return;
        isReloading = true;

        reloadCoroutine = StartCoroutine(ReloadEnumerator());
    }

    public IEnumerator ReloadEnumerator()
    {
        float waitPerMissile = (reloadRate-1) / 6;

        for (int i = 0; i < listOfRocketObjects.Count; i++)
        {
            listOfRocketObjects[i].SetActive(true);
            yield return new WaitForSeconds(waitPerMissile);
        }
        yield return new WaitForSeconds(1);
        isReloading = false;
        if (OnReloadComplete != null) OnReloadComplete();
        reloadCoroutine = null;
        yield return null;
    }

}
