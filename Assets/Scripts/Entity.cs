using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public int MaxHealth;
    public Slider slider;
    private int health;

    protected void Start()
    {
        health = MaxHealth;

        slider.maxValue = MaxHealth;
        slider.value = health;
    }

    public void Damage(int damage)
    {
        health -= damage;
        slider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
