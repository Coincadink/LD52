using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.15f;
    private bool facingRight = true;

    public void FixedUpdate()
    {
        Vector3 translation = new Vector3();
        translation.x = Input.GetAxis("Horizontal") * speed;
        translation.y = Input.GetAxis("Vertical") * speed;

        transform.position += translation;

        if (translation.x < 0 && facingRight || translation.x > 0 && !facingRight) 
            Flip();
    }

    private void Flip()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
}
