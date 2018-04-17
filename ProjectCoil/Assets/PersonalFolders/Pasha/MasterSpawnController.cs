using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSpawnController : MonoBehaviour
{
    public List<Barricade> listOfBarricades= new List<Barricade>();
    public int currentBarricadeIndex;
    public bool isPaused;
    public enum EnemyType
    {
        DroneRoam,
        DronePatrol,
        GroundTest
    }


    [System.Serializable]
    public struct TypeOfEnemyInWave
    {
        public EnemyType typeOfEnemy;
        public GameObject spawnedObject;
        public EnemySpawner spawnerToUse;
        public int number;
        public float spawnDelays;
    }
    [System.Serializable]
    public struct WaveData
    {
        public List<TypeOfEnemyInWave> listOfThingsToSpawnInWave;
        public int numberOfThingsLeftBeforeNextWave;
    }
    [System.Serializable]
    public struct BarricadeStopData
    {
        public List<WaveData> listOfWaves;
    }
    public List<BarricadeStopData> listOfBarricadeStops;

    public Coroutine RoundCoroutine;
    public Coroutine WaveCoroutine;

    private bool waveInProgress;

    private int wavesLeft;
     
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    public void LaunchWave()
    {
        RoundCoroutine = StartCoroutine(RoundSpawn());
    }

    public IEnumerator RoundSpawn()
    {
        wavesLeft = listOfBarricadeStops[currentBarricadeIndex].listOfWaves.Count;
        int localWavesLeft=0;
        WaveData tempData = new WaveData();
        
        while (true)
        {
            if (!isPaused)
            {
                if (localWavesLeft == wavesLeft)
                {
                    if (wavesLeft > 0)
                    {
                        if (!waveInProgress)
                        {
                            
                            WaveCoroutine = StartCoroutine(WaveSpawn(tempData));

                        }
                       

                    }
                    else
                    {
                        print("Round Complete");
                        break;
                    }
                }
                else
                {
                    localWavesLeft = wavesLeft;
                    int temp = (listOfBarricadeStops[currentBarricadeIndex].listOfWaves.Count - 1) - (wavesLeft - 1);

                    if (wavesLeft <= 0)
                    {
                        print("Round Complete");
                        break;
                    }

                    tempData = listOfBarricadeStops[currentBarricadeIndex].listOfWaves[temp];
                }
            }
            else
            {
                yield return new WaitForSeconds(1);
            }

            yield return null;
        }

        currentBarricadeIndex++;

        yield return null;
    }

    public IEnumerator WaveSpawn(WaveData data)
    {
        waveInProgress = true;
        bool waitingForWave = false;
        int spawningProcesses = 0;
        wavesLeft--;

        while (true)
        {
            if (!waitingForWave)
            {
                spawningProcesses = data.listOfThingsToSpawnInWave.Count;
                for (int i = 0; i < data.listOfThingsToSpawnInWave.Count; i++)
                {
                    data.listOfThingsToSpawnInWave[i].spawnerToUse.OnCompleteSpawn += () => { spawningProcesses--; };
                    data.listOfThingsToSpawnInWave[i].spawnerToUse.StartSpawning(data.listOfThingsToSpawnInWave[i]);
                }
                waitingForWave = true;
            }
            else
            {
                if (spawningProcesses == 0 )
                {
                    if (EnemyCounter_Static.enemyCount <= data.numberOfThingsLeftBeforeNextWave)
                    {
                        break;
                    }
                }
                
            }
            yield return null;

        }

        waveInProgress = false;
        yield return null;
    }
}
