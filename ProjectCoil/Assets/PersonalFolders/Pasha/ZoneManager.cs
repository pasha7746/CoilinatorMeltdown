using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public List<Zone> listOfZones;

    public enum ZoneTypes
    {
        Open,
        Enclosed,
        Cover,
        Overlook,
        Safe,
        LongDistance,
        Close

    }

	// Use this for initialization
	void Start ()
	{
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
