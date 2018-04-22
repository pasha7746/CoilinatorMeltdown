using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundAIBase : MonoBehaviour 
{
    protected NavMeshAgent myAgent;
    protected ZoneManager myZoneManager;

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myZoneManager = masterManager.myZoneManager;
    }

    // Use this for initialization
	void Start ()
	{
	   // myAgent.SetDestination(myZoneManager.listOfZones[0].transform.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
	   
    }

    
   
}
