using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    public GameObject enemy;

    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public int numberOfSpawns;
    private int currentNumOfSpawns = 0;

    
    // Update is called once per frame
    void Update()
    {
        if (currentNumOfSpawns == numberOfSpawns)
        {
            
        }
        else if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-8.4f, 8.4f);
            randY = Random.Range(-8.4f, 8.4f);
            whereToSpawn = new Vector2(randX, randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            currentNumOfSpawns++;
        }    
    }
}
