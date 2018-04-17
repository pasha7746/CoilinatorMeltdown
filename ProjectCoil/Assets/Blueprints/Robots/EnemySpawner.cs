using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private GameObject robotCache;
    public List<NodePathCluster_Start> listOfConnectedFlightGrid;
    public List<NodePathCluster_Start> listOfConnectedPaths;
    public event Action OnCompleteSpawn;

    public void StartSpawning(MasterSpawnController.TypeOfEnemyInWave spawnData)
    {
        StartCoroutine(Spawn(spawnData));

    }

    public IEnumerator Spawn(MasterSpawnController.TypeOfEnemyInWave spawnData)
    {
        int robotsToSpawn = spawnData.number;
        while (true)
        {
            EnemyCounter_Static.GlobalCounter_AddEnemy();
            robotCache = Instantiate(spawnData.spawnedObject);
            robotCache.transform.position = transform.position;

            switch (spawnData.typeOfEnemy)
            {
                case MasterSpawnController.EnemyType.DroneRoam:
                    robotCache.GetComponent<FlightPathFinding>().myPathCluster = listOfConnectedFlightGrid[Random.Range(0, listOfConnectedFlightGrid.Count)];
                    break;
                case MasterSpawnController.EnemyType.DronePatrol:
                    break;
                case MasterSpawnController.EnemyType.GroundTest:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            robotsToSpawn--;


            if (robotsToSpawn <= 0)
            {
                print("all done");
                break;
            }
            yield return new WaitForSeconds(spawnData.spawnDelays);

            yield return null;
        }

        if (OnCompleteSpawn != null) OnCompleteSpawn();
        yield return null;
    }
}
