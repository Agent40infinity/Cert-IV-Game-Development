using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : MonoBehaviour
{
    public bool won = false;
    public bool loss = false;
	
	void Update ()
    {
        if (UI.health == 0)
        {
            loss = true;
        }
        else if (Rounds.roundNum == 21)
        {
            won = true;
        }
	}
}
