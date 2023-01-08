using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int MaxHealth;
    private int health;

    protected void Start()
    {
        health = MaxHealth;
    }

    public void Damage(int damage)
    {
        Debug.Log("ouch");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
