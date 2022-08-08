using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Peter
 * Date: 8 Aug 2022
 * 
 * Class that deals with the players health as well as the damage taken by player
 * and the player death interaction
 */
public class PlayerHealth : MonoBehaviour
{
	//Maximum Health of player
	public int maxHealth = 100;

	//Current Health of player
	public int currentHealth;

	//UI Healthbar
	public HealthBar healthBar;

	public bool Rigidbody2D { get; private set; }

	//Whether there is damage reduction
	public bool damageReductionActive;

	//The percentage of damage that is reduced per instance of damage taken
	public float dmgReduction;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		damageReductionActive = false;
		dmgReduction = 0f;
	}	

	/*
	 * Function that reduces the players current health by the input int
	 * if current health less than 0, the player dies
	 */
	public void TakeDamage(int damage)
	{
		if(damageReductionActive)
        {
            GetComponent<WarriorAbility>().Reflect(damage);
			damage = (int) Mathf.Floor(damage * (1 - dmgReduction));
        }

		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	/*
	 * Function that regenerates health to the player based on the int input 
	 * in the param
	 */
	public void Regen(int health)
    {
		if (currentHealth + health <= maxHealth)
		{
			currentHealth += health;
			healthBar.SetHealth(currentHealth);
			
		}
	}

	/*
	 * Function that deals with restarting the game when the player dies
	 */
	public void Die()
	{
		Regen(maxHealth - currentHealth);
		DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	/*
	 * Function that deals with activating the damage reduction
	 */
	public void DamageReduction(float dmgRed)
    {
		dmgReduction = dmgRed;
		damageReductionActive = true;
	}

	/*
	 * Function that is used to deactive damage reduction
	 */
	public void DamageReduction()
    {
		dmgReduction = 0f;
		damageReductionActive = false;
    }

	/*
	 * Function that is used to change the max health of the player which
	 * also increases current health
	 */
	public void ChangeMaxHealth(int increase)
    {
		//Debug.Log("Max Health increased by" + increase);
		maxHealth += increase;
		healthBar.ChangeMaxHealth(maxHealth);
		Regen(increase);
	}
}