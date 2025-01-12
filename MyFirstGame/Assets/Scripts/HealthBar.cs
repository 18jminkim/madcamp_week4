﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        slider = GetComponent<Slider>();
        //fill = GetComponent<Image>();
    }


    public void setMaxHealth(int health)
    {
        Debug.Log(slider);
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }


    public void setHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }
}
