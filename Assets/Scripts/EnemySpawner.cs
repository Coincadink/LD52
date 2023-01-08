using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySpawner : MonoBehaviour
{
    public int Cooldown;
    private int spawnTimer;

    public GameObject Enemy;
    public GameObject Player;

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
            GameObject enemy = Instantiate(Enemy, transform.position, transform.rotation);
            AIDestinationSetter targetScript = enemy.GetComponent<AIDestinationSetter>();
            targetScript.target = Player.transform;
        }
    }
}
