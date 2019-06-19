using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;

[RequireComponent(typeof(CharacterController2D))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpSpeed = 5f;
    public bool isGrounded = false;
    public bool isClimbing = false;
    public CharacterController2D controller;
    public float gravity = -10f;
    private Vector3 motion;
    public float jumpHeight = 8f;
    public float centreRadius = 0.5f;
    public Animator anim;
    public SpriteRenderer rend;

    void Start() //Gets the required components
    {
        controller = GetComponent<CharacterController2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update() //Get Input | Call upon functions
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        if (!controller.isGrounded && !isClimbing) //Apply gravity
        {
            motion.y += gravity * 2 * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump")) //used to Jump
        {
            Jump();
        }

        if (!isClimbing) //Animation controller for jumping
        {
            anim.SetBool("isGrounded", controller.isGrounded);
            anim.SetFloat("JumpY", motion.y);
        }

        Climb(inputV, inputH);
        Move(inputH);
        controller.move(motion * Time.deltaTime);
    }

    private void OnDrawGizmos() //Gives reference within the scene 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, centreRadius);
    }

    void Move(float inputH) //Allows the player to move
    {
        motion.x = inputH * movementSpeed;
        anim.SetBool("isRunning", inputH != 0);
        if (inputH != 0) //Flips the sprites in the sprite renderer when facing left and vice versa
        {
            rend.flipX = inputH < 0; 
        }
    }

    void Climb(float inputV, float inputH) //Used to climb the ladder
    {
        bool isOverLadder = false;
        Vector3 inputDir = new Vector3(inputH, inputV, 0);

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, centreRadius);
        foreach (var hit in hits) //Used to gather information from "Ladder" and "Ground" for the animator
        {
            if (hit.tag == "Ladder")
            {
                isOverLadder = true;
                break;
            }

            if (hit.tag == "Ground")
            {
                isClimbing = false;
                isOverLadder = false;
                break;
            }
        }

        if (isOverLadder && inputV != 0) //Checks if the player is able to climb the ladder
        {
            anim.SetBool("isClimbing", true);
            isClimbing = true;
        }

        if (isClimbing) //Allows the player to freely move on the ladder and remove gravity
        {
            motion.y = 0;
            transform.Translate(inputDir * movementSpeed * Time.deltaTime);
        }

        if (!isOverLadder) //Disables climbing animation 
        {
            anim.SetBool("isClimbing", false);
            isClimbing = false;
        }

        anim.SetFloat("climbSpeed", inputDir.magnitude * movementSpeed); 
    }

    void Hurt()
    {

    }

    void Jump() //Used to jump
    {
        motion.y = jumpHeight*1.5f;
    }
}
