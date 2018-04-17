using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class miniClone : MonoBehaviour
{
   public List<Transform> listOfTags= new List<Transform>();

    void Awake()
    {
        listOfTags = GetComponentsInChildren<Transform>().ToList();
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
