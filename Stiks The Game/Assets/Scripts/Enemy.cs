using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwshots;

    public GameObject projectile;
    public Transform player;
  
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwshots;
    }

    
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //move closer
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) 
        {
            transform.position = this.transform.position; //stop moving
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0) {

            Instantiate(projectile, transform.position, Quaternion.identity); //(what we wanna spawn, position, rotation)
            timeBtwShots = startTimeBtwshots;
                }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
       
    }

    internal void TakeDamage(int attackDamage)
    {
        throw new NotImplementedException();
    }
}
