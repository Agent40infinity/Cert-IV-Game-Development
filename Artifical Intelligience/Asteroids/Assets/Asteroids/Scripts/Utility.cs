using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Bounds GetBounds(this Camera cam, float padding = 1f)
    {
        float camHeight, camWidth; //Define camera dimensions as a float
        Vector3 camPos = cam.transform.position; // Get the position of the camera
        camHeight = 2f * cam.orthographicSize; 
        camWidth = camHeight * cam.aspect; // Calculate height and Width of the camera
        camHeight += padding;
        camWidth += padding; //Applies padding
        return new Bounds(camPos, new Vector3(camWidth, camHeight, 100)); // Create a camera bounds from above information
    }
    public static Vector3 GetRandomPosOnBounds
}
