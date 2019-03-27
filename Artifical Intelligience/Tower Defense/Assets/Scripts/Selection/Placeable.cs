using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    public bool isAvailable = true; // Can a tower be placed here?
    public Transform pivotPoint; // Where to place the tower

    /// <summary>
    /// Returns the point point attached to the tile (if any)
    /// </summary>
    /// <returns>Returns placeable position if no pivot is made</returns>
    public Vector3 GetPivotPoint()
    {
        // If there is no pivot point added to placeable
        if (pivotPoint == null)
        {
            // Return placeable's position
            return transform.position;
        }
        // Return pivot point otherwise
        return pivotPoint.position;
    }
}

