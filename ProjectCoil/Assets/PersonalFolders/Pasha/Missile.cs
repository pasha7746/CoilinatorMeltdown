using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Missile : BaseHealth
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
    private Rigidbody myRigidbody;
    private Quaternion rot;
    private bool isLive;
    public float liveAfterXSec;
    public float speed;
    [HideInInspector]
    public float baseDamage;
    public event Action OnTrack; 

    void Awake()
    {
        myMeshRenderer = GetComponentInChildren<MeshRenderer>();
        myExplosionsCollection = GetComponentInChildren<ExplosionsCollection>();
        myRigidbody = GetComponent<Rigidbody>();
        
    }

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
        target = FindObjectOfType<Players>().gameObject;
        OnHit += Explode;
    }

    void Update()
    {
        if (isLive)
        {
           // transform.LookAt(target.transform.position);
           // myRigidbody.AddForce(Vector3.back * 10);
        }
        else
        {
            rot = transform.rotation;
            rot.SetLookRotation(myRigidbody.velocity);
            transform.rotation = rot;
        }
        


    }

    void OnEnable()
    {
        
        if (liveTimer != null)
        {
            StopAllCoroutines();
        }

        liveTimer= StartCoroutine(LiveCountdown());
    }

    public void Fly(float force, Vector2 controlForce)
    {
        myRigidbody.AddForce(((transform.up* controlForce.y)+ (transform.forward)* controlForce.x) * force* 10);
    }

    public IEnumerator LiveCountdown()
    {
        yield return new WaitForSeconds(liveAfterXSec);
        isLive = true;
        ////myRigidbody.useGravity = false;
        //myRigidbody.AddForce((Vector3.back + Vector3.up* 1000));
        transform.DOLookAt(target.transform.position, 0.5f);
        transform.DOMove(target.transform.position,
            Vector3.Distance(transform.position, target.transform.position) / (speed)).SetEase(Ease.Linear);
        if (OnTrack != null) OnTrack();
        yield return new WaitForSeconds(liveTime- liveAfterXSec);
        isLive = false;
        if (OnDeath != null) OnDeath(gameObject);
        yield return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!isLive) return;

       

        if (other.GetComponent<PlayerTrigger>() || other.GetComponent<RobotPieceBreak>() || !other.isTrigger)
        {
            Explode();
        }
       
    }

    public void Explode()
    {
        if (!isLive) return;
       
        myMeshRenderer.enabled = false;
        int index = Random.Range(0, myExplosionsCollection.listOfExplosions.Count - 1);
        explosionCache = myExplosionsCollection.listOfExplosions[index];
        explosionCache.SetActive(true);
        explosionCache.transform.parent = null;
        explosionCache.transform.position = transform.position;
        explosionTimer = StartCoroutine(ExplosionCountdown());
        isLive = false;
        AreaDamage();
    }

    public IEnumerator ExplosionCountdown()
    {
        yield return new WaitForSeconds(liveTime);
        explosionCache.SetActive(false);
        explosionCache.transform.parent = myExplosionsCollection.transform;
        explosionCache.transform.localPosition= Vector3.zero;
        if (OnDeath != null) OnDeath(gameObject);
    }

    public void AreaDamage()
    {
        List<GameObject> listOfHitThingsTemp= new List<GameObject>();
        listOfHitThingsTemp.AddRange(Physics.OverlapSphere(transform.position,blastRadius).ToList().ConvertAll((a)=>a.gameObject));
        List<BaseHealth> listOfDamaged= new List<BaseHealth>();
        BaseHealth tempHealth;
        for (int i = 0; i < listOfHitThingsTemp.Count; i++)
        {
            tempHealth = listOfHitThingsTemp[i].GetComponent<BaseHealth>();
            if (tempHealth == null)
            {
                tempHealth = listOfHitThingsTemp[i].GetComponentInChildren<BaseHealth>();
                if (tempHealth == null)
                {
                    tempHealth = listOfHitThingsTemp[i].GetComponentInParent<BaseHealth>();
                    if (tempHealth == null)
                    {
                        continue;
                    }
                }
            }
            listOfDamaged.Add(tempHealth);

        }
        listOfDamaged.ForEach((a)=>a.Damage(-baseDamage));

        


    }


}
