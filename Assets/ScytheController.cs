using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheController : MonoBehaviour
{
    public float meleeDamage;
    public float meleeSpeed;
    public float meleeArcLength;

    private void Update()
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

    }
}
