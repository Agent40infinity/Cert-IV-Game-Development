using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    //Integers:
    public int damage;
    public int towerSelection;
    public int[,] towerSprites = new int[4, 3];

    //Float:
    public float movement;
    public float firerate;
    public float range;

    //Movement:
    public Transform WaypointParent; //Allows for the reference of a parent GameObject for the waypoints
    public float moveSpeed = 2f; //Determines the movement speed of the ship
    public float stoppingDistance = 0.1f; //Determines the distance the ship can be from the waypoint before it switches
    public Transform[] waypoints; //Array to store the transform data for each waypoint
    private int currentIndex = 1; //Creates a Index for the waypoints array


    void Start ()
    {
        Load();
	}

    void Update()
    {
        Firing();
        Movement();
    }

    void Firing()
    {

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

    private void Load()
    {
        switch (towerSelection)
        {
            case 1: //Cannon ship
                {
                    damage = 10;
                    range = 5f;
                    firerate = 8f;
                    movement = 2f;
                    //towerSprites[1, 0];
                }
                break;
            case 2:  //Gun ship
                {
                    damage = 1;
                    range = 10f;
                    firerate = 0.2f;
                    movement = 3f;
                    //towerSprites[2, 0];
                }
                break; //Support Ship
            case 3:
                {
                    damage = 0;
                    range = 3f;
                    firerate = 2f;
                    movement = 1f;
                    //towerSprites[3, 0];
                }
                break;
            case 4: //Bomb Tower
                {
                    damage = 3;
                    range = 20f;
                    firerate = 1.2f;
                    movement = 1f;
                    //towerSprites[4, 0];
                }
                break;

        }
    }
}
