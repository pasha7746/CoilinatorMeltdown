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
    private List<MeshRenderer> taGameObjects= new List<MeshRenderer>();
    public Material giveMaterial;

    // Use this for initialization
    void Start ()
	{
	    myClone = FindObjectOfType<miniClone>();
	    //myBreaker = FindObjectOfType<MiskPieceBreaker>();


	    taGameObjects = GetComponentsInChildren<MeshRenderer>().ToList();
	    DoThings();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
           // DoThings();
        }
    }

    public void DoThings()
    {
       // MiskPieceBreaker.Pieces piece = new MiskPieceBreaker.Pieces();

        for (int i = 0; i < taGameObjects.Count; i++)
        {
            if (myClone)
            {
                taGameObjects[i].gameObject.GetComponent<MeshFilter>().mesh =
                    myClone.ListOfMsMeshRenderers[i].gameObject.GetComponent<MeshFilter>().mesh;

            }

            taGameObjects[i].material = giveMaterial;
        }




        for (int i = 0; i < listOfMisk.Count; i++)
        {
            //piece.broken = listOfMisk[i].gameObject;

            //piece.original =
            //            myClone.listOfTags.Find((a) =>
            //            {
            //                if (a.gameObject.name == listOfMisk[i].gameObject.name)
            //                {
            //                    return true;
            //                }
            //                else
            //                {
            //                    return false;
            //                }
            //            }).gameObject;
            //piece.brokenColl = listOfMisk[i].gameObject.GetComponent<BoxCollider>();
            //piece.brokenRend = listOfMisk[i].GetComponent<MeshRenderer>();
            //piece.brokenRig = listOfMisk[i].gameObject.GetComponent<Rigidbody>();


            //myBreaker.listOfMiskPiecesToBreak.Add(piece);
        }

        foreach (var tata in taGameObjects)
        {
            //tata.shadowCastingMode = ShadowCastingMode.Off;
            //tata.receiveShadows = false;
            //DestroyObject(tata.GetComponent<MiskTag>());
            //if (tata != null)
            //{
            //    if (tata.GetComponent<Rigidbody>().isKinematic)
            //    {
            //        listOfMisk.Add(tata.gameObject);
            //    }
            //}


            //myClone.listOfTags

            //tata.enabled = true;
            //if (tata.enabled)
            //{
            //   // tata.gameObject.AddComponent<RobotPieceBreak>();
            //    tata.gameObject.GetComponent<RobotPieceBreak>().piece =
            //        myClone.listOfTags.Find((a) =>
            //        {
            //            if (a.gameObject.name == tata.gameObject.name)
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //                return false;
            //            }
            //        }).gameObject;
            //}


            // tata.gameObject.AddComponent<Rigidbody>();
            //tata.gameObject.AddComponent<BoxCollider>();

            //if (tata.gameObject.GetComponent<BoxCollider>())
            //{
            //   // DestroyObject(tata.gameObject.GetComponent<BoxCollider>());

            //// tata.enabled = false;
            //  tata.gameObject.AddComponent<RobotPieceBreak>();

            //    tata.GetComponent<RobotPieceBreak>().piece =
            //                    myClone.listOfTags.Find((a) =>
            //                    {
            //                        if (a.gameObject.name == tata.gameObject.name)
            //                        {
            //                            return true;
            //                        }
            //                        else
            //                        {
            //                            return false;
            //                        }
            //                    }).gameObject;


            //}
            //tata.gameObject.GetComponent<BoxCollider>().enabled = false;
            //tata.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //tata.enabled = false;
        }

        Debug.Break();
    }

  
}
