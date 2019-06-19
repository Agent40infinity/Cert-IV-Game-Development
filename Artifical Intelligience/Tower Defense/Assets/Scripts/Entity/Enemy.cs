using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public Transform target;

    private NavMeshAgent agent;
    private int health = 0;

	void Start () //Gets components needed and sets the health up
    {
        health = maxHealth; 
        agent = GetComponent<NavMeshAgent>(); //Get NavMeshAgent
        agent.SetDestination(target.position); //Follow desitination
	}
	
	void Update ()
    {
		
	}
}
