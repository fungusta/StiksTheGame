using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Jason
 * Date: 10 Aug 2022
 * 
 * Class that deals with Enemies Health as well as damage taken with death interaction
 */
public class EnemyHealth : MonoBehaviour
{   public Animator animator;

    //max health of enemy
    public int maxHealth = 100;
    
    //current health
    public int currentHealth;

    public int expGiven;
    //amount of xp Enemy is worth

    public LevelSystem playerLevel;

    public bool Rigidbody2D { get; private set; }

    void Start()
    {
        //starts the level with full health and worth 5 XP
        currentHealth = maxHealth;
        expGiven = 5;
    }

    void Update()
    {    
        // player is tagged to a level system
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>();
    }

    /*
	 * Function that reduces the enemies current health by the input int
	 * if current health less than 0, the player dies
	 */
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Play hurt animation
        animator.SetTrigger("Hurt");
        //Debug.Log("damage taken by enemy" + damage);
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /*
	 * Function that activates when enemy health < 0 (death)
	 */
    public void Die()
    {
        //Debug.Log("Enemy died!");
        //Die animation
        animator.SetBool("IsDead", true);

        //disable the enemy AI when dead
        GetComponent<Collider2D>().enabled = false;
        Rigidbody2D = false;
        this.enabled = false;
        GetComponent<ImprovedPatrol>().enabled = false;
        
        //Debug.Log("Exp given" + expGiven);
        Destroy(gameObject);
        playerLevel.GainExp(expGiven);
    }

}
