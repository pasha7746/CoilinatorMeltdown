using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodePathCluster_Start : MonoBehaviour
{
    private List<NodePath> listOfRoutes = new List<NodePath>();
    [HideInInspector]
    public FlightGrid connectedFlightGrid;

    public bool isPatrolPath;

    // Use this for initialization
    void Start()
    {
        listOfRoutes = GetComponentsInChildren<NodePath>().ToList();
        listOfRoutes.ForEach((a) => a.CustomStart());
        if (!isPatrolPath)
        {
            DetectConnectedFlightGrid();
        }

    }

    public NodePath SelectRandomNode()
    {
        int temp = Random.Range(0, listOfRoutes.Count);
        // print(temp);
        return listOfRoutes[temp];
    }

    public void DetectConnectedFlightGrid()
    {
        List<Collider> tempListOfOverlaps = Physics.OverlapBox(listOfRoutes[listOfRoutes.Count - 1].listOfNodes[listOfRoutes[listOfRoutes.Count - 1].listOfNodes.Count - 1].transform.position, new Vector3(1, 1, 1)).ToList();

        connectedFlightGrid = tempListOfOverlaps.Find((a) => a.GetComponent<FlightGrid>()).GetComponent<FlightGrid>();

    }
}
