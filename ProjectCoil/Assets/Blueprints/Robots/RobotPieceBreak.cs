using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RobotPieceBreak : BaseRobotPiece 
{
  
    public event Action<RobotPieceBreak> OnPieceBreak;
    public bool isPieceBreakable;
    private Points myPoints;
    public float pieceDurability;

    void Awake()
    {
        render = piece.GetComponent<MeshRenderer>();
        myCollider = piece.GetComponent<Collider>();
        myRigidbody = piece.GetComponent<Rigidbody>();
        if (shouldRenderChildren)
        {
            childRendrerList=(piece.GetComponentsInChildren<MeshRenderer>().ToList());
            childColliderList = (piece.GetComponentsInChildren<BoxCollider>().ToList());

        }
        if (isPieceBreakable)
        {
            OnPieceHit += PieceGetsHit;

        }
    }

    void Start()
    {
         myPoints = GetComponent<Points>();
         OnPieceBreak += SendPointsOnBreak;
         OnPieceHit += SendPointsOnHit;

    }

    public void SendPointsOnHit(float none)
    {
        myPoints.Score_Low();
    }

    public void SendPointsOnBreak(RobotPieceBreak none)
    {
        myPoints.Score_Med();
    }


    public void PieceGetsHit(float damage)
    {
        if(!isPieceBreakable) return;
        pieceDurability -= damage;
        if (pieceDurability <= 0)
        {
            BreakPice();
        }
    }


    public void BreakPice()
    {

        gameObject.SetActive(false);
        if (!render) return;
        
        render.enabled = true;

        
        myCollider.enabled = true;
        myRigidbody.isKinematic = false;
        piece.transform.parent = null;
        if (shouldRenderChildren)
        {
            childRendrerList.ForEach((A) => { A.enabled = true; });
            childColliderList.ForEach((A) => { A.enabled = true; });
        }
        if (OnPieceBreak != null) OnPieceBreak(this);
    }






   

}
