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

    void Reset()
    {
        controller = GetComponent<CharacterController2D>();
    }

    void Update()
    {
        float InputH = Input.GetAxis("Horizontal");
        float InputV = Input.GetAxis("Vertical");
        motion.x = InputV * jumpSpeed;
        motion.x = InputH * movementSpeed;
        if (controller.isGrounded)
        {
            motion.y = 0;
        } 
        motion.y += gravity * Time.deltaTime;
        controller.move(motion * Time.deltaTime);
    }
}
