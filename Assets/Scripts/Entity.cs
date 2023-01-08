using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
<<<<<<< Updated upstream
    public int maxHealth;
=======
    public int MaxHealth;
    public Slider slider;
>>>>>>> Stashed changes
    private int health;

    protected void Start()
    {
<<<<<<< Updated upstream
        health = maxHealth;
=======
        health = MaxHealth;

        slider.maxValue = MaxHealth;
        slider.value = health;
>>>>>>> Stashed changes
    }

    public void Damage(int damage)
    {
        Debug.Log("ouch");

        health -= damage;
        slider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
