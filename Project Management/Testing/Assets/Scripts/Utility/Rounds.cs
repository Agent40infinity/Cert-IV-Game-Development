using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounds : MonoBehaviour
{
    //Overall:
    public static bool roundStart = false;
    public static bool endRound = false;
    public static bool setup = true;
    public static int suTimer = 0;
    public static int waitTimer = 0;

    //Round:
    public static int maxBarrels = 15;
    public static int currentBarrels = 0;
    public static int spawnRate = 60;
    public static int roundTimer = 0; 
	
	public void Update ()
    {
        if (setup == true)
        {
            suTimer++;
            if (suTimer == 120)
            {
                setup = false;
                roundStart = true;
                suTimer = 0;
            }
        }
        CheckFor();
        Debug.Log("Current Barrels: " + currentBarrels);
    }

    public void CheckFor()
    {
        if (FindObjectOfType<Barrel>() == null && endRound == true)
        {
            Debug.Log("Starting New Round");
            Debug.Log("Wait Timer: " + waitTimer);
            waitTimer++;
            if (waitTimer == 120)
            {
                roundStart = true;
                waitTimer = 0;
                endRound = false;
            }
        }
    }
}
