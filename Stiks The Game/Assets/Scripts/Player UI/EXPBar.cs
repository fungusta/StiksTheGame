using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with slider in level UI for player Exp
 */
public class EXPBar : MonoBehaviour
{
    /*
     * Slider that moves when exp changes
     */
	public Slider slider;

    /*
     * Unity UI variables
     */
	public Gradient gradient;
	public Image fill;

    private void Start()
    {
        SetExp(0);
    }

    /*
     * Function that sets new maximum exp based on input param in EXP bar
     */
    public void SetMaxExp(int exp)
    {
        slider.maxValue = exp;

        fill.color = gradient.Evaluate(0f);
    }

    /*
     * Function that sets current exp based on input param in EXP bar
     */
    public void SetExp(int exp)
    {
        slider.value = exp;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
