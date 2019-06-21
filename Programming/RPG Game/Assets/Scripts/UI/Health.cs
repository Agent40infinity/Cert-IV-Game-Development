using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Allow us to interact with UI elements

//this script can be found in the Component section under the option Intro PRG/Player/Health
namespace Health
{
    [AddComponentMenu("Health")]
    public class Health : MonoBehaviour
    {
        [Header("Player Stats")]
        public int maxHealth = 6;
        public int curHealth;
        [Header("Heart Slots")]
        public Image[] healthSlots = new Image[3];
        //Canvas Image heartSlots array
        public Sprite[] hearts = new Sprite[3];
        //Sprite hearts array
        private float healthPerSection;
        //private percent healthPerSection
        #region Start
        public void Start()
        {
            curHealth = maxHealth;
            UpdateHearts();
        }
        #endregion
	    #region Update 
        public void Update()
        {
            int i = 0;
            foreach(Image slot in healthSlots)
            {
                if (curHealth >= (healthPerSection * 2) + (healthPerSection * 2) * i)
                {
                    healthSlots[i].sprite = hearts[0];
                }
                else if (curHealth >= (healthPerSection * 1) + (healthPerSection * 2) * i)
                {
                    healthSlots[i].sprite = hearts[1];
                }
                else 
                {
                    healthSlots[i].sprite = hearts[2];
                }
                i++;
            }


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
        }
	    #endregion
        #region UpdateHearts
        public void UpdateHearts()
        {
            healthPerSection = maxHealth / (healthSlots.Length * 2);
           //calculate the health points per heart section
        }
        #endregion
    }
}
