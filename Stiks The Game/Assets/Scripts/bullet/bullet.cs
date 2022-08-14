using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Jason
 * Date: 10 Aug 2022
 * 
 * Class that deals with the properties of projectiles
 */


public class bullet : MonoBehaviour
{
    // speed of bullet
    public float speed = 20f;

    //damage of bullet
    public int damage = 20;

    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    /*
     * Function that creates an impact animation and damage
     */
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(impactEffect);
        Destroy(gameObject);
    }

    
}
