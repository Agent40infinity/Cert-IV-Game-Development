using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro RPG/Player/Interact
public class PickUp : MonoBehaviour 
{
	#region Variables
	//We are setting up these variable and the tags in update for week 3,4 and 5
	//[Header("Player and Camera connection")]
	//create two gameobject variables one called player and the other mainCam
	#endregion
	#region Start
		//connect our player to the player variable via tag
		//connect our Camera to the mainCam variable via tag
	#endregion
	#region Update
		//if our interact key is pressed
			//create a ray
			//this ray is shooting out from the main cameras screen point center of screen
			//create hit info
			//if this physics raycast hits something within 10 units
				#region NPC tag
				//and that hits info is tagged NPC
					//Debug that we hit a NPC
				#endregion
				#region Item
				//and that hits info is tagged Item
					//Debug that we hit an Item
				#endregion
	#endregion
}






