using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : BaseHealth
{
    public float maxHealth;
    public float health;

    public bool healthRegenerates;
    public float regenerationRate;
    
    public Coroutine regenRoutine;
    

    public event Action<float> OnHealthChange;
    public event Action OnHealthZero;
    public event Action OnDeath;

    private PlayerTrigger myPlayerTrigger;


    void Awake()
    {
        OnHealthZero += () =>
        {
            if (regenRoutine != null)
            {
                StopCoroutine(regenRoutine);
            }
        };

        if (healthRegenerates)
        {
            StartRegenRoutine();
        }

        myPlayerTrigger = GetComponentInChildren<PlayerTrigger>();
    }

    void Start()
    {
        myPlayerTrigger.OnDamage += ChangeHealth;
        if (OnHealthChange != null) OnHealthChange(health);
    }

   

    public override void Damage(float baseDamage)
    {
        base.Damage(baseDamage);
        ChangeHealth(baseDamage);
    }

    public void ChangeHealth(float change)
    {
        if (health > 0)
        {
            health += change;
          
        }
        if(health <= 0)
        {
            if (OnHealthZero != null) OnHealthZero();
            if (OnDeath != null) OnDeath();
        }
        else if(health>maxHealth)
        {
            health = maxHealth;
        }

        if (OnHealthChange != null) OnHealthChange(health);
    }

    public void HealEffect(float rate, float healthAdded)
    {
        StartCoroutine(HealEffectTimer(rate, healthAdded));
    }

    public IEnumerator HealEffectTimer(float rate, float healthAdded)
    {
        float duration = healthAdded / rate;
        regenerationRate += rate;
        while (true)
        {
            duration -= Time.deltaTime;

            if (duration <= 0)
            {
                break;
            }
            //yield return new WaitForEndOfFrame();
            yield return null;
        }

        regenerationRate -= rate;

        yield return null;
    }

    public void StartRegenRoutine()
    {
        regenRoutine = StartCoroutine(HealRoutine());
    }

    public IEnumerator HealRoutine()
    {
        float healthPiece = 0;
        while (true)
        {
            healthPiece = Time.deltaTime * regenerationRate;
            
            ChangeHealth(healthPiece);
            
            yield return null;
        }

        yield return null;
    }

}
