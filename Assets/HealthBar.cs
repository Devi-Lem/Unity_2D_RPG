using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI hp;

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        hp.text = $"HP:{maxHealth}/{maxHealth}";
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        hp.text = health.ToString();
        hp.text = $"HP:{health}/{slider.maxValue}";
    }

}
