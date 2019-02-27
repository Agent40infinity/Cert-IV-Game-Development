using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Allow us to interact with UI elements

//this script can be found in the Component section under the option Intro PRG/Player/Health

public class Health : MonoBehaviour
{
    //[Header("Player Stats")]
    //public maxHealth
    //public curHealth
    //[Header("Heart Slots")]
    //Canvas Image heartSlots array
    //Sprite hearts array
    //private percent healthPerSection
    #region Start
           // Run UpdateHearts
    #endregion
	#region Update 
        //index variable starting at 0 for slot checks
        //foreach Image slot in heartSlots
            //if curHealth is greater or equal to full for this slot amount
                //Set heart to 4/4
            //else if curHealth is greater or equal to 3/4 for this slot amount
                //Set Heart to 3/4
            //else if curHealth is greater or equal to 2/4 for this slot amount
                //Set Heart to 2/4
            //else if curHealth is greater or equal to 1/4 for this slot amount
                //Set Heart to 1/4
            //else
                //we are empty
            //after checking this slot increase slot index
      
	#endregion
    #region UpdateHearts
        //calculate the health points per heart section
    #endregion
}
