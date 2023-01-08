using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D m_rigidbody;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = new Vector2
        {
            x = Random.value - 0.5f,
            y = Random.value - 0.5f
        }.normalized;

        Debug.Log(direction);

        m_rigidbody.position += direction * Speed;
    }
}
