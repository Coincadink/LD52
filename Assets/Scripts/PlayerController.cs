using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.15f;
    private bool facingRight = true;

    public GameObject Attack;

    public void FixedUpdate()
    {
        Vector3 translation = new()
        {
            x = Input.GetAxis("Horizontal") * speed,
            y = Input.GetAxis("Vertical") * speed
        };

        transform.position += translation;

        if (translation.x < 0 && facingRight || translation.x > 0 && !facingRight) 
            Flip();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var newAtt = Instantiate(Attack, transform.position, transform.rotation);
            newAtt.GetComponent<Attack>().Owner = gameObject;
        }
    }

    private void Flip()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
}
