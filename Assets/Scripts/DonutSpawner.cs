using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject donut;

    private int lastSpawnPosition = 0;

    private void Start()
    {
       SpawnDonut();
    }


    public void SpawnDonut()
    {
        int index = GetRandomPosition(lastSpawnPosition);
        lastSpawnPosition = index;
        Transform randomSpawnPoint = spawnPoints[index];

        //Atentar para que a posção
        Instantiate(donut, new Vector2(randomSpawnPoint.position.x, randomSpawnPoint.position.y), Quaternion.identity);

    }

    private int GetRandomPosition(int excludeLastPosition)
    {
        int index = Random.Range(0, spawnPoints.Length);

        while (index == excludeLastPosition)
        {
            index = Random.Range(0, spawnPoints.Length);
        }

        return index;
    }
}
