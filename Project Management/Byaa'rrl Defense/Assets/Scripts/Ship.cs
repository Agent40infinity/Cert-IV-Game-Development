using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ship : MonoBehaviour
{
    public Transform WaypointParent;
    public float moveSpeed = 2f;
    public float stoppingDistance = 0.1f;

    public Transform[] waypoints;
    private int currentIndex = 1;
    void Start()
    {
        waypoints = WaypointParent.GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        Patrol();
    }
    void Patrol()
    {
        Transform point = waypoints[currentIndex];
        float distance = Vector2.Distance(transform.position, point.position);
        if (distance < stoppingDistance)
        {
            currentIndex++;
        }
        if (currentIndex == waypoints.Length)
        {
            currentIndex = 1;
        }
        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);
    }
}

