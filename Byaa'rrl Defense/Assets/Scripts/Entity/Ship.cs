using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ship : MonoBehaviour
{
    //Ship Movement:
    public Transform WaypointParent; //Allows for the reference of a parent GameObject for the waypoints
    public float moveSpeed = 2f; //Determines the movement speed of the ship
    public float stoppingDistance = 0.1f; //Determines the distance the ship can be from the waypoint before it switches
    public Transform[] waypoints; //Array to store the transform data for each waypoint
    private int currentIndex = 1; //Creates a Index for the waypoints array

    //Barrel Spawn:
    public GameObject barrels; //Allows for the reference of the barrel Prefab
    public static bool roundStart = false; //Determines whether or not the round has started (referenced in ship)
    public static float distanceP1; //Used to calculate the distance between the ship and Path 1
    public static float distanceP2; //Used to calculate the distance between the ship and Path 2
    public static float distanceP3; //Used to calculate the distance between the ship and Path 3
    public Transform Path_1; //Creates a reference for Path 1's transform
    public Transform Path_2; //Creates a reference for Path 2's transform
    public Transform Path_3; //Creates a reference for Path 3's transform

    public Transform barrelHolder;


    public void Start()
    {
        waypoints = WaypointParent.GetComponentsInChildren<Transform>(); //creates the waypoints array based on the parent
    }
    public void Update()
    {
        Movement();
        CalculateDistance();
        if (roundStart == true) //Determines if the round started
        {
            SpawnBarrels();
        }
    }

    public void SpawnBarrels()
    {
        if (Rounds.currentBarrels < Rounds.maxBarrels) //Checks whether or not the max amount of barrels have spawned for that round
        {
            Debug.Log("Spawning Barrels");
            Rounds.roundTimer++;
            if (Rounds.roundTimer >= Rounds.spawnRate) //Makes sure that the barrels spawn at the same rate as the set spawn rate
            {
                Instantiate(barrels, transform.position, transform.rotation, barrelHolder);
                Rounds.currentBarrels++;
                Rounds.roundTimer = 0;
            }
        }
        else if (Rounds.currentBarrels == Rounds.maxBarrels) //Creates a gateway statement when the max amount have barrels has been met
        {
            Debug.Log("Spawning Complete");
            roundStart = false;
            Rounds.currentBarrels = 0;  
            Rounds.endRound = true;
        }
    }
    public void CalculateDistance() //Calculates the distance between the Path's positions and the Ship
    {
        distanceP1 = Vector2.Distance(transform.position, Path_1.position);
        distanceP2 = Vector2.Distance(transform.position, Path_2.position);
        distanceP3 = Vector2.Distance(transform.position, Path_3.position);
    }

    public void Movement() //Allows the ship to move between waypoints
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

