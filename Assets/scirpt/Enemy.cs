using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public float health = 100;

    public int worth = 50;
    private Transform target;
    private int wavepointINdEx = 0;

     void Start()
    {
        target = Waypoints.points[0];

    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerState.money -= worth;
        Destroy(gameObject);
    }

   void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoints();
        }
    }

     void GetNextWaypoints()
    {
        if(wavepointINdEx >= Waypoints.points.Length - 1)
        {
            EndPath();
            Destroy(gameObject);
            return;

        }
        wavepointINdEx++;
        target = Waypoints.points[wavepointINdEx];
    }

    void EndPath()
    {
        PlayerState.Lives--;
        Destroy(gameObject);
    }
}
