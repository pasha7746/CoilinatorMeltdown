using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiskPieceBreaker : MonoBehaviour
{
    [System.Serializable]
    public struct Pieces
    {
        public GameObject original;
        public GameObject broken;
        public Renderer brokenRend;
        public BoxCollider brokenColl;
        public Rigidbody brokenRig;
    }

    public List<Pieces> listOfMiskPiecesToBreak;
    private RobotCenterHealth myHealth;


	// Use this for initialization
	void Start ()
	{
	    myHealth = GetComponent<RobotCenterHealth>();
	    myHealth.OnDeath += BreakAll;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //if (Input.GetKeyDown(KeyCode.S))
	    //{
	    //    for (int i = 0; i < listOfMiskPiecesToBreak.Count; i++)
	    //    {
	            

	    //    }
	    //}
	}

    public void BreakAll()
    {
        listOfMiskPiecesToBreak.ForEach(Break);
    }

    public void Break(Pieces piece)
    {
        piece.original.SetActive(false);
        if(!piece.brokenRend) return;

        piece.brokenRend.enabled = true;
        piece.brokenColl.enabled = true;
        piece.brokenRig.isKinematic = false;
        piece.broken.transform.parent = null;

        //gameObject.SetActive(false);
        //if (!render) return;

        //render.enabled = true;


        //myCollider.enabled = true;
        //myRigidbody.isKinematic = false;
        //piece.transform.parent = null;
        //if (shouldRenderChildren)
        //{
        //    childRendrerList.ForEach((A) => { A.enabled = true; });
        //    childColliderList.ForEach((A) => { A.enabled = true; });
        //}
        //if (OnPieceBreak != null) OnPieceBreak(this);
    }

}
