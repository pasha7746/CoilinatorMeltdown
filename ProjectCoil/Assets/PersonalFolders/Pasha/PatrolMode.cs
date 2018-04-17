using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMode : MonoBehaviour
{
    public NodePathCluster_Start myNodeCluster;

    public enum PatrolStates
    {
        LoopClosed, LoopReverse 
    }

    public PatrolStates myPatrolState;


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
