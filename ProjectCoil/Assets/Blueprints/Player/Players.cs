using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public int totalAmmo;
    public int maxAmmo;

    public void AddAmmo(int ammo)
    {
        totalAmmo += ammo;
        if (totalAmmo > maxAmmo)
        {
            totalAmmo = maxAmmo;
        }
    }


}
