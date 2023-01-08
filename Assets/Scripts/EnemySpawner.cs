using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Runtime.Serialization;

public class EnemySpawner : MonoBehaviour
{
    public float cooldown = 1.0f;
    
    public GameObject Enemy;
    public GameObject Player;

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, cooldown);
    }

    void Spawn()
    {
        GameObject enemy = Instantiate(Enemy, transform.position, transform.rotation);

        Enemy script = enemy.GetComponent<Enemy>();
        script.target = Player.transform;
    }
}
