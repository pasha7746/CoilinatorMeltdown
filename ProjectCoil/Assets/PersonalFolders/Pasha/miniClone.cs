using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class miniClone : MonoBehaviour
{
    public List<MeshRenderer> ListOfMsMeshRenderers= new List<MeshRenderer>();


    void Awake()
    {
        ListOfMsMeshRenderers = GetComponentsInChildren<MeshRenderer>().ToList();

    }


    // Use this for initialization
    void Start ()
	{

    }

    public void ShitHeadUnity()
    {
        ListOfMsMeshRenderers.ForEach((a)=> a.enabled=false);
    }

    // Update is called once per frame
    void Update ()
	{
		
	}
}
