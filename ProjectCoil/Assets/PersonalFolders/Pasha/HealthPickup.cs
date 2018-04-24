using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : PickupBase
{
    public float healthToGive;
    public Vector2 deviation;
    private PlayerHealth myHealth;


    void Start()
    {
        CustomStart();
        myHealth = MasterManager.player.GetComponent<PlayerHealth>();
    }

    public override void OnHit()
    {
        myHealth.ChangeHealth(healthToGive+ Random.Range(deviation.x, deviation.y));
       
        base.OnHit();
    }
}
