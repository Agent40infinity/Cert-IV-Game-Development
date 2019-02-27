using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent; //Reference to the NavMeshAgent
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.SetDestination(target.position); //Updates destionation of NavMeshAgent
	}
}
