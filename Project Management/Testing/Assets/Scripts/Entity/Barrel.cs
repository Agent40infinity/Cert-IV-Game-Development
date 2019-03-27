using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float stoppingDistance = 0.1f;
    public Transform[,] waypoints = new Transform[3,5];
    public int currentIndexX = 0;
    public int currentIndexY = 1;
    public float distanceP1;
    public float distanceP2;
    public float distanceP3;

    public static int health = 20; //Move to Health later    

    void Start()
    {
        LoadArray();
        //waypoints = WaypointParent.GetComponentsInChildren<Transform>();
        //waypoints[waypoints.Length+1] = GameObject.Find("Endpoint").transform;
        CalculateDistance();
    }

    void Update()
    {
        Patrol();
        Debug.Log(health);
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Endpoint")
        {
            Debug.Log("No u");
            health--;
            Destroy(this.gameObject);
        
        }

    }

    public void CalculateDistance()
    {
        distanceP1 = Ship.distanceP1;
        distanceP2 = Ship.distanceP2;
        distanceP3 = Ship.distanceP3;

        if (distanceP1 < distanceP2)
        {
            if (distanceP1 < distanceP3)
            {
                currentIndexX = 0;
            }
            else
            {
                currentIndexX = 2;
            }
        }
        else if (distanceP2 < distanceP3)
        {
            currentIndexX = 1;
        }
        else
        {
            currentIndexX = 2;
        }
    }

    public void Patrol()
    {
        Transform point = waypoints[currentIndexX,currentIndexY];
        print(currentIndexX + " - " + currentIndexY);

        float distance = Vector2.Distance(transform.position, point.position);
        
        if (distance < stoppingDistance)
        {
            currentIndexY++;
        }
        if (currentIndexY == 5)
        {
            currentIndexY = 1;
        }
        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);
    }

    public void LoadArray()
    {
        //WaypointParent.GetComponentsInChildren<Transform>();
        waypoints[0,0] = GameObject.Find("Path_1").transform;
        waypoints[0,1] = GameObject.Find("Waypoint1-1").transform;
        waypoints[0,2] = GameObject.Find("Waypoint1-2").transform;
        waypoints[0,3] = GameObject.Find("Waypoint1-3").transform;
        waypoints[0,4] = GameObject.Find("Endpoint").transform;

        waypoints[1,0] = GameObject.Find("Path_2").transform;
        waypoints[1,1] = GameObject.Find("Waypoint2-1").transform;
        waypoints[1,2] = GameObject.Find("Waypoint2-2").transform;
        waypoints[1,3] = GameObject.Find("Waypoint2-3").transform;
        waypoints[1,4] = GameObject.Find("Endpoint").transform;

        waypoints[2,0] = GameObject.Find("Path_3").transform;
        waypoints[2,1] = GameObject.Find("Waypoint3-1").transform;
        waypoints[2,2] = GameObject.Find("Waypoint3-2").transform;
        waypoints[2,3] = GameObject.Find("Waypoint3-3").transform;
        waypoints[2,4] = GameObject.Find("Endpoint").transform;
    }
}
