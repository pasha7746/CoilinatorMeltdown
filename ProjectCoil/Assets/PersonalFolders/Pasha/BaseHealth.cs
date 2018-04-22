using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public event Action OnHit;
    public virtual void Damage(float baseDamage)
    {
        if (OnHit != null) OnHit();
    }



}
