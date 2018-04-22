using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundGuns : MonoBehaviour
{
    private List<ProjectileSpawnPoint> listOfProjectileSpawnPoints= new List<ProjectileSpawnPoint>();




    void Awake()
    {

    }


    // Use this for initialization
	void Start ()
	{
	    listOfProjectileSpawnPoints = GetComponentsInChildren<ProjectileSpawnPoint>().ToList();

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
