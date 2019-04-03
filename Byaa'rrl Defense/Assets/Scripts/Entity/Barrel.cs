using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    //Movement and Loading
    public float moveSpeed; //Defines the speed of the barrels
    public float stoppingDistance = 0.1f; //Defines the radius a barrel can be away from a waypoint until it moves to the next
    public Transform[,] waypoints = new Transform[3,5]; //Array for waypoint positions
    public int currentIndexX = 0; //Shows the index of the waypoint's array x position
    public int currentIndexY = 1; //Shows the index of the waypoint's array y position
    public float distanceP1; //Used to store Path 1's position that was recorded from Ship script
    public float distanceP2; //Used to store Path 1's position that was recorded from Ship script
    public float distanceP3; //Used to store Path 1's position that was recorded from Ship script

    //Barrel Type
    public int barrelType = 0; //Determines the barrel type
    public bool needType = true; //Determines whether or not the barrel needs a type
    public Sprite[] barrel = new Sprite[3]; //Array for loading and changing image of the barrel depending on the type

    #region Start & Update
    void Start()
    {
        LoadArray();
        //waypoints = WaypointParent.GetComponentsInChildren<Transform>();
        //waypoints[waypoints.Length+1] = GameObject.Find("Endpoint").transform;
        CalculateDistance();
        BarrelType();
    }

    void Update()
    {
        Movement();
        Debug.Log(UI.health);
    }
    #endregion

    #region Barrel Type
    public void BarrelType()
    {
        if (needType == true) //Checks if the a type is needed then changes it in accordance to the round
        {
            if (Rounds.roundNum <= 4)
            {
                barrelType = 1;
                needType = false;
            }
            else if (Rounds.roundNum <= 8)
            {
                barrelType = 2;
                needType = false;
            }
            else if (Rounds.roundNum <= 12)
            {
                barrelType = 3;
                needType = false;
            }
        }

        if (barrelType == 1) //Determines the values for each barrel type
        {
            moveSpeed = 2f;
            this.GetComponent<SpriteRenderer>().sprite = barrel[1];
        }
        else if (barrelType == 2)
        {
            moveSpeed = 3f;
            this.GetComponent<SpriteRenderer>().sprite = barrel[2];
        }
        else if (barrelType == 3)
        {
            moveSpeed = 4f;
            this.GetComponent<SpriteRenderer>().sprite = barrel[3];
        }
    }

    #endregion

    #region Movement
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Endpoint") //Checks if the barel has reached the endpoint
        {
            UI.health--;
            Destroy(this.gameObject);
        
        }

    }

    public void CalculateDistance() //Gatheres the calculated distance from Ship then calculates it's targeted path
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

    public void Movement() //Allows the barrels to move along the waypoints
    {
        Transform point = waypoints[currentIndexX,currentIndexY];
        print(currentIndexX + " - " + currentIndexY);

        float distance = Vector2.Distance(transform.position, point.position);
        
        if (distance < stoppingDistance) //Allows the barrels to keep moving if they are close enough to the waypoint
        {
            currentIndexY++;
        }
        //if (currentIndexY == 5)
        //{
        //    currentIndexY = 1;
        //}
        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);
    }
    #endregion

    #region Load
    public void LoadArray() //Loads the objects in the world into an array
    {
        //Path 1's waypoints
        waypoints[0,0] = GameObject.Find("Path_1").transform;
        waypoints[0,1] = GameObject.Find("Waypoint1-1").transform;
        waypoints[0,2] = GameObject.Find("Waypoint1-2").transform;
        waypoints[0,3] = GameObject.Find("Waypoint1-3").transform;
        waypoints[0,4] = GameObject.Find("Endpoint").transform;

        //Path 2's waypoints
        waypoints[1,0] = GameObject.Find("Path_2").transform;
        waypoints[1,1] = GameObject.Find("Waypoint2-1").transform;
        waypoints[1,2] = GameObject.Find("Waypoint2-2").transform;
        waypoints[1,3] = GameObject.Find("Waypoint2-3").transform;
        waypoints[1,4] = GameObject.Find("Endpoint").transform;

        //Path 3's waypoints
        waypoints[2,0] = GameObject.Find("Path_3").transform;
        waypoints[2,1] = GameObject.Find("Waypoint3-1").transform;
        waypoints[2,2] = GameObject.Find("Waypoint3-2").transform;
        waypoints[2,3] = GameObject.Find("Waypoint3-3").transform;
        waypoints[2,4] = GameObject.Find("Endpoint").transform;
    }
    #endregion 
}
