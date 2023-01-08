using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Transform Target { protected get; set; }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if ((transform.position - Target.transform.position).magnitude <= attackDistance)
        //{
        //    var newAtt = Instantiate(attack, transform.position, transform.rotation);
        //    newAtt.GetComponent<EnemySlash>().Target = Target;
        //}
    }
}
