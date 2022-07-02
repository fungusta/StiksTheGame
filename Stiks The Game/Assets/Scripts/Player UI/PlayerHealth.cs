using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public Animator animator;
	public int maxHealth = 100;
	public int currentHealth;
	public int level = 3; 

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
	public void SavePlayer()
    {
		SaveSystem.SavePlayer(this);
    }
	public void LoadPlayer()
    {
		PlayerData data = SaveSystem.LoadPlayer();

		level = data.level;
		currentHealth = data.health;

		Vector3 position;
		position.x = data.position[0];
		position.y = data.position[1];
		position.z = data.position[2];
		transform.position = position;

	}
	void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	
}