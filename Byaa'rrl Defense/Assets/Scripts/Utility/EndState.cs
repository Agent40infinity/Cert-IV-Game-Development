using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : MonoBehaviour
{
    public GameObject overlay, end;
    public GameObject win, lose;
    public bool endState = false;
    public bool won = false;
    public bool loss = false;

    void Update()
    {
        if (UI.health <= 0)
        {
            endState = true;
            loss = true;
        }
        else if (Rounds.roundNum == 21)
        {
            endState = true;
            won = true;
        }
        ToggleEndState();
    }

    public void ToggleEndState()
    {
        if (endState == true)
        {
            overlay.SetActive(false);
            end.SetActive(true);
            if (won == true)
            {
                win.SetActive(true);
                lose.SetActive(false);
            }
            else if (loss == true)
            {
                lose.SetActive(true);
                win.SetActive(false);
            }
        }
        else if (endState == false)
        {
             overlay.SetActive(true);
             end.SetActive(false);
        }
    }
}
