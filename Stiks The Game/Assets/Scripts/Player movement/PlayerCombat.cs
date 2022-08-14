using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Jason
 * Date: 10 Aug 2022
 * 
 * Class that deals with the players attack damage as well 
 * the player attack animations
 */

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    // range of attack
    public float attackRange = 0.5f;

    // attack damage
    public int attackDamage = 40;

    // rate of attack
    public float attackRate = 4f;
    float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
        // Attack is adjusted according to the frame rate of the player's computer
    {   if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    /*
	 * Function that calls for attack
	 */
    void Attack()
    {
        // Attack Animation
        animator.SetTrigger("Attack");

        // Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Debug.Log(hitEnemies.Length);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }


    }

    /*
	 * Function shows the attack radius of the player model
	 */
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) 
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void ChangeAttackDamage(int i)
    {
        attackDamage += i;
    }

}


