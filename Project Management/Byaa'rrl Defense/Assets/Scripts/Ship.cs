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
    public GameObject barrels;
    public float distanceP1;
    public float distanceP2;
    public float distanceP3;
    public Transform Path_1;
    public Transform Path_2;
    public Transform Path_3;


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
            CalculateDistance();
        //}
    }

    public void SpawnBarrels()
    {
        if (currentBarrels <= maxBarrels)
        {
            roundTimer++;
            if (roundTimer >= spawnRate)
            {
                Instantiate(barrels, transform.position, transform.rotation);
                currentBarrels++;
                roundTimer = 0;
            }
        }
    }
    public void CalculateDistance()
    {
        distanceP1 = Vector2.Distance(transform.position, Path_1.position);
        distanceP2 = Vector2.Distance(transform.position, Path_2.position);
        distanceP3 = Vector2.Distance(transform.position, Path_3.position);

        if (distanceP1 < distanceP2)
        {
            if (distanceP1 < distanceP3)
            {
                Barrels.currentIndexX = 1;
            }
            else
            {
                Barrels.currentIndexX = 3;
            }
        }
        else if (distanceP2 < distanceP3)
        {
            Barrels.currentIndexX = 2;
        }
        else
        {
            Barrels.currentIndexX = 3;
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

