using UnityEngine;
using System.Collections;
[AddComponentMenu("Interact")]
public class Interact : MonoBehaviour 
{
    #region Variables

    [Header("Player and C" +
        "amera connection")]
    public GameObject player;
    #endregion
    #region Start
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //connect our player to the player variable via tag
        //connect our Camera to the mainCam variable via tag
    }
    #endregion
    #region Update
    public void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Ray interact;
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    Debug.Log("Item");
                }
                if (hitInfo.collider.CompareTag("Item"))
                {
                    Debug.Log("NPC");
                }
            }
        }
        //if our interact key is pressed
        //create a ray
        //this ray is shooting out from the main cameras screen point center of screen
        //create hit info
        //if this physics raycast hits something within 10 units
    }
    #endregion
}






