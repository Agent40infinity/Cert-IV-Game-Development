using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Character Set Up 
//Character Movement
//This script requires the component Character controller
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("IntroPRG/RPG/Player Movement")]
public class Movement : MonoBehaviour
{
    #region Variables
    [Header("Player Movement")]
    [Space(10)]
    [Header("Characters MoveDirection")]
    public Vector3 moveDirection; //vector3 called moveDirection
    //we will use this to apply movement in worldspace
    private CharacterController _charC; //(https://docs.unity3d.com/ScriptReference/CharacterController.html)
    [Header("Character Variables")]
    public float jumpSpeed = 8;
    public float speed = 5;
    public float sprintSpeed = 10;
    public float gravity = 20;
    #endregion
    #region Start
    private void Start()
    {
        _charC = this.GetComponent<CharacterController>();
    }
    //charc is on this game object we need to get the character controller that is attached to it
    #endregion
    #region Update
    private void Update()
    {
        //if our character is grounded
        if (_charC.isGrounded) //we are able to move in game scene meaning
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //moveDir is equal to a new vector3 that is affected by Input.Get Axis.. Horizontal, 0, Vertical
            moveDirection = transform.TransformDirection(moveDirection);
            //moveDir is transformed in the direction of our moveDir
            if (Input.GetButton("Shift"))
            {
                moveDirection *= sprintSpeed;
            }
            else
            {
                moveDirection *= speed;
            }
            //our moveDir is then multiplied by our speed
            //Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
            //Input(https://docs.unity3d.com/ScriptReference/Input.html)
            //we can also jump if we are grounded so
            //in the input button for jump is pressed then
            //our moveDir.y is equal to our jump speed
            //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
            //we then tell the character Controller that it is moving in a direction timesed Time.deltaTime}
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        _charC.Move(moveDirection * Time.deltaTime);
        #endregion
    }
}










