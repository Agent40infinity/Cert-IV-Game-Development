using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public Camera attachedCamera;
    public float movementThreshold = .25f;
    public float movementSpeed = 20f;
    public float zoomSensitivity = 10;
    public Vector3 size = new Vector3(20f, 1f, 20f);

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

    Vector3 GetAdjustedPos(Vector3 incomingPos)
    {
        Vector3 pos = transform.position;
        Vector3 halfSize = size * .5f;

        //X
        if (incomingPos.x > pos.x + halfSize.x) incomingPos.x = pos.x + halfSize.x;
        if (incomingPos.x < pos.x - halfSize.x) incomingPos.x = pos.x - halfSize.x;

        //Y
        if (incomingPos.y > pos.y + halfSize.y) incomingPos.y = pos.y + halfSize.y;
        if (incomingPos.y < pos.y - halfSize.y) incomingPos.y = pos.y - halfSize.y;

        //Z
        if (incomingPos.z > pos.z + halfSize.z) incomingPos.z = pos.z + halfSize.z;
        if (incomingPos.z < pos.z - halfSize.z) incomingPos.z = pos.z - halfSize.z;

        return incomingPos;
    }
	void Update ()
    {
        Movement();
	}
    void Movement()
    {
        Transform camTransform = attachedCamera.transform; //Create a transform with a smaller name

        Vector2 mousePoint = attachedCamera.ScreenToViewportPoint(Input.mousePosition); //Get mouse to viewport coordinates
        Vector2 offset = mousePoint - new Vector2(.5f, .5f);

        Vector3 input = Vector3.zero;
        if (offset.magnitude > movementThreshold)
            input = new Vector3(offset.x, 0, offset.y) * movementSpeed;

        float inputScroll = Input.GetAxis("Mouse ScrollWheel"); //Get scroll from axis and multiply by zoomSensitivity
        Vector3 scroll = camTransform.forward * inputScroll * zoomSensitivity;

        Vector3 movement = input + scroll; //Apply movement
        camTransform.position += movement * Time.deltaTime;

        camTransform.position = GetAdjustedPos(camTransform.position);
    }
}
