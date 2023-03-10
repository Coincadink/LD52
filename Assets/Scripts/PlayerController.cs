using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    public GameObject scythe;
    private ScytheController scytheController;

    public float speed = 0.15f;

    private bool facingRight = true;
    private Rigidbody2D rb;

    new void Start() 
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        scytheController = scythe.GetComponent<ScytheController>();
    }

    public void FixedUpdate()
    {
        Vector2 translation = new()
        {
            x = Input.GetAxis("Horizontal") * speed,
            y = Input.GetAxis("Vertical") * speed
        };

        rb.position += translation;

        if (translation.x < 0 && facingRight || translation.x > 0 && !facingRight) 
            Flip();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            scytheController.Swing();
        }
    }

    private void Flip()
	{
		facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).Rotate(0, 180, 0);
        }
	}
}
