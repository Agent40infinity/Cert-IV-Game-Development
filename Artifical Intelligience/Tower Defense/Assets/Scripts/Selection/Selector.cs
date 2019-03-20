using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public GameObject[] towers;
    public GameObject[] holograms;

    private int currentTower = 0;

    private Vector3 placeablePoint;

	void OnDrawGizmos ()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawLine(mouseRay.origin, mouseRay.origin + mouseRay.direction * 1000f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(placeablePoint, 0.5f);
	}
	void Update ()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Initualize raycast
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit)) //Perform raycasting
        {
            Placeable p = hit.collider.GetComponent<Placeable>(); //Is placeable
            if (p) //Is it placeable
            {
                placeablePoint = p.transform.position;
            }
        }
	}

    public void SelectTower(int tower)
    {
        if (tower >= 0 && tower < towers.Length) //Checks if the tower is within range of the array
        {
            currentTower = tower; //Set current tower to tower index
        }
    }
}
