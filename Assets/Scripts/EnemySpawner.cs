using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int Cooldown;
    private int spawnTimer;

    public GameObject Enemy;

    private void Start()
    {
        spawnTimer = Cooldown;
    }

    private void FixedUpdate()
    {
        spawnTimer--;
        if (spawnTimer == 0)
        {
            spawnTimer = Cooldown;
            Instantiate(Enemy, transform.position, transform.rotation);
        }
    }
}
