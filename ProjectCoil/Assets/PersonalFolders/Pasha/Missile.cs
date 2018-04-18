using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Missile : MonoBehaviour
{
    public float liveTime;
    private Coroutine liveTimer;
    private Coroutine explosionTimer;
    public event Action<GameObject> OnDeath;
    public Vector3 centerOfMass;
    public float blastRadius;
    private MeshRenderer myMeshRenderer;
    private ExplosionsCollection myExplosionsCollection;
    private GameObject explosionCache;
    public GameObject target;

    void Awake()
    {
        myMeshRenderer = GetComponentInChildren<MeshRenderer>();
        myExplosionsCollection = GetComponentInChildren<ExplosionsCollection>();
    }

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
    }

    void OnEnable()
    {
        if (liveTimer != null)
        {
            StopAllCoroutines();
        }

        liveTimer= StartCoroutine(LiveCountdown());
    }

    public IEnumerator LiveCountdown()
    {
        yield return new WaitForSeconds(liveTime);
        if (OnDeath != null) OnDeath(gameObject);
        yield return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerTrigger>() || other.GetComponent<RobotPieceBreak>() || !other.isTrigger)
        {
            Explode();
        }
       
    }

    public void Explode()
    {
        myMeshRenderer.enabled = false;
        explosionCache = myExplosionsCollection.listOfExplosions[Random.Range(0, myExplosionsCollection.listOfExplosions.Count - 1)];
        explosionCache.SetActive(true);
        explosionCache.transform.parent = null;
        explosionCache.transform.position = transform.position;
        explosionTimer = StartCoroutine(ExplosionCountdown());
        
    }

    public IEnumerator ExplosionCountdown()
    {
        yield return new WaitForSeconds(liveTime);
        explosionCache.SetActive(false);
    }

    public void AreaDamage()
    {

    }


}
