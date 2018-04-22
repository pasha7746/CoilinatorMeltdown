using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class HeavyAI : GroundAIBase
{
    public List<Heavy_Guns> listOfHeavyGuns= new List<Heavy_Guns>();

	// Use this for initialization
	void Start ()
	{
		listOfHeavyGuns.AddRange(GetComponentsInChildren<Heavy_Guns>());
        PositionToShoot();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    public void PositionToShoot()
    {
        Zone tempZone=  myZoneManager.Open.Find((a) => a.linkedBarricade_1 == masterManager.mySpawnController.currentBarricadeIndex);
        if (tempZone == null)
        {
            tempZone = myZoneManager.Open.Find((a) => a.linkedBarricade_2 == masterManager.mySpawnController.currentBarricadeIndex);
            if (tempZone == null)
            {
                tempZone = myZoneManager.Open.Find((a) => a.linkedBarricade_3 == masterManager.mySpawnController.currentBarricadeIndex);

            }
        }
        else
        {
            Vector3 pos= new Vector3();
            pos.y = transform.position.y;
            pos.x = tempZone.transform.position.x +
                    Random.Range(-(tempZone.myBoxCollider.size.x / 2), (tempZone.myBoxCollider.size.x / 2));
            pos.z = tempZone.transform.position.z +
                    Random.Range(-(tempZone.myBoxCollider.size.z / 2), (tempZone.myBoxCollider.size.z / 2));
            myAgent.SetDestination(pos);
            StartCoroutine(WaitForArrivalAtDestination());
        }
        
    }

    public IEnumerator WaitForArrivalAtDestination()
    {
        while (true)
        {
            if (myAgent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                Aim();
                break;
            }

            
        }
        yield return null;
    }

    public void Aim()
    {
        transform.DOLookAt(listOfHeavyGuns[0].myTarget.transform.position, 1);
        Shoot();
    }

    public void Shoot()
    {
        foreach (var cGun in listOfHeavyGuns)
        {
            cGun.Shoot(6);
        }
    }

}
