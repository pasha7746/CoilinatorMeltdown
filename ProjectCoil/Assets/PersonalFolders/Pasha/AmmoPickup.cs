using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : PickupBase
{
    public int ammoToGive;
    public Vector2 deviation;
    private DebugTotalAmmoUI myTotalAmmoUi;

    void Start()
    {
        CustomStart();
        myTotalAmmoUi = MasterManager.player.GetComponentInChildren<DebugTotalAmmoUI>();
    }

    public override void OnHit()
    {
        MasterManager.player.AddAmmo((int)(ammoToGive+Random.Range(deviation.x, deviation.y)));
        myTotalAmmoUi.UpdateUI();
        base.OnHit();
    }
}
