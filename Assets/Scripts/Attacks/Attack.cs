using UnityEngine;

public class Attack : MonoBehaviour
{
    public int Lifetime;
    private int age;

    public int Damage;
    public GameObject Owner { protected get; set; }

    public void Start()
    {
        age = 0;
    }

    public void FixedUpdate()
    {
        age++;
        if (age > Lifetime)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != Owner)
        {
            collision.gameObject.GetComponent<Entity>().Damage(Damage);
        }
    }
}
