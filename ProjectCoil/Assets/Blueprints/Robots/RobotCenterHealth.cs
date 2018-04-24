using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RobotCenterHealth : BaseHealth
{
    public float robotHealth;
    public event Action OnDeath;

	// Use this for initialization
	void Start ()
    {
		GetComponentsInChildren<BaseRobotPiece>().ToList().ForEach((a) => { a.OnPieceHit += EventPieceIsHit; });
        OnDeath += EnemyCounter_Static.GlobalCounter_RemoveEnemy;
        Points myPoints = GetComponent<Points>();
        OnDeath += myPoints.Score_High;
    }


    public void EventPieceIsHit(float damage)
    {
       ApplyDamage(damage);
    }

    public void ApplyDamage(float damage)
    {
        robotHealth -= damage;
        if (robotHealth <= 0)
        {
            MasterManager.myPickupManager.SpawnPickup(transform.position);
            if (OnDeath != null) OnDeath();
            
        }
    }

    public override void Damage(float baseDamage)
    {
        base.Damage(baseDamage);
        ApplyDamage(baseDamage);
    }
}
