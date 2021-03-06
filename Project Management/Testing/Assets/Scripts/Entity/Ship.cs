﻿using System.Collections;
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
    public GameObject barrels;
    public static float distanceP1;
    public static float distanceP2;
    public static float distanceP3;
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
        CalculateDistance();
        if (Rounds.roundStart == true)
        {
            SpawnBarrels();
        }
    }

    public void SpawnBarrels()
    {
        if (Rounds.currentBarrels < Rounds.maxBarrels)
        {
            Debug.Log("Spawning Barrels");
            Rounds.roundTimer++;
            if (Rounds.roundTimer >= Rounds.spawnRate)
            {
                Instantiate(barrels, transform.position, transform.rotation);
                Rounds.currentBarrels++;
                Rounds.roundTimer = 0;
            }
        }
        else if (Rounds.currentBarrels == Rounds.maxBarrels)
        {
            Debug.Log("Spawning Complete");
            Rounds.roundStart = false;
            Rounds.currentBarrels = 0;
            Rounds.endRound = true;
        }
    }
    public void CalculateDistance()
    {
        distanceP1 = Vector2.Distance(transform.position, Path_1.position);
        distanceP2 = Vector2.Distance(transform.position, Path_2.position);
        distanceP3 = Vector2.Distance(transform.position, Path_3.position);
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

