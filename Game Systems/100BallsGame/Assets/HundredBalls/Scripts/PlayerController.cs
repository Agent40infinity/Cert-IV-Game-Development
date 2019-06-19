using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool open = false;
    public Animator anim;

    void Update()
    { 
        if (Input.GetMouseButtonDown(0)) //Checks if the player has pressed left click.
        {
            if (open) //checks if the hing is already open and closes it if it is. Does the opposite if not.
            {
                anim.SetTrigger("Close");
                open = false;
            }
            else
            {
                anim.SetTrigger("Open");
                open = true;
            }
        }
    }
}
