using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public Animator animator;
	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;
	public bool Rigidbody2D { get; private set; }

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	// Update is called once per frame
	

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		

		healthBar.SetHealth(currentHealth);

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	
}