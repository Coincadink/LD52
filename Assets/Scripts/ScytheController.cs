using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ScytheController : MonoBehaviour
{
    public int meleeDamage;
    public int meleeLength;
    public float meleeArcLength;
    public int meleeCooldown;

    private AttackState state;
    private enum AttackState
    {
        Melee,
        Throw,
        None
    }

    private int attackCooldownCounter;
    private int attackFrameCounter;

    private void Update()
    {
        if (state != AttackState.None) return;

        RotateTowardsMouse();
    }

    private void FixedUpdate()
    {
        if (attackCooldownCounter > 0) attackCooldownCounter--;

        switch (state)
        {
            case AttackState.Melee:
                transform.Rotate(0, 0, meleeArcLength / meleeLength);

                attackFrameCounter++;
                if (attackFrameCounter > meleeLength)
                {
                    state = AttackState.None;
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == transform.parent.transform) return;

        if (state == AttackState.Melee)
        {
            if (collision.gameObject.TryGetComponent<Entity>(out var entityHandler))
                entityHandler.Damage(meleeDamage);
            else if (collision.gameObject.TryGetComponent<Bullet>(out var bullet))
            {
                bullet.Owner = transform;
                //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Debug.Log((Vector2)(mousePos - transform.position));
                bullet.Direction = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.parent.transform.position;
            }
        }
            
    }

    private void RotateTowardsMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 210));
    }

    public void Swing()
    {
        if (attackCooldownCounter > 0) return;
        attackCooldownCounter = meleeCooldown;
        attackFrameCounter = 0;

        RotateTowardsMouse();

        state = AttackState.Melee;
        transform.Rotate(0, 0, -meleeArcLength / 2);        
    }

}
