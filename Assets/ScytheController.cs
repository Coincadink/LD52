using UnityEngine;

public class ScytheController : MonoBehaviour
{
    public float meleeDamage;
    public float meleeLength;
    public float meleeArcLength;

    private AttackState state;
    private enum AttackState
    {
        Melee,
        Throw,
        None
    }

    private int attackFrameCounter;

    private void Update()
    {
        if (state != AttackState.None) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 210));
    }

    private void FixedUpdate()
    {
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
        Debug.Log("collided");
    }

    public void Swing()
    {
        attackFrameCounter = 0;
        state = AttackState.Melee;
        transform.Rotate(0, 0, -meleeArcLength / 2);        
    }

}
