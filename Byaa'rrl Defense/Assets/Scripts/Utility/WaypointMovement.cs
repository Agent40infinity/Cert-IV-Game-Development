using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    public float speed;
    public int change;
    public int cTimer;
    public bool facing = true; //True = Right, False = Left
    //public Vector2 movementX;
    Vector2 movementX; 

    void Start ()
    {
        speed = Random.Range(0f, 0.035f);
        change = Random.Range(20, 120);
        movementX = new Vector2(speed, 0);
        //this.transform.localPosition(0,0,0);
    }
	
	void Update ()
    {
        if (cTimer <= change)
        {
            cTimer++;
            if (facing == true)
            {
                this.transform.Translate(movementX);
            }
            else
            {
                this.transform.Translate(-movementX);
            }
        }
        else
        {
            if (facing == true)
            {
                facing = false;
            }
            else
            {
                facing = true;
            }
            cTimer = 0;
        }
	}
}
