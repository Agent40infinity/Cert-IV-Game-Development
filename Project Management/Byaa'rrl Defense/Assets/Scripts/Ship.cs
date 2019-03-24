using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ship : MonoBehaviour
{
    //Ship Movement:
    public Transform WaypointParent;
    public float moveSpeed = 2f;
    public float stoppingDistance = 0.1f;
    public Transform[] waypoints;
    private int currentIndex = 1;

    //Barrel Spawn:
    private int maxBarrels = 15; //move to Round later
    private int currentBarrels = 0; //move to Round Later
    private int spawnRate = 60; //move to Round later
    private int roundTimer = 0; //move to Round Later
    public GameObject Barrels;


    public void Start()
    {
        waypoints = WaypointParent.GetComponentsInChildren<Transform>();
    }
    public void Update()
    {
        Patrol();
        //if (Round.RoundStart == true)
        //{
            SpawnBarrels();
        //}
    }

    public void SpawnBarrels()
    {
        if (currentBarrels <= maxBarrels)
        {
            roundTimer++;
            if (roundTimer >= spawnRate)
            {
                Instantiate(Barrels, transform.position, transform.rotation);
                currentBarrels++;
                roundTimer = 0;
            }
        }
    }

    public void Patrol()
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

