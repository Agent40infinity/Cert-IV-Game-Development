using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Intro PRG/RPG/Player/Movement")]
public class Movement : MonoBehaviour
{
    #region Variables
    [Header("PLAYER MOVEMENT")]
    [Space(10)]
    [Header("Characters Move Direction")]
    public Vector3 moveDirection;
    private CharacterController _charC;
    [Header("Character Variables")]
    public float jumpSpeed = 8f;
    public float speed = 5f;
    public float gravity = 20f;
    #endregion
    #region Start
    private void Start()
    {
        _charC = GetComponent<CharacterController>();
    }
    #endregion
    #region Update
    private void Update()
    {
        if(_charC.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        _charC.Move(moveDirection * Time.deltaTime);
    }
    #endregion

}
//16 errors