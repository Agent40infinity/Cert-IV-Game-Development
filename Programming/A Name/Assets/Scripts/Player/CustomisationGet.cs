using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//you will need to change Scenes
public class CustomisationGet : MonoBehaviour {

    [Header("Character")]
    public Renderer character;
    public bool setNeeded = true;

    #region Start
    public void Start()
    {
        character = GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<SkinnedMeshRenderer>();
        LoadTexture();
    }
    #endregion

    #region LoadTexture Function
    void LoadTexture()
    {
        if (setNeeded == true)
        {
            //SetTexture();
        }
    }
    //check to see if our save file for this character
    //if it doesnt then load the CustomSet level
    //if it does have a save file then load and SetTexture Skin, Hair, Mouth and Eyes from PlayerPrefs
    //grab the gameObject in scene that is our character and set its Object name to the Characters name
    #endregion
    #region SetTexture
    void SetTexture(string type, int index)
    {
        Texture2D tex = null;
        int matIndex = 0;
        switch(type)
        {
            case "Skin":
                tex = Resources.Load("Character/Skin_" + index) as Texture2D;
                matIndex = 1;
                break;
            case "Hair":
                tex = Resources.Load("Character/Hair_" + index) as Texture2D;
                matIndex = 2;
                break;
            case "Mouth":
                tex = Resources.Load("Character/Mouth_" + index) as Texture2D;
                matIndex = 3;
                break;
            case "Eyes":
                tex = Resources.Load("Character/Eyes_" + index) as Texture2D;
                matIndex = 4;
                break;
            case "Clothes":
                tex = Resources.Load("Character/Clothes_" + index) as Texture2D;
                matIndex = 5;
                break;
            case "Armour":
                tex = Resources.Load("Character/Armour_" + index) as Texture2D;
                matIndex = 6;
                break;

        }

        Material[] mats = character.materials;
        mats[matIndex].mainTexture = tex;
        character.materials = mats;
    }
    #endregion
}
