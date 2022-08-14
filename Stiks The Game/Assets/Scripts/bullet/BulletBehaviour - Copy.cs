using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Jason
 * Date: 8 Aug 2022
 * 
 * Class that deals with behaviour of a homing bullet
 */
public class BulletBehaviour : MonoBehaviour{
    
    // speed of bullet
    public float speed;

    private float direction = 0f;

    private Transform player;
    private Vector2 target;

    // impact animataion when bullet hits target
    public GameObject impactEffect;

    //bullet damage
    public int damage = 20;

    void Start()
    {   
        // bullet will target player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

        //bullet to face correct direction
        if (direction < 0) //moving right
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (direction < 0) //moving left
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }

    
    void Update()
    {
        

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    /*
     * Function that destroys projectile 
     */
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    /*
     * Function that detects collisions and then destroys the bullet
     */
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            DestroyProjectile();
        }
         // bullet is destroyed
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(impactEffect);
        Destroy(gameObject);
    }
    
}
