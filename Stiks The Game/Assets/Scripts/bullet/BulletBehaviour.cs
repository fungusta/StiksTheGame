using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Jason
 * Date: 8 Aug 2022
 * 
 * Class that deals with destruction of bullets
 */

public class Bullet : MonoBehaviour

{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    private void Update()
    {

        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
