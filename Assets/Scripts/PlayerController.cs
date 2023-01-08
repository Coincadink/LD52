using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.15f;
    public GameObject Attack;
    public GameObject Scythe;

    private bool facingRight = true;
    private Rigidbody2D rb;

    public void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
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
            var newAtt = Instantiate(Attack, transform.position, transform.rotation);
            newAtt.GetComponent<Attack>().Owner = gameObject;
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
 
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;
 
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        Scythe.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 210));
    }

    private void Flip()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Scythe.transform.localScale = new Vector3(-Scythe.transform.localScale.x, Scythe.transform.localScale.y, Scythe.transform.localScale.z); // TODO: Don't do this.
	}
}
