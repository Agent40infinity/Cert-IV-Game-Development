using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 20f;
    public Rigidbody rigid;
	void Start () //Used to get the components required 
    {
        rigid = GetComponent<Rigidbody>();
	}
	void Update () //Used to record Input and then translate that into movement using the rigidbody
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(inputX, 0, inputZ);
        rigid.velocity = input * -movementSpeed;
	}
}
