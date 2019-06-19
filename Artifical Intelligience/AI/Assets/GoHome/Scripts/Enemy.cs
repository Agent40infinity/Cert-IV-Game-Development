using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum State //Used to reference Patrol and Seek with ease.
    {
        Patrol, Seek
    }
    public State currentState;
    public Transform WaypointParent;
    public float moveSpeed = 15f;
    public float stoppingDistance = 1f;

    public Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;
    private Transform target;
    void Start() //Used to get the components required from attached GameObject and children of the parent specified
    {
        waypoints = WaypointParent.GetComponentsInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update() //Used to switch between the two states (Patrol and Seek)
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Seek:
                Seek();
                break;
            default:
                Patrol();
                break;
        }
    }
    void Patrol() //Used to make the enemy travel between the waypoints speificed under the parented waypoint gameobject/
    {
        Transform point = waypoints[currentIndex];
        float distance = Vector3.Distance(transform.position, point.position);
        if (distance < stoppingDistance) //Checks if the enemy has become in range of the checkpoint and then sets it's new directive 
        {
            currentIndex++;
        }
        if (currentIndex == waypoints.Length) //Used to reset the enemy's directive once they have finished cycling through the waypoints
        {
            currentIndex = 1;
        }
        agent.SetDestination(point.position); //Makes the enemy move between the waypoints (point)
    }
    void Seek() //Used to make the enemy follow the player
    {
        agent.SetDestination(target.position);
    }
    private void OnTriggerEnter(Collider other) //Checks if the player is within range so that they can be targeted
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.transform;
            currentState = State.Seek;
        }
    }
    private void OnTriggerExit(Collider other) //Used to return the enemy back to the Patrol state once the player is out of range
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentState = State.Patrol;

        }
    }
}
