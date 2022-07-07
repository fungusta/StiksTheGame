using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;
    public int expGiven;
    public LevelSystem playerLevel;

    public bool Rigidbody2D { get; private set; }

    void Start()
    {
        currentHealth = maxHealth;
        expGiven = 5;
    }

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

    public void Die()
    {
        //Debug.Log("Enemy died!");
        //Die animation
        animator.SetBool("IsDead", true);
        //disable
        GetComponent<Collider2D>().enabled = false;
        Rigidbody2D = false;
        this.enabled = false;
        GetComponent<ImprovedPatrol>().enabled = false;
        
        //Debug.Log("Exp given" + expGiven);
        Destroy(gameObject);
        playerLevel.GainExp(expGiven);
    }

}
