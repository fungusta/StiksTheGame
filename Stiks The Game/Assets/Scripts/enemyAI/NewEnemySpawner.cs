using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Jason
 * Date: 10 Aug 2022
 * 
 * Class that deals with the spawning of enemies
 */


public class NewEnemySpawner : MonoBehaviour
{
    // indication of spawn points
    public GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;

    //type of enemy to spawn
    public GameObject[] enemies;

    // duration between spawns, randomised
    public float minTimeBtwSpawns;
    public float maxTimeBtwSpawns;
    public bool canSpawn;
    public float spawnTime;

    //max number of enemies that can be in the same area
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

    /*
     * Function that allows the spawning of enemies at spawn locations
     */
    void SpawnEnemy()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];

        //random time allocations for spawns
        float timeBtwSpawns = Random.Range(minTimeBtwSpawns, maxTimeBtwSpawns);

        if(canSpawn)
        {
            // creation of enemies
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
