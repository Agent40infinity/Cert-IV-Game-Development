//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Temp : MonoBehaviour
//{
//    #region Textures
//    #region Set
//    #region Skin
//    public void IncreaseSkin()
//    {
//        SetTexture("Skin", 1);
//    }

//    public void DecreaseSkin()
//    {
//        SetTexture("Skin", -1);
//    }
//    #endregion

//    #region Hair
//    public void IncreaseHair()
//    {
//        SetTexture("Hair", 1);
//    }

//    public void DecreaseHair()
//    {
//        SetTexture("Hair", -1);
//    }
//    #endregion

//    #region Eyes
//    public void IncreaseEyes()
//    {
//        SetTexture("Eyes", 1);
//    }

//    public void DecreaseEyes()
//    {
//        SetTexture("Eyes", -1);
//    }
//    #endregion

//    #region Mouth
//    public void IncreaseMouth()
//    {
//        SetTexture("Mouth", 1);
//    }

//    public void DecreaseMouth()
//    {
//        SetTexture("Mouth", -1);
//    }
//    #endregion

//    #region Clothes
//    public void IncreaseClothes()
//    {
//        SetTexture("Clothes", 1);
//    }

//    public void DecreaseClothes()
//    {
//        SetTexture("Clothes", -1);
//    }
//    #endregion

//    #region Armour
//    public void IncreaseArmour()
//    {
//        SetTexture("Armour", 1);
//    }

//    public void DecreaseArmour()
//    {
//        SetTexture("Armour", -1);
//    }
//    #endregion
//    #endregion

//    #region Random | Reset
//    public void SetRandom()
//    {
//        SetTexture("Skin", Random.Range(0, skinMax - 1));
//        SetTexture("Hair", Random.Range(0, hairMax - 1));
//        SetTexture("Mouth", Random.Range(0, mouthMax - 1));
//        SetTexture("Eyes", Random.Range(0, eyesMax - 1));
//        SetTexture("Clothes", Random.Range(0, clothesMax - 1));
//        SetTexture("Armour", Random.Range(0, armourMax - 1));
//    }

//    public void Reset()
//    {
//        SetTexture("Skin", skinIndex = 0);
//        SetTexture("Hair", hairIndex = 0);
//        SetTexture("Mouth", mouthIndex = 0);
//        SetTexture("Eyes", eyesIndex = 0);
//        SetTexture("Clothes", clothesIndex = 0);
//        SetTexture("Armour", armourIndex = 0);
//    }
//    #endregion

//    #region Save
//    public void SaveSettings()
//    {
//        Save();
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
//        customizer.SetActive(false);
//    }
//    #endregion
//    #endregion

//    #region Stats
//    #region Class
//    public void UpClass()
//    {
//        selectedIndex++;
//        if (selectedIndex > selectedClass.Length - 1)
//        {
//            selectedIndex = 0;
//        }
//        ChooseClass(selectedIndex);
//    }

//    public void DownClass()
//    {
//        selectedIndex--;
//        if (selectedIndex < 0)
//        {
//            selectedIndex = selectedClass.Length - 1;
//        }
//        ChooseClass(selectedIndex);
//    }
//    #endregion

//    #region Points
//    public void Points(bool decrease, bool increase)
//    {
//        for (int x = 0; x < 6; x++)
//        {
//            if (points > 0)
//            {
//                if (increase == true)
//                { 
//                    points--;
//                    tempStats[x]++;
//                    increase = false;
//                }
//            }
//            GUI.Box(new Rect(3.75f * scrtW, 2.5f * scrtH + x * (0.5f * scrtH), 2f * scrtW, 0.5f * scrtH), statArray[x] + ": " + (tempStats[x] + stats[x]));
//            if (points < 10 && tempStats[x] > 0)
//            {
//                if (decrease == true)
//                {
//                    points++;
//                    tempStats[x]--;
//                    decrease = false;
//                }
//            }
//        }
//    }
//    #endregion
//    #endregion
//}
