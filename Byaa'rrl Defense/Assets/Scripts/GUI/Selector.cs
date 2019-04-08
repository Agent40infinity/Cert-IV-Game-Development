using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public Transform Towers;
    public int currentTower = 0;
    public GameObject[] towers;
    public GameObject[] holograms;



    private Vector2 placeablePoint;

    private void OnDrawGizmos()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(mouseRay.origin, mouseRay.origin + mouseRay.direction * 1000f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(placeablePoint, .5f);
    }

    /// <summary>
    /// disables the gameobjects of all referenced holgrams
    /// </summary>

    void DisableAllHolograms()
    {
        foreach (var holo in holograms)
        {
            holo.SetActive(false);
        }
    }




    void Update()
    {
        //disable all holograms at the start of each frame
        DisableAllHolograms();
        // Creates a ray
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction, 1000f);
        // If it hits something...
        if (hit.collider != null)
        {
            //try to get placeable from thing we hit
            Placeable p = hit.collider.GetComponent<Placeable>();
            //Is it placeable? ... AND placeable is Available
            if (p && p.isAvailable)
            {
                //>>>Hover Mechanic<<<
                // placeablePoint = p.transform.position;
                GameObject hologram = holograms[currentTower];
                //get hologram of current tower
                //active hologram
                hologram.SetActive(true);
                //position hologram to tile
                hologram.transform.position = p.GetPlaceHere();

                //>>>Placement Mechanic<<<
                //if left mouse is down
                if (Input.GetMouseButtonDown(0))
                {
                    // get the current tower prefab
                    GameObject towerPrefab = towers[currentTower];
                    //spawn a new tower
                    GameObject tower = Instantiate(towerPrefab, Towers);

                    print(hit.transform.name);
                    tower.GetComponent<Towers>().waypoints = hit.transform.GetComponent<Placeable>().spawnPoints;
                    //position new tower to tile
                    tower.transform.position = p.GetPlaceHere();
                    //tile is no longer placeable
                   // p.isAvailable = false;
                }

            }
        }
    }

    public void SelectTower(int tower)
    {
        // Is tower in range of array (tower)
        if (tower >= 0 && tower < towers.Length)
        {
            //If yes - Set currentTower to tower
            currentTower = tower;
        }

    }
}

