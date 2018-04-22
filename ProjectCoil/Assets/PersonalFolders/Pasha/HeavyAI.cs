using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class HeavyAI : GroundAIBase
{
    public List<Heavy_Guns> listOfHeavyGuns= new List<Heavy_Guns>();

    public enum Events
    {
        Retreat,
        Attack
    }
   



	// Use this for initialization
	void Start ()
	{
		listOfHeavyGuns.AddRange(GetComponentsInChildren<Heavy_Guns>());
        listOfHeavyGuns.ForEach((a) =>
        {
            a.OnReload += Retreat;
            a.OnReloadComplete += PositionToShoot;
            
        });
	    PositionToShoot();

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
           
            myAgent.SetDestination(SelectRandomPositionInTheZone(tempZone));
            StartCoroutine(WaitForArrivalAtDestination(Events.Attack));
        }
        
    }

    public Vector3 SelectRandomPositionInTheZone(Zone tempZone)
    {
        Vector3 pos = new Vector3();
        pos.y = transform.position.y;
        pos.x = tempZone.transform.position.x +
                Random.Range(-(tempZone.myBoxCollider.size.x / 2), (tempZone.myBoxCollider.size.x / 2));
        pos.z = tempZone.transform.position.z +
                Random.Range(-(tempZone.myBoxCollider.size.z / 2), (tempZone.myBoxCollider.size.z / 2));
        return pos;
    }

    public IEnumerator WaitForArrivalAtDestination(Events action)
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
         
           if (myAgent.remainingDistance <= myAgent.stoppingDistance/2)
            {
                switch (action)
                {
                    case Events.Retreat:
                        PositionToShoot();
                        break;
                    case Events.Attack:
                        Aim();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("action", action, null);
                }
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

    public void Retreat()
    {
        Zone tempZone = myZoneManager.Safe.Find((a) => a.linkedBarricade_1 == masterManager.mySpawnController.currentBarricadeIndex);
        if (tempZone == null)
        {
            tempZone = myZoneManager.Safe.Find((a) => a.linkedBarricade_2 == masterManager.mySpawnController.currentBarricadeIndex);
            if (tempZone == null)
            {
                tempZone = myZoneManager.Safe.Find((a) => a.linkedBarricade_3 == masterManager.mySpawnController.currentBarricadeIndex);

            }
        }
        myAgent.SetDestination(SelectRandomPositionInTheZone(tempZone));
        StartCoroutine(WaitForArrivalAtDestination(Events.Retreat));

    }


}
