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
        
        Attack,
        Wait
    }

    private bool isRetreatComplete= true;
    private Heavy_AnimationController myAnimationController;


    // Use this for initialization
	void Start ()
	{
	    myAnimationController = GetComponentInChildren<Heavy_AnimationController>();
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
       if(!isRetreatComplete) return;
        Zone tempZone=  myZoneManager.Open.Find((a) => a.linkedBarricade_1 == MasterManager.mySpawnController.currentBarricadeIndex);
        if (tempZone == null)
        {
            tempZone = myZoneManager.Open.Find((a) => a.linkedBarricade_2 == MasterManager.mySpawnController.currentBarricadeIndex);
            if (tempZone == null)
            {
                tempZone = myZoneManager.Open.Find((a) => a.linkedBarricade_3 == MasterManager.mySpawnController.currentBarricadeIndex);

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
        myAnimationController.Play(Heavy_AnimationController.States.MoveForwards);
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
           

            if (Vector3.Distance(myAgent.pathEndPosition, transform.position) <= myAgent.stoppingDistance)
            {
                switch (action)
                {
                   
                    case Events.Attack:
                        
                        Aim();
                        break;
                    case Events.Wait:
                        myAnimationController.Play(Heavy_AnimationController.States.Stop);
                        isRetreatComplete = true;
                        PositionToShoot();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("action", action, null);
                }
                break;
            }

            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    public void Aim()
    {
        transform.DOLookAt(listOfHeavyGuns[0].myTarget.transform.position, 1).OnComplete(Shoot);
       // Shoot();
    }

   

    public void Shoot()
    {
        myAnimationController.Play(Heavy_AnimationController.States.Stop);
        myAnimationController.Play(Heavy_AnimationController.States.Shoot);
        foreach (var cGun in listOfHeavyGuns)
        {
            
            cGun.Shoot(6);
        }

    }

    public void Retreat()
    {
        isRetreatComplete = false;
        Zone tempZone = myZoneManager.Safe.Find((a) => a.linkedBarricade_1 == MasterManager.mySpawnController.currentBarricadeIndex);
        if (tempZone == null)
        {
            tempZone = myZoneManager.Safe.Find((a) => a.linkedBarricade_2 == MasterManager.mySpawnController.currentBarricadeIndex);
            if (tempZone == null)
            {
                tempZone = myZoneManager.Safe.Find((a) => a.linkedBarricade_3 == MasterManager.mySpawnController.currentBarricadeIndex);

            }
        }
        myAgent.SetDestination(SelectRandomPositionInTheZone(tempZone));
        StartCoroutine(WaitForArrivalAtDestination(Events.Wait));

    }


}
