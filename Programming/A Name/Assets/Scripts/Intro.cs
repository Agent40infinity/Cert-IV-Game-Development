using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    void Awake() // Idk
    {
        Debug.Log("Awake");
    }
    void Start() // Use this for initialization
    {
        Debug.Log("Start");
    }
    void Update() // Update is called once per frame
    {
        Debug.Log("Update");
        Debug.Log(Time.deltaTime);
    }
    void LateUpdate() // LateUpdate is called at another time 
    {
        Debug.Log("LateUpdate");
    }
    void FixedUpdate() // FixedUpdate is called once every selected frame | 0.02
    {
        Debug.Log("FixedUpate");
    }
}
