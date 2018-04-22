using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGuns : MonoBehaviour
{
    [System.Serializable]
    public struct GunStats
    {
        public GameObject gunModel;
        public GameObject projectileModel;
        public Vector2 fireRateRange;
        public float projectileSpeed;
        public Vector2 shotsInBurst;
        public Transform barrelEnding;
        [Range(0,1)]
        public float accuracy;

        public int maxAmmo;
        public float projectileLifetime;
        public float baseDamage;
    }

    public SteamVR_Camera targetPlayers;
    private event Action<GunStats, int> OnAllGunsAimed;
    public List<GunStats> gunList;
    public List<Coroutine> fireRoutineList= new List<Coroutine>();
    public int[] cAmmo;
    public event Action<Vector3, float> OnNeedReload;
    public float reloadTime;
    

    // Use this for initialization
    void Start ()
	{
	    targetPlayers = FindObjectOfType<SteamVR_Camera>();
	    OnAllGunsAimed += FireGuns;
	    GetComponent<RobotCenterHealth>().OnDeath += OnDeathCutOfFireRoutines;

        GunStats tempGunStats= new GunStats();

	    for (int i = 0; i < gunList.Count; i++)
	    {
	        tempGunStats= gunList[i];
	        tempGunStats.barrelEnding = gunList[i].gunModel.GetComponentInChildren<ProjectileSpawnPoint>().transform;
	        gunList[i] = tempGunStats;
	    }
	    cAmmo= new int[gunList.Count];
	    for (int i = 0; i < gunList.Count; i++)
	    {
	        cAmmo[i] = gunList[i].maxAmmo;
	    }
	}

    public void AddAmmo()
    {
        for (int i = 0; i < gunList.Count; i++)
        {
          //  Debug.Break();
            cAmmo[i] = gunList[i].maxAmmo;
        }
    }

    public void OnDeathCutOfFireRoutines()
    {
       OnAllGunsAimed = null;
       StopAllCoroutines();
      
    }
    
    public void AimGuns(Vector3 target)
    {
        int gunEmpty = 0;

        for (int i = 0; i < gunList.Count; i++)
        {
            if (cAmmo[i] > 0)
            {
                gunList[i].gunModel.transform.DOLookAt(target, 1f).OnComplete(AimComplete(gunList[i], i));

            }
            else
            {
                gunEmpty++;
            }
        }

        if (gunEmpty == gunList.Count)
        {
            Reload();
        }
    }

    public void Reload()
    {
        RaycastHit hit;
        int layers = 1 << 15;
        layers = ~layers;
        Physics.Raycast(transform.position, Vector3.down,out hit,50,layers, QueryTriggerInteraction.Ignore);
        Debug.DrawRay(transform.position, Vector3.down*20, Color.green, 200f);
        if (hit.collider)
        {
            if (hit.collider.gameObject.isStatic)
            {
                if (OnNeedReload != null) OnNeedReload(hit.point, reloadTime);
            }
        }

    }

    public TweenCallback AimComplete(GunStats cGun, int index)
    {
        if (OnAllGunsAimed != null) OnAllGunsAimed(cGun, index);
        return null;
    }

    public IEnumerator FireRoutine(GunStats cGun, int index)
    {

        int ammountOfShots = (int)(Random.Range(cGun.shotsInBurst.x, cGun.shotsInBurst.y+1));

        for (int i = 0; i < ammountOfShots; i++)
        {
           // Debug.Break();

            yield return new WaitForSeconds(Random.Range(cGun.fireRateRange.x, cGun.fireRateRange.y));
            ShootProjectile(cGun, index);
        }

        yield return null;
    }

    public void FireGuns(GunStats cGun, int coroutineIndex)
    {
        if (fireRoutineList.Count < gunList.Count)
        {
            fireRoutineList.Add(StartCoroutine(FireRoutine(cGun, coroutineIndex)));
        }
        else
        {
            if (fireRoutineList[coroutineIndex] != null)
            {
                StopAllCoroutines();

            }
            fireRoutineList[coroutineIndex] = StartCoroutine(FireRoutine(cGun, coroutineIndex));
            
        }
        
    }
    
    public void ShootProjectile(GunStats cGun, int index)   //projectile gets fired out using this method
    {
        GameObject spawnedProjectile = Instantiate(cGun.projectileModel);
        cAmmo[index]--;
        spawnedProjectile.transform.position = cGun.barrelEnding.position;
        spawnedProjectile.transform.LookAt(targetPlayers.transform.position);
        EnemyProjectileTag projectileStats = spawnedProjectile.GetComponent<EnemyProjectileTag>();
        if (projectileStats)
        {
            projectileStats.damage = cGun.baseDamage;
            projectileStats.totalPossibleLifetime = cGun.projectileLifetime;
        }
        projectileStats.StartLifeTimer();
        float distance = Vector3.Distance(cGun.barrelEnding.position, targetPlayers.transform.position);
        distance *= cGun.accuracy;

        Vector3 accuracyOffest = (spawnedProjectile.transform.forward* distance) + new Vector3(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f)) ;
        accuracyOffest= Vector3.Normalize(accuracyOffest);
        spawnedProjectile.GetComponent<Rigidbody>().AddForce((spawnedProjectile.transform.forward+ accuracyOffest) * cGun.projectileSpeed);
    }
    
}
