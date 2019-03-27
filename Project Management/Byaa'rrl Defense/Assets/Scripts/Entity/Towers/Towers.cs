using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    //Integers:
    public int damage;
    public int towerSelection;
    public int[,] towerSprites = new int[4, 3];

    //Float:
    public float movement;
    public float firerate;
    public float range;

    //Booleans:
    public bool towerCannon = false;
    public bool towerGunship = false;
    public bool towerSupport = false;
    public bool towerAOE = false;


	void Start ()
    {
        switch (towerSelection)
        {
            case 1:
                towerCannon = true;
                break;
            case 2:
                towerGunship = true;
                break;
            case 3:
                towerSupport = true;
                break;
            case 4:
                towerAOE = true;
                break;

        }
	}

    private void Load()
    {
        if (towerCannon == true)
        {
            damage = 10;
            range = 5f;
            firerate = 8f;
            movement = 2f;
            //towerSprites[1, 0];
        }
        if (towerGunship == true)
        {
            damage = 1;
            range = 10f;
            firerate = 0.2f;
            movement = 3f;
            //towerSprites[2, 0];
        }
        if (towerSupport == true)
        {
            damage = 0;
            range = 3f;
            firerate = 2f;
            movement = 1f;
            //towerSprites[3, 0];
        }
        if (towerAOE == true)
        {
            damage = 3;
            range = 20f;
            firerate = 1.2f;
            movement = 1f;
            //towerSprites[4, 0];
        }
    }
}
