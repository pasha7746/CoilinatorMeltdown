using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PickupBase : MonoBehaviour
{
    public event Action OnPickupHit;
    public event Action<GameObject> OnDisable; 
    public enum PickupType
    {
        DamageBoost, ExtraAmmo, HealthPickup, RapidFirePickup, NoneNull
    }

    public Tween myScaleDown;
    public Tween myScaleUp;
    public PickupType thisPickupIs;
    public bool isUsed;
    public Ease myEase;

    void OnEnable()
    {
        myScaleUp = transform.DOScale(Vector3.one, 2f).SetEase(myEase);
    }

    public virtual void CustomStart()
    {
        OnPickupHit += OnHit;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(isUsed) return;
        if(!other.GetComponent<Projectile>()) return;
        if (OnPickupHit != null) OnPickupHit();
    }

    public virtual void OnHit()
    {
        isUsed = true;
        if (myScaleUp.IsActive())
        {
            myScaleUp.Kill();
        }

        myScaleDown= transform.DOScale(Vector3.zero, 2f).SetEase(myEase).OnComplete(Despawn);
    }

    public void Despawn()
    {
        if (OnDisable != null) OnDisable(gameObject);

    }

}
