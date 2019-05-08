using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator movement;
    public Transform transform;
    public float horizontal;
    public float vertical;
    void Start()
    {
        movement = GetComponent<Animator>();
        transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        vertical = Input.GetAxisRaw("Horizontal");
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    public void Movement() 
    {
        #region Vertical and Horizontal
        if (Input.GetAxisRaw("Vertical") > 0.1)
        {
            movement.SetBool("Walk", true);
            if (Input.GetButton("Sprint"))
            {
                movement.SetBool("Walk", false);
                movement.SetBool("Sprint", true);
            }
            else
            {
                movement.SetBool("Sprint", false);
            }
        }
        else
        {
            movement.SetBool("Walk", false);
        }

        if (horizontal >= 0.1 && horizontal <= 1)
        {
            transform.Rotate(0, 1, 0);
        }
        else if (horizontal <= -0.1 && horizontal >= -1)
        {
            transform.Rotate(0, -1, 0);
        }
        #endregion

        #region Jump
        if (Input.GetButtonDown("Jump"))
        {
            movement.SetBool("Jump", true);
        }
        else
        {
            movement.SetBool("Jump", false);
        }
        #endregion
    }
}
