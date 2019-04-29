using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//you will need to change Scenes
public class CustomisationGet : MonoBehaviour {

    //[Header("Character")]
    //public variable for the Skinned Mesh Renderer which is our character reference

    #region Start
    //our character reference connected to the Skinned Mesh Renderer via finding the Mesh
    //Run the function LoadTexture	
    #endregion

    #region LoadTexture Function
    //check to see if our save file for this character
    //if it doesnt then load the CustomSet level
    //if it does have a save file then load and SetTexture Skin, Hair, Mouth and Eyes from PlayerPrefs
    //grab the gameObject in scene that is our character and set its Object name to the Characters name
    #endregion
    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing

    //we need variables that exist only within this function
    //these are int material index and Texture2D array of textures
    //inside a switch statement that is swapped by the string name of our material
    //case skin      

    //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
    //material index element number is 1
    //break
    //now repeat for each material 
    //hair is 2
    //mouth is 3
    //eyes are 4

    //Material array is equal to our characters material list
    //our material arrays current material index's main texture is equal to our texture arrays current index
    //our characters materials are equal to the material array
    #endregion
}
