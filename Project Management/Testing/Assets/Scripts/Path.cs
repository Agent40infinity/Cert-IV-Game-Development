using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform[] waypoints;

    public void Reset()
    {
        waypoints = GetComponentsInChildren<Transform>();
    }

    public Transform GetWaypoint(int index)
    {
        return waypoints[index];
    }
}
