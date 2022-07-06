using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;

    private void Start()
    {
        SetExp(0);
    }

    public void SetMaxExp(int exp)
    {
        slider.maxValue = exp;

        //fill.color = gradient.Evaluate(0f);
    }

    public void SetExp(int exp)
    {
        slider.value = exp;

        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
