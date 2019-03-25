using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrels : MonoBehaviour
{
    public Transform WaypointParent;
    public float moveSpeed = 2f;
    public float stoppingDistance = 0.1f;
    public Transform[,] waypoints = new Transform[3,5];
    public int currentIndexX = 0;
    public int currentIndexY = 1;
    

    void Start()
    {
        LoadArray();
        //waypoints = WaypointParent.GetComponentsInChildren<Transform>();
        //waypoints[waypoints.Length+1] = GameObject.Find("Endpoint").transform;

    }

    void Update()
    {
        Patrol();
    }

    public void Patrol()
    {
        Transform point = waypoints[currentIndexX,currentIndexY];
        print(currentIndexX + " - " + currentIndexY);

        if(point == null)
        {
            print("Brah. Your shits fucked");
        }

        float distance = Vector2.Distance(transform.position, point.position);
        
        if (distance < stoppingDistance)
        {
            currentIndexY++;
        }
        if (currentIndexY == waypoints.Length)
        {
            currentIndexY = 1;
        }
        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);
    }

    public void LoadArray()
    {
        //WaypointParent.GetComponentsInChildren<Transform>();
        print("Loading");
        waypoints[0,0] = GameObject.Find("Path_1").transform;
        waypoints[0,1] = GameObject.Find("Waypoint1-1").transform;
        waypoints[0,2] = GameObject.Find("Waypoint1-2").transform;
        waypoints[0,3] = GameObject.Find("Waypoint1-3").transform;
        waypoints[0,4] = GameObject.Find("Endpoint").transform;

        waypoints[1, 0] = GameObject.Find("Path_2").transform;
        waypoints[1, 1] = GameObject.Find("Waypoint2-1").transform;
        waypoints[1, 2] = GameObject.Find("Waypoint2-2").transform;
        waypoints[1, 3] = GameObject.Find("Waypoint2-3").transform;
        waypoints[1, 4] = GameObject.Find("Endpoint").transform;

        waypoints[2, 0] = GameObject.Find("Path_3").transform;
        waypoints[2, 1] = GameObject.Find("Waypoint3-1").transform;
        waypoints[2, 2] = GameObject.Find("Waypoint3-2").transform;
        waypoints[2, 3] = GameObject.Find("Waypoint3-3").transform;
        waypoints[2, 4] = GameObject.Find("Endpoint").transform;
        print("Loaded");
    }
}
