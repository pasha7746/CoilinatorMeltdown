using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class miniHelper : MonoBehaviour
{
    private miniClone myClone;
    private MiskPieceBreaker myBreaker;
    public List<GameObject> listOfMisk= new List<GameObject>();
    public Material giveMaterial;

    // Use this for initialization
    void Start ()
    {
        myBreaker = GetComponentInParent<MiskPieceBreaker>();
	    myClone = FindObjectOfType<miniClone>();
        listOfMisk.Clear();

	    DoThings();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
           DoThings();
        }
    }

    public void DoThings()
    {
        List<MeshRenderer> myRenderest= new List<MeshRenderer>();
        myRenderest = GetComponentsInChildren<MeshRenderer>().ToList();

        List<MeshRenderer> listOfbrekables= new List<MeshRenderer>();

        myClone.ListOfMsMeshRenderers.ForEach((a) =>
        {
            a.gameObject.AddComponent<Rigidbody>();
            a.GetComponent<Rigidbody>().isKinematic = true;
            a.gameObject.AddComponent<BoxCollider>();
            a.GetComponent<BoxCollider>().enabled = false;
            a.shadowCastingMode = ShadowCastingMode.Off;
            a.receiveShadows = false;
            a.material = giveMaterial;
            a.enabled = false;
        });
        int index = 0;
        myRenderest.ForEach((a) =>
        {
            if (a.gameObject.GetComponent<RobotPieceBreak>())
            {
                a.gameObject.GetComponent<RobotPieceBreak>().piece =
                    myClone.ListOfMsMeshRenderers.Find((b) => b.name == a.name).gameObject;
                if (!a.gameObject.GetComponent<BoxCollider>())
                {
                    a.gameObject.AddComponent<BoxCollider>();

                }

                a.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                listOfbrekables.Add(a);
            }
            else
            {
                MiskPieceBreaker.Pieces pice = new MiskPieceBreaker.Pieces();
                pice.original = a.gameObject;
                pice.broken = myClone.ListOfMsMeshRenderers.Find((b) => a.gameObject.name == b.gameObject.name)
                    .gameObject;
                pice.brokenRend = pice.broken.GetComponent<MeshRenderer>();
                pice.brokenColl = pice.broken.GetComponent<BoxCollider>();
                pice.brokenRig = pice.broken.GetComponent<Rigidbody>();

                // myBreaker.listOfMiskPiecesToBreak.Add(pice);
                myBreaker.listOfMiskPiecesToBreak[index] = pice;
                index++;

            }

            a.material = giveMaterial;
        });


       

        //myClone.ShitHeadUnity();




        //Debug.Break();
    }

  
}
