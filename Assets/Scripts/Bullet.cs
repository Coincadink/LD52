using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform Owner { set; private get; }
    public Vector2 Direction { set { _direction = value.normalized; } }
    private Vector2? _direction;

    public float speed;
    public int damage;

    private void FixedUpdate()
    {
        if (_direction is null) return;

        transform.position += speed * Time.deltaTime * (Vector3)_direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform != Owner)
        {
            if (collision.gameObject.TryGetComponent<Entity>(out var entityHandler))
                entityHandler.Damage(damage);
            if (!collision.gameObject.TryGetComponent<ScytheController>(out var _))
                Destroy(gameObject);
        }
    }
}
