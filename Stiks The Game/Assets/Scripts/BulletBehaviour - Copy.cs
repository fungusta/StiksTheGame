using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour{

    public float speed;
    private float direction = 0f;

    private Transform player;
    private Vector2 target;

    public GameObject impactEffect;
    public int damage = 20;

    void Start()
    {
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

    
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            DestroyProjectile();
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(impactEffect);
        Destroy(gameObject);
    }
    
}
