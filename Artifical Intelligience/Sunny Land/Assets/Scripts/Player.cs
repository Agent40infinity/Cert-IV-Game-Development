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
    public CharacterController2D controller;
    public float gravity = -10f;
    private Vector3 motion;
    public float jumpHeight = 5f;
    public Animator anim;
    public SpriteRenderer rend;

    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        motion.y *= gravity * Time.deltaTime;
        if (controller.isGrounded)
        {
            motion.y = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        Climb(inputV);
        Move(inputH);
        controller.move(motion * Time.deltaTime);
    }

    void Move(float inputH)
    {
        motion.x = inputH * movementSpeed;
        anim.SetBool("isRunning", inputH != 0);
        rend.flipx = inputH < 0;
    }

    void Climb(float inputV)
    {

    }

    void Hurt()
    {

    }

    void Jump()
    {
        motion.y = jumpHeight;
    }
}
