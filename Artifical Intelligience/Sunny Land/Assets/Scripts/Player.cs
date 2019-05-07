﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;

[RequireComponent(typeof(CharacterController2D))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
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
        motion.x = InputH * movementSpeed;
        if (controller.isGrounded)
        {
            motion.y = 0;
        } 
        motion.y += gravity * Time.deltaTime;
        controller.move(motion * Time.deltaTime);
    }
}