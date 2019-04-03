using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounds : MonoBehaviour
{
    //Overall:
    public static bool roundStart = false; //Checks whether or not a round has started
    public static bool endRound = false; //Checks whether or not a round has ended
    public static bool setup = true; //Checks whether or not round setup is required
    public static int suTimer = 0; //Timer for setup
    public static int waitTimer = 0; //Timer for wait period

    //Round:
    public static int maxBarrels = 15; //Determines the max amount of barrels that can spawn on any given turn
    public static int currentBarrels = 0; //Determines the current amount of barrels in the instance
    public static int spawnRate = 60; //Determines the spawn rate of the barerls (60 ticks in a second)
    public static int roundTimer = 0; //Timer that counts towards the max value of spawnRate
    public static int roundNum = 0; //Counts what round it is (begins at round 1)
	
	public void Update ()
    {
        CheckFor();
        RoundModeration();

        if (setup == true) //Determines whether or not a setup is required (used to give the player time to breath at the start of the game)
        {
            suTimer++;
            if (suTimer == 120) //Ends the setup period
            {
                setup = false;
                roundStart = true;
                suTimer = 0;
            }
        }

        Debug.Log("Current Barrels: " + currentBarrels);
        Debug.Log("Round Number " + roundNum);
    }

    public void RoundModeration() //Checks whether or not a new round is needed
    {
        if (roundStart == true)
        {
            roundNum++;
            Ship.roundStart = true;
            roundStart = false;
        }
    }

    public void CheckFor()
    {
        if (FindObjectOfType<Barrel>() == null && endRound == true) //Checks whether or not there are no barrels remaining in the intance and makes sure that all barrels needed during that round have be sent out
        {
            Debug.Log("Starting New Round");
            Debug.Log("Wait Timer: " + waitTimer);
            waitTimer++;
            if (waitTimer == 120) //Period of time given to the player in between rounds
            {
                roundStart = true;
                waitTimer = 0;
                endRound = false;
            }
        }
    }
}
