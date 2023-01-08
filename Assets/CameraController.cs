using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    public float cameraDistance;

    // Update is called once per frame
    void Update()
    {
        transform.position = new()
        {
            x = followTarget.transform.position.x,
            y = followTarget.transform.position.y,
            z = cameraDistance
        };
    }
}
