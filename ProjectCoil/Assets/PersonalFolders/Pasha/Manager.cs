using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    void Awake()
    {
        masterManager.myPool = GetComponent<Pool>();
        masterManager.mySpawnController = GetComponent<MasterSpawnController>();
        masterManager.myZoneManager = GetComponent<ZoneManager>();

    }

}
