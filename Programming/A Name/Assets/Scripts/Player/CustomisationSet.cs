using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//you will need to change Scenes
public class CustomisationSet : MonoBehaviour 
{
    #region Variables
    [Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes
	public List<Texture2D>() skin = new List<Texture2D>();
	public List<Texture2D>() eyes = new List<Texture2D>();
	public List<Texture2D>() mouth = new List<Texture2D>();
	public List<Texture2D>() hair = new List<Texture2D>();
	public List<Texture2D>() cloths = new List<Texture2D>();
	public List<Texture2D>() armour = new List<Texture2D>();
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
	public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothsIndex, armourIndex;
    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
	public renderer character;
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
	public int skinMax, eyesMax, mouthMax, hairMax, clothsMax, armourMax;
    [Header("Character Name")]
    //name of our character that the user is making
	public string characterName = "Adventure";
	[Header("Stats")]
	public CharacterClass charClass;
	public CharacterRace charRace;
	public int[] tempStats;
	public int stats;
	public string[] statName;
	public int points;
    #endregion

    #region Start
    public void Start
	{
        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
		for (int i = 0; i > skinMax; i++)
		{
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            //add our temp texture that we just found to the skin List
		}
        //for loop looping from 0 to less than the max amount of hair textures we need
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
            //add our temp texture that we just found to the hair List
        //for loop looping from 0 to less than the max amount of mouth textures we need    
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#
            //add our temp texture that we just found to the mouth List
     
        //for loop looping from 0 to less than the max amount of eyes textures we need
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
            //add our temp texture that we just found to the eyes List            
        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        #endregion
	}
	#endregion

    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing
        //we need variables that exist only within this function
        //these are ints index numbers, max numbers, material index and Texture2D array of textures
        //inside a switch statement that is swapped by the string name of our material
        #region Switch Material
            //case skin
                //index is the same as our skin index
                //max is the same as our skin max
                //textures is our skin list .ToArray()
                //material index element number is 1
                //break
            //now repeat for each material 
            //hair is 2
                //index is the same as our index
                //max is the same as our max
                //textures is our list .ToArray()
                //material index element number is 2
                //break
            //mouth is 3
                //index is the same as our index
                //max is the same as our max
                //textures is our list .ToArray()
                //material index element number is 3
                //break
            //eyes are 4
                //index is the same as our index
                //max is the same as our max
                //textures is our list .ToArray()
                //material index element number is 4
                //break
        #endregion
        #region OutSide Switch
        //outside our switch statement
        //index plus equals our direction
        //cap our index to loop back around if is is below 0 or above max take one
        //Material array is equal to our characters material list
        //our material arrays current material index's main texture is equal to our texture arrays current index
        //our characters materials are equal to the material array
        //create another switch that is goverened by the same string name of our material
        #endregion
        #region Set Material Switch
            //case skin
                //skin index equals our index
                //break
            //case hair
                //index equals our index
                //break
            //case mouth
                //index equals our index
                //break
            //case eyes
                //index equals our index
                //break
        #endregion
    #endregion

    #region Save
    //Function called Save this will allow us to save our indexes 
        //SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex
        //SetString CharacterName
    #endregion

    #region OnGUI
    //Function for our GUI elements
        //create the floats scrW and scrH that govern our 16:9 ratio
        //create an int that will help with shuffling your GUI elements under eachother
        #region Skin
        //GUI button on the left of the screen with the contence <
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
        //GUI Box or Lable on the left of the screen with the contence Skin
        //GUI button on the left of the screen with the contence >
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        #endregion
        //set up same things for Hair, Mouth and Eyes
        #region Hair
        //GUI button on the left of the screen with the contence <
            //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
        //GUI Box or Lable on the left of the screen with the contence material Name
        //GUI button on the left of the screen with the contence >
        //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        #endregion
        #region Mouth
        //GUI button on the left of the screen with the contence <
            //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
        //GUI Box or Lable on the left of the screen with the contence material Name
        //GUI button on the left of the screen with the contence >
        //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        #endregion
        #region Eyes
        //GUI button on the left of the screen with the contence <
            //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
        //GUI Box or Lable on the left of the screen with the contence material Name
        //GUI button on the left of the screen with the contence >
        //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        #endregion
        #region Random Reset
        //create 2 buttons one Random and one Reset
        //Random will feed a random amount to the direction 
        //reset will set all to 0 both use SetTexture
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        #endregion
        #region Character Name and Save & Play
        //name of our character equals a GUI TextField that holds our character name and limit of characters
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this

        //GUI Button called Save and Play
            //this button will run the save function and also load into the game level
    #endregion
    #endregion
}

public enum CharacterRace
{
	Dragonborn,
	Dwarf,
	Elf,
	Gnome,
	Half_Elf,
	Half_Orc,
	Halfling,
	Human,
	Tiefling	
}

public enum CharacterClass
{
	
}
