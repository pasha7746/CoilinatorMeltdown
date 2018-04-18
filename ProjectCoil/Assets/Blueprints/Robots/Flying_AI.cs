using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(FlightPathFinding))]

public class Flying_AI : MonoBehaviour
{
    private EnemyGuns myGuns;
    private FlightPathFinding myMovement;
    public Vector2 droidHoverLenghtRange;
    private Coroutine waitCoroutine;

    //public PatrolGrid MyPatrolGrid;

    public bool moveLocked; //debug only

    public enum FlyType
    {
        Roam, Patrol
    }

    public FlyType flightBehavior;

    void Awake()
    {
        myGuns = GetComponent<EnemyGuns>();
        myMovement = GetComponent<FlightPathFinding>();

    }

    // Use this for initialization
    void Start()
    {
        myMovement.OnRouteComplete += myMovement.MoveToRandomPointOnMap;
        myMovement.OnGridPointHit += Wait;
        if (moveLocked) return;
        switch (flightBehavior)
        {
            case FlyType.Roam:

                myMovement.MoveToCombatArea();

                break;
            case FlyType.Patrol:
              //  Patrol();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }

    //public void Patrol()
    //{
    //    MyPatrolGrid = GetComponent<PatrolGrid>();
    //}

    public void Wait()
    {


        if (waitCoroutine == null)
        {
            waitCoroutine = StartCoroutine(WaitCoroutine());

        }

    }

    public IEnumerator WaitCoroutine()
    {
        myMovement.TurnTowardsPlayer(myGuns.targetPlayers.transform.position);
        myGuns.AimGuns(myGuns.targetPlayers.transform.position);
        yield return new WaitForSeconds(Random.Range(droidHoverLenghtRange.x, droidHoverLenghtRange.y));

        myMovement.MoveToRandomPointOnMap();
        waitCoroutine = null;
        yield return null;
    }


}
