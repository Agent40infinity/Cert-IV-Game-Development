using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public Transform towerParent;
    public GameObject[] towers;
    public GameObject[] holograms;

    private int currentTower = 0;

    private Vector3 placeablePoint;

	void OnDrawGizmos () //Debug for the scene to show us raycasts and other oebjects
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawLine(mouseRay.origin, mouseRay.origin + mouseRay.direction * 1000f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(placeablePoint, 0.5f);
	}
	void Update ()
    {
        DisableAllHolograms();
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Initualize raycast
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit)) //Perform raycasting
        {
            Placeable p = hit.collider.GetComponent<Placeable>(); //Is placeable
            if (p && p.isAvailable) //Is it placeable
            {
                //>>Hover Mechani
                GameObject hologram = holograms[currentTower]; // Get hologram of current tower
                hologram.SetActive(true); // Activate hologram
                hologram.transform.position = p.GetPivotPoint();// Position hologram to tile

                if (Input.GetMouseButtonDown(0)) // If left mouse is down
                {
                    GameObject towerPrefab = towers[currentTower]; //Get the current tower prefab
                    GameObject tower = Instantiate(towerPrefab, towerParent); //Spawn a new tower
                    tower.transform.position = p.GetPivotPoint(); //Position new tower to tile
                    p.isAvailable = false; //Tile is no longer placeable
                }
            }
        }
	}

    public void DisableAllHolograms() //Disable hologram after tower is placed
    {
        foreach (var holo in holograms)
        {
            holo.SetActive(false);
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
