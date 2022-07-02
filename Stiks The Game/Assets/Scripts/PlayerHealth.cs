using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	//For when damage taken has been implemented
	//public Animator animator;
	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;
	public bool Rigidbody2D { get; private set; }

	public bool damageReductionActive;
	//Reduction is in 0 to 1
	public float dmgReduction;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		damageReductionActive = false;
		dmgReduction = 0f;
	}	

	public void TakeDamage(int damage)
	{
		if(damageReductionActive)
        {
            GetComponent<WarriorAbility>().Reflect(damage);
			damage = (int) Mathf.Floor(damage * (1 - dmgReduction));
        }

		currentHealth -= damage;
		//Debug.Log("damage taken by hero" + damage);
		healthBar.SetHealth(currentHealth);
		

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public void Regen(int health)
    {
		if (currentHealth + health <= 100)
		{
			currentHealth += health;
			healthBar.SetHealth(currentHealth);
		}
	}

	public void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


	public void DamageReduction(float dmgRed)
    {
		dmgReduction = dmgRed;
		damageReductionActive = true;
	}

	//To deactive damage reduction
	public void DamageReduction()
    {
		dmgReduction = 0f;
		damageReductionActive = false;
    }
}