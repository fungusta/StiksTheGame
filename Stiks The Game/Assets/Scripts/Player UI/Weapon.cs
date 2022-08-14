using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Jason
 * Date: 10 Aug 2022
 * 
 * Class that deals with range attacks
 */


public class Weapon : MonoBehaviour
{
    // where bullet will instantiate from
    public Transform firePoint;
    
    // bullet image
    public GameObject bulletPrefab;
    public float attackRate = 4f;
    float nextAttackTime = 0f;
    public Animator animator;

    /*
	 * Function that creates an input for attack adjusted to the frames of the computer player is using
	 */
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {    
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Attack");
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    /*
	 * Function that calls for attack(shoot)
	 */
    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
