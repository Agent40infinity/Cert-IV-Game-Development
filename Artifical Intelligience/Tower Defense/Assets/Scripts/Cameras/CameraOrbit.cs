using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Camera attachedCamera;
    [Header("Orbit")]
    public float xSpeed = 120f, ySpeed = 210f;
    public float yMinLimit = -20f, yMaxLimit = 80f;
    [Header("Collision")]
    public bool cameraCollision = true; //Is camera collision enabled?
    public bool ignoreTrggers = true; //Will the spherecast ignore triggers
    public float castRadius = .3f; //Radius of sphere to cast
    public float castDistance = 1000f; //Distance the cast travels
    public LayerMask hitLayers; //Layers that casting will hit

    private float originalDistance; //Record starting distance of camera
    private float distance; //Current distance of camera
    private float x, y; //X and Y mouse rotation

	void Start ()
    {
        originalDistance = Vector3.Distance(transform.position, attachedCamera.transform.position); //Set original distanceS
        x = transform.eulerAngles.y; //Set X and Y degress to current camera rotation
        y = transform.eulerAngles.x;

    }
	
	void Update ()
    {
        if (Input.GetMouseButton(1)) //Is right mouse button pressed
        {
            //Disable Cursor:
            Cursor.visible = false; 
            Cursor.lockState = CursorLockMode.Locked;

            //Orbit:
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
            transform.rotation = Quaternion.Euler(y, x, 0); //Rotate the transform using Euler angles
        }
        else
        {
            Cursor.visible = true; //Enable Cursor
            Cursor.lockState = CursorLockMode.None;
        }
	}


    private void FixedUpdate()
    {
        distance = originalDistance; //Set distance to original distance
        if (cameraCollision) //Change distance to what we hit
        {
            Ray camRay = new Ray(transform.position, -transform.forward);
            RaycastHit hit; //Stores the hit inforation after cast
            if (Physics.SphereCast(camRay, castRadius, out hit, castDistance, hitLayers, ignoreTrggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide))
            {
                distance = hit.distance;
            }
        }
        attachedCamera.transform.position = transform.position - transform.forward * distance; //Apply distance to cameras
    }
}
