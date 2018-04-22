﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [Header("Projectiles")]
    public GameObject playerBolt;
    public GameObject enemyProjectile;
    public GameObject heavyRocket;
    
    private List<GameObject> listOfBolts= new List<GameObject>();    //public for debug
    private List<GameObject> listOfMissiles= new List<GameObject>();
    

    public GameObject Give_PlayerProjectile()
    {
        
        if (Set_PlayerProjectileAlive()!=null)
        {
            return Set_PlayerProjectileAlive();
        }
        else
        {
            GameObject projectile = Instantiate(playerBolt);
            projectile.GetComponent<Projectile>().OnDeath += PutToSleep_PlayerProjectile;
            return projectile;
        }
    }

    private GameObject Set_PlayerProjectileAlive()
    {
        return listOfBolts.Find((a) => !a.activeSelf);
        
    }

    private void PutToSleep_PlayerProjectile(GameObject projectile)
    {
        Projectile projectileReset  = playerBolt.GetComponent<Projectile>();
        Projectile proejctileClone = projectile.GetComponent<Projectile>();
        

        proejctileClone.angle = projectileReset.angle;
        proejctileClone.hit = projectileReset.hit;
        proejctileClone.impactedObject = projectileReset.impactedObject;
        proejctileClone.norm = projectileReset.norm;
        proejctileClone.shouldBounce = projectileReset.shouldBounce;
        proejctileClone.targetPoint = projectileReset.targetPoint;

        projectile.SetActive(false);

        projectile.GetComponent<Rigidbody>().velocity= Vector3.zero;
        projectile.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


        if (!listOfBolts.Contains(projectile))
        {
            listOfBolts.Add(projectile);

        }

    }

    public GameObject Give_Missile()
    {
        if (Set_Missile() != null)
        {
            return Set_Missile();
        }
        else
        {
            GameObject missileTemp = Instantiate(heavyRocket);
            heavyRocket.GetComponent<Missile>().OnDeath += PutToSleep_Missile;
            return missileTemp;
        }
    }

    private GameObject Set_Missile()
    {
        return listOfMissiles.Find((a) => !a.activeSelf);
    }

    private void PutToSleep_Missile(GameObject missile)
    {
        missile.SetActive(false);

        missile.GetComponent<Rigidbody>().velocity = Vector3.zero;
        missile.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


        if (!listOfMissiles.Contains(missile))
        {
            listOfMissiles.Add(missile);

        }
    }


}
