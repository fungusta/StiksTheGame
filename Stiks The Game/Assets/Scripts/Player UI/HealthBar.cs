using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with slider in health UI in game
 */
public class HealthBar : MonoBehaviour
{
	/*
	 * UI variables for health bar
	 */
	public Slider slider;
	public Gradient gradient;
	public Image fill;

	/*
	 * Function that sets initial maximum health in health bar
	 */
	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f);
	}

	/*
	 * Function that changes max health after initial max in health bar
	 */
	public void ChangeMaxHealth(int health)
    {
		slider.maxValue = health;

		fill.color = gradient.Evaluate(1f);
	}

	/*
	 * Function that changes current health in health bar
	 */
	public void SetHealth(int health)
	{
		slider.value = health;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}