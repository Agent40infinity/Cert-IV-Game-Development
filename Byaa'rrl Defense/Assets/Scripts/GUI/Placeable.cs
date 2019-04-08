using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    public bool isAvailable = true; //Tower can be placed
    public Transform[] spawnPoints;
    
    public Vector2 GetPlaceHere()
    {
        return transform.position;
    }
}
