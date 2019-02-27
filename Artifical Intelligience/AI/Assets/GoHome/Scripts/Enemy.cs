using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform WaypointParent;
    public float moveSpeed = 15f;
    public float stoppingDistance = 1f;

    public Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;
    void Start()
    {
        waypoints = WaypointParent.GetComponentsInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Patrol();
    }
    void Patrol()
    {
        Transform point = waypoints[currentIndex];
        float distance = Vector3.Distance(transform.position, point.position);
        if (distance < stoppingDistance)
        {
            currentIndex++;
        }
        if (currentIndex == waypoints.Length)
        {
            currentIndex = 1;
        }
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed*Time.deltaTime);
        agent.SetDestination(point.position);
    }
}
