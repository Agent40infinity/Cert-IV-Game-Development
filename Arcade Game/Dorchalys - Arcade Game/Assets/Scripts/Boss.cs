using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    //Integers:
    private int aTimer = 0;
    private int jTimer = 0;
    private int sTimer = 0;

    //Booleans:
    private bool startPeriod = true;
    private bool canAttack = false;
    private bool jumpAttack = false;
    private bool chargeAttack = false;
    private bool burstAttack = false;

    //Array:
    int[][] Setup;

    void Start ()
    {
		
	}

    void FixedUpdate()
    {

    }

    public void CalcAttack()
    { }

    public void Charge()
    { }

    public void Jump()
    { }

    public void Burst()
    { }
}
