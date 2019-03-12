using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro PRG/Mouse Look
[AddComponentMenu("IntroPRG/RPG/Player/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    //Before you write this section please scroll to the bottom of the page
    #region Variables
    [Header("Rotational Axis")]
    public RotationalAxis axis = RotationalAxis.MouseX;
    //create a public link to the rotational axis called axis and set a defualt axis

    [Header("Sensitivity")]
    [Range(0,20)]
    public float sensX = 15;
    [Range(0, 20)]
    public float sensY = 15;
    //public floats for our x and y sensitivity

    [Header("Y Rotation Clamp")]
    public float minY = -60;
    public float maxY = 60;
    public float rotationY = 0;
    //max and min Y rotation
    //we will have to invert our mouse position later to calculate our mouse look correctly
    //float for rotation Y

    #endregion
    #region Start
    public void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
    //if our game object has a rigidbody attached to it
    //set the rigidbodys freezRotaion to true


    #endregion
    #region Update
    public void Update()
    {
        #region Mouse X and Y
        //if our axis is set to Mouse X and Y
        if (axis == RotationalAxis.MouseXandY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensX;
            rotationY += Input.GetAxis("Mouse Y") * sensY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            //float rotation x is equal to our y axis plus the mouse input on the Mouse X times our x sensitivity
            //our rotation Y is plus equals  our mouse input for Mouse Y times Y sensitivity
            //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
            //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and x rotation on the y axis
        }


        #endregion
        #region Mouse X   
        //else if we are rotating on the X
        else if (axis == RotationalAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensX, 0);
            //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
            //x                y                          z
        }
        

        #endregion
        #region Mouse Y       
        //else we are only rotation on the Y
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
            //our rotation Y is pulse equals  our mouse input for Mouse Y times Y sensitivity
            //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
            //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and local euler angle Y on the y axis
        }
  

        #endregion
    }
    #endregion
}
public enum RotationalAxis
{
    MouseXandY,
    MouseY,
    MouseX
}
#region RotationalAxis
/*
enums are what we call state value variables 
they are comma separated lists of identifiers
we can use them to create Type or Category variables
meaning each heading of the list is a type or category element that this can be
eg weapons in an inventory are a type of inventory item
if the item is a weapon we can equipt it
if it is a consumable we can drink it
it runs different code depending on what that objects enum is set to
you can also have subtypes within those types
eg weapons are an inventory category or type
we can then have ranged, melee weapons
or daggers, short swords, long swords, mace, axe, great axe, war axe and so on
each Type or Category holds different infomation the game needs like 
what animation plays, where the hands sit on the weapon, how many hands sit on the weapon and so on
*/
//Create a public enum called RotationalAxis

//Creating an enum out side the script and making it public means it can be asessed anywhere in any script with out reference
#endregion











