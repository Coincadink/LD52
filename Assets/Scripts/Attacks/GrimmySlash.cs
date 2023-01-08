using UnityEngine;

public class GrimmySlash : Attack
{
    public float DistanceFromPlayer;

    public new void Start()
    {
        base.Start();

        var angle = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Owner.transform.position;
        angle.z = 0;
        angle = angle.normalized;
        transform.position += angle * DistanceFromPlayer;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + 270);
    }
}
