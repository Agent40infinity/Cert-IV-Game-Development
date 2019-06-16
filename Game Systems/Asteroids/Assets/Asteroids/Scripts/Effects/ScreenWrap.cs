using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public float padding = 3f; // Padding around the screen for screen wrapping
    public Color debugColor = Color.blue; //Color of gizmos

    private SpriteRenderer spriteRenderer; //Reference to sprite renderer
	void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //Get reference to sprite renderer
	}
    private void OnDrawGizmos()
    {
        Bounds camBounds = Camera.main.GetBounds(padding); // Get the bounds around the cameras with given padding
        Gizmos.color = debugColor; // Draw the camera bounds
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }
    void UpdatePosition()
    {
        Bounds camBounds = Camera.main.GetBounds(padding); // Get the camera dimensions using padding
        Vector3 pos = transform.position; // Store position and size in a shorter variable name
        Vector3 min = camBounds.min;
        Vector3 max = camBounds.max; // Store min and max vectors
        if (pos.x < min.x) // Check left
        {
            pos.x = max.x;
        }
        if (pos.x > max.x) // Check right
        {
            pos.x = min.x;
        }
        if (pos.y < min.y) // Check up
        {
            pos.y = max.y;
        }
        if (pos.y > max.y) // Check down
        {
            pos.y = min.y;
        }
        transform.position = pos; // Apply position
    }
    void LateUpdate()
    {
        UpdatePosition();
    }
}
