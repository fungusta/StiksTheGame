using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Jason
 * Date: 10 Aug 2022
 * 
 * Class that deals with the movement of enemy Ai, patrol
 */

public class ImprovedPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    // speed of enemies, detection radius and rate of fire
    public float walkSpeed, range, timeBTWShots, shootSpeed;
    private float distToPlayer;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn, canShoot;

    public Rigidbody2D rb;
    
    //position of enemies
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    public Transform player, shootPos;
    public GameObject bullet;


    

    void Start()
    {
        mustPatrol = true;
        canShoot = true;
        
    }
	
    //enemies wont collide with each other
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
        //detection of players
    {    
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.position);
        
        //If player is in AI's detection range, AI will turn to face the direction player is at
        if (distToPlayer <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

            mustPatrol = false;
            rb.velocity = Vector2.zero;
            if (canShoot)
                StartCoroutine(Shoot());

        }
        else
        {
            mustPatrol = true;
        }

    }

    // a circle body collider that touches the ground and prevents enemies from falling off platforms
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
        // allows for AI to turn at walls as well as end of platforms
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    /*
     * Function that allows AI to turn and not get stuck
     */
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    // shoots at players who are within detection radius
    IEnumerator Shoot()
    {
        canShoot = false;
        
        // cooldown for shots
        yield return new WaitForSeconds(timeBTWShots);

        //creation of bullet
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);

        // speed of bullet adjusted for any computer
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
        canShoot = true;
    }
    
}
