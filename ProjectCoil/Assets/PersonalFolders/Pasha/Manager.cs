using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    void Awake()
    {
        MasterManager.myPool = GetComponent<Pool>();
        MasterManager.mySpawnController = GetComponent<MasterSpawnController>();
        MasterManager.myZoneManager = GetComponent<ZoneManager>();
        MasterManager.myScoreUIManager = GetComponent<ScoreUIManager>();
        
    }

    void Start()
    {
        MasterManager.player = FindObjectOfType<Players>().gameObject;
    }

}
