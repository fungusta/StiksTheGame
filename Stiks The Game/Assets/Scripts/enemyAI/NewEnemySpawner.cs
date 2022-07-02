using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemySpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;

    public GameObject[] enemies;
    public float minTimeBtwSpawns;
    public float maxTimeBtwSpawns;
    public bool canSpawn;
    public float spawnTime;
    public int enemiesInRoom;
    public bool spawnerDone;
    public GameObject spawnerDoneGameObject;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime < 0)
        {
            canSpawn = false;
        }
    }

    void SpawnEnemy()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        float timeBtwSpawns = Random.Range(minTimeBtwSpawns, maxTimeBtwSpawns);

        if(canSpawn)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], 
                        currentPoint.transform.position, 
                        Quaternion.identity);
            enemiesInRoom++;
        }

        Invoke("SpawnEnemy", timeBtwSpawns);
        if(spawnerDone)
        {
            //Done spawning
            spawnerDoneGameObject.SetActive(true);
        }
    }
}
