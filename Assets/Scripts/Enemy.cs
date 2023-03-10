using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathfinding;

public class Enemy : Entity
{
    public Transform target;
    
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;

    public GameObject bullet;

    Path path;
    int currentWaypoint = 0;
    // bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    new void Start()
    {
        base.Start();
        
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating(nameof(UpdatePath), 0f, 0.5f);
        InvokeRepeating(nameof(FireBullet), 1f, 1f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error) 
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FireBullet()
    {
        var newBullet = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Bullet>();
        newBullet.Owner = transform;
        newBullet.Direction = target.position - transform.position;
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            // reachedEndOfPath = true;
            return;
        } else
        {
            // reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = speed * Time.deltaTime * direction;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.01f && force.x > 0f)
        {
            enemyGFX.localScale = new Vector3(0.2f, 0.2f, 1f);
        } 
        else if (rb.velocity.x <= -0.01f && force.x < 0f)
        {
            enemyGFX.localScale = new Vector3(-0.2f, 0.2f, 1f);
        }
    }
}
