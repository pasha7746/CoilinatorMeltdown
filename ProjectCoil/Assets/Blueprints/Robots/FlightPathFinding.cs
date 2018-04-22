using System;
using System.Collections;
using System.ComponentModel;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class FlightPathFinding : MonoBehaviour
{
    private FlyDroneState.StateEnum myState;
    private FlyDroneState.Triggers_Movement myTriggersMovement;

    private FlightGrid myCombatAreaGrid;
    private Vector3 initialPos;
    private Vector3 targetPos;
    private event Action OnPointHit;
    public event Action OnGridPointHit;
    public event Action OnRouteComplete;
    public event Action OnReloadWaitComplete;

    private bool isPathComplete;
    //private event Action OnReadyForCombat;
    //private event Action OnReadyToMove;

    private NodePath currentNodePath;
    [HideInInspector]
    public NodePathCluster_Start myPathCluster;
    private Coroutine followingRoutine;
    private int indexCounter;
    
    public float moveSpeed;

    private float reloadTime;

    private Vector3 reloadOrigin;
    private bool isReloading;
    public float landHeight;


    // Use this for initialization
    // Use this for initialization
    void Start()
    {

        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //   MoveToRandomPointOnMap();
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //MoveToPoint(beacon.transform.position, 5);
        //    myPathCluster = FindObjectOfType<NodePathCluster_Start>();
        //    currentNodePath = myPathCluster.SelectRandomNode();

        //    StartFollowingSteps();

        //}
    }



    public void MoveToCombatArea()
    {
        if (myPathCluster != null)
        {
            myCombatAreaGrid = myPathCluster.connectedFlightGrid; // moved

            currentNodePath = myPathCluster.SelectRandomNode();
            StartFollowingSteps();
        }
        else
        {
            print("No Path Found");
        }


    }

    public void TurnTowardsPlayer(Vector3 point)
    {
        LookAtPoint(new Vector3(point.x, transform.position.y, point.z), 0.5f);

    }
    //public void LaunchRoamMode()
    //{
    //    AlignToGrid();
    //    OnReadyToMove += RequestMove;
    //    OnReadyForCombat += RequestCombat;
    //    RequestMove();
    //}

    //public void RequestCombat()
    //{

    //}

    //public void RequestMove()
    //{

    //}

    public void AlignToGrid()
    {
        // print("WorkerRunning");

        //  initialPos = transform.position;

        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += DetectPoint;
        worker.RunWorkerCompleted += OnCompletDetectPoint;
        worker.RunWorkerAsync();
    }
    
    private void DetectPoint(object sender, DoWorkEventArgs e)
    {
        Vector3 point = new Vector3();
        float distance = 10000;
        float tempDistance = 0;
        for (int i = 0; i < myCombatAreaGrid.gridBlockSize.x; i++)
        {
            for (int j = 0; j < myCombatAreaGrid.gridBlockSize.y; j++)
            {
                for (int k = 0; k < myCombatAreaGrid.gridBlockSize.z; k++)
                {
                    if (!myCombatAreaGrid.obstacleMap[i, j, k]) continue;
                    tempDistance = Vector3.Distance(initialPos, myCombatAreaGrid.triDPos[i, j, k]);
                    if (tempDistance > distance) continue;
                    distance = tempDistance;
                    targetPos = myCombatAreaGrid.triDPos[i, j, k];
                }
            }
        }
    }
    private void OnCompletDetectPoint(object sender, RunWorkerCompletedEventArgs e)
    {
        MoveToPoint(targetPos, moveSpeed);
    }

    public void MoveToPoint(Vector3 point, float speed)
    {
        float newSpeed = 0;
        newSpeed = Vector3.Distance(transform.position, point) / speed;
        transform.DOMove(point, newSpeed).SetEase(Ease.Linear).OnComplete(EventPointHit);
    }

    public void Land(Vector3 point, float time)
    {
        if(isReloading) return;
        isReloading = true;
        reloadOrigin = transform.position;
        StopAllCoroutines();
        float newSpeed = 0;
        point.y += landHeight;

        newSpeed = Vector3.Distance(transform.position, point) / moveSpeed;
        reloadTime = time;
        transform.DOMove(point, newSpeed).SetEase(Ease.Linear).OnComplete(WaitForReload);
       // Debug.Break();
    }

    public void WaitForReload()
    {
        StartCoroutine(WaitForReloadEnumerator(reloadTime));
    }

    public IEnumerator WaitForReloadEnumerator(float time)
    {
        float newSpeed = Vector3.Distance(transform.position, reloadOrigin) / moveSpeed;
        yield return new WaitForSeconds(time);
        transform.DOMove(reloadOrigin, newSpeed).SetEase(Ease.Linear).OnComplete(ReturnToOrigin);
        
        yield return null;
    }

    public void ReturnToOrigin()
    {
        StartCoroutine(ReturnToOriginEnumerator());
    }

    public IEnumerator ReturnToOriginEnumerator()
    {
        isReloading = false;

        if (OnReloadWaitComplete != null) OnReloadWaitComplete();
        yield return new WaitForEndOfFrame();
        yield return null;
    }

    public void LookAtPoint(Vector3 point, float speed)
    {
        float newSpeed = 0;
        newSpeed = Vector3.Angle(transform.position, point);
        transform.DOLookAt(point, speed);
    }

    public void EventPointHit()
    {
        if (isPathComplete)
        {
            if (OnGridPointHit != null) OnGridPointHit();
            return;
        }

        if (OnPointHit != null) OnPointHit();
    }


    public void MoveToRandomPointOnMap()
    {
        if(isReloading) return;
        Vector3 target = new Vector3(Random.Range(-myCombatAreaGrid.bounds.x / 2, myCombatAreaGrid.bounds.x / 2), Random.Range(-myCombatAreaGrid.bounds.y / 2, myCombatAreaGrid.bounds.y / 2), Random.Range(-myCombatAreaGrid.bounds.z / 2, myCombatAreaGrid.bounds.z / 2));
        initialPos = transform.position + target;
        LookAtPoint(target, 0.5f);
        AlignToGrid();

    }

    public void FollowPath(NodePath path)
    {
        OnPointHit = null;
        OnPointHit += StartFollowingSteps;
        MoveToPoint(path.listOfNodes.Find((a) => a.GetComponent<Node>().thisNodeType == Node.NodeType.StartNode).transform.position, 5); //add speed values

    }

    public void StartFollowingSteps()
    {
        followingRoutine = StartCoroutine(FollowSteps(currentNodePath));

    }

    public IEnumerator FollowSteps(NodePath path)
    {
        int target = path.listOfNodes.Count;
        indexCounter = 0;
        int compare = -1;
        OnPointHit = null;
        OnPointHit += OnStepReached;

        while (true)
        {
            if (indexCounter != compare)
            {
                if (indexCounter < target)
                {
                    MoveToPoint(path.listOfNodes[indexCounter].transform.position, moveSpeed);  //add speed values
                    LookAtPoint(path.listOfNodes[indexCounter].transform.position, 0.3f);  //add speed values
                    compare = indexCounter;
                }
                else
                {
                    initialPos = transform.position;

                    myCombatAreaGrid = myPathCluster.connectedFlightGrid;
                    if (OnRouteComplete != null) OnRouteComplete();
                    isPathComplete = true;
                    // print("PathComplete");
                    break;
                }
            }


            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    public void OnStepReached()
    {
        indexCounter++;
    }




}
