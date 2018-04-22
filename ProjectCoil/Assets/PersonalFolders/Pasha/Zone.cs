using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public ZoneManager.ZoneTypes zone;
    public int linkedBarricade_1=-1, linkedBarricade_2=-1, linkedBarricade_3=-1;
    public BoxCollider myBoxCollider;

    void Awake()
    {
        myBoxCollider = GetComponent<BoxCollider>();
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
