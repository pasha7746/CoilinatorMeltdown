using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class PickupManager : MonoBehaviour
{
    [System.Serializable]
    public struct Pickup
    {
        public PickupBase.PickupType type;
        
        public int Chance;
        public int turnIncrement;
        [HideInInspector]
        public int currentChance, givenChance;

        public Vector2 deviation;
    }

    public Pickup health, ammo;

    void Start()
    {
        health.currentChance = health.Chance;
        ammo.currentChance = ammo.Chance;
    }

    public void SpawnPickup(Vector3 pos)
    {
        GameObject tempPickup = MasterManager.myPool.Give_Pickup(CalculatePickupChance());
        if (tempPickup)
        {
            tempPickup.transform.position = pos;
            tempPickup.SetActive(true);
        }
    }

    private PickupBase.PickupType CalculatePickupChance()   //this is a quickhand... can be reworked later
    {
        health.givenChance = (int) (Random.value * 100);
        ammo.givenChance = (int)(Random.value * 100);
        bool healthChance = false;
        bool ammoChance = false;

        if (health.givenChance<health.currentChance) healthChance = true;
        if (ammo.givenChance < ammo.currentChance) ammoChance = true;

        if (healthChance && ammoChance)
        {
            float distHealth = health.currentChance - health.givenChance;
            float distAmmo = ammo.currentChance - ammo.givenChance;
            if (distHealth >= distAmmo)
            {
                health.currentChance = health.Chance;
                ammo.currentChance += (int)(ammo.turnIncrement + Random.Range(ammo.deviation.x, ammo.deviation.y));
                return health.type;
            }
            else
            {
                ammo.currentChance = ammo.Chance;
                health.currentChance += (int)(health.turnIncrement + Random.Range(health.deviation.x, health.deviation.y));
                return ammo.type;
            }

        }
        else if(healthChance)
        {
            health.currentChance = health.Chance;
            ammo.currentChance += (int) (ammo.turnIncrement + Random.Range(ammo.deviation.x, ammo.deviation.y));
            return health.type;
        }
        else if(ammoChance)
        {
            ammo.currentChance = ammo.Chance;
            health.currentChance += (int)(health.turnIncrement + Random.Range(health.deviation.x, health.deviation.y));
            return ammo.type;
        }
        else
        {
            return PickupBase.PickupType.NoneNull;
        }

    }

}
