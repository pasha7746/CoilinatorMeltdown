using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWorldScale : MonoBehaviour
{
    public GameObject mark;
    public float moveFactor;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("TriggerButLeft"))
        {
            mark.transform.Translate(Vector3.up*moveFactor);

        }
    }
}
