﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
	public class Boss : MonoBehaviour 
	{
		//Integers:
		private int tTimer = 0; //Tick rate timer
		public int sTimer = 0; //Start timer
		public int aTimer = 100; //Attack timer
		private int baTimer = 0; //Basic Attack timer
		private int jTimer = 0; //Jump timer
		private int cTimer = 0; //Charge timer
		private int bTimer = 0; //Burst timer
        private int rTimer = 60; //Rest timer
		private int basicV = 0; //Basic Attack's value
		private int jumpV = 0; //Jump Attack's value
		private int chargeV = 0; //Charge Attack's value
		private int burstV = 0; //Burst Attack's value
		private int phase = 0; //Determines the difficulty of the boss
        private int move = 0; //Counts up everytime an ability is used

        //Floats:
        public float distanceFP = 0f; //Tracks how far away the Player is from the boss
        public int aRange = 0; //Used to randomly select an attack pattern
	 
		//Booleans:
		private bool startPeriod = true; //Checks whether or not it's the start of an instance
		private bool canAttack = false; //Checks whether or not the boss is allowed to attack
		private bool jumpAttack = false; //Checks whether or not a jump attack has been selected
		private bool chargeAttack = false; //Checks whether or not a charge attack has been selected
		private bool burstAttack = false; //Checks whether or not a burst attack has been selected
		private bool secondPhase = false; //Checks whether or not the second phase has activated
        private bool attackPossible = true; //Checks whether or no an attack is avaliable for use
        private bool attackReset = true; //Checks whether or not the attack pattern needs to be reset
        private bool waiting = false; //Checks whether or not an attack has finished and starts the rest period

        //Reference:
        public Transform Player;

		void Start ()
		{
		
		}

		void FixedUpdate()  
		{
            distanceFP = Vector2.Distance(transform.position, Player.position);

			if (startPeriod == true)
			{
				sTimer++;
				if (sTimer == 240)
				{
					startPeriod = false;
					sTimer = 0;
				}
			}
			else if (startPeriod == false)
			{
			CalcAttack();
			}
		}

		public void CalcAttack()
		{ 
			if (aTimer >= 0 && attackPossible == true)
			{
				aTimer--;
                if (distanceFP <= 10f)
                {
                    if (aRange == 1)
                    {
                        Basic();
                        print("Basic");
                    }
                    else if (aRange == 2)
                    {
                        Charge();
                        print("Charge");
                    }
                    else if (aRange == 3)
                    {
                        if (secondPhase == true)
                        {
                            Burst();
                            print("Burst");
                        }
                        else
                        {
                            aRange = Random.Range(1, 3);
                            print("Redo");
                        }
                    }
                }
                else
                {
                    Jump();
                    print("Jump");
                }
			}
            if (attackReset == true)
            {
                aRange = Random.Range(0, 4);
                attackReset = false;
            }
            if (waiting == true)
            {
                Waiting();
            }

		}

		public void Basic()
		{
			aTimer = basicV;
			//set = 3;
		}

		public void Charge()
		{ 
			aTimer = chargeV;
			//set = 4;
		}	

		public void Jump()
		{ 
			aTimer = jumpV;
			//set = 5;
		}

		public void Burst()
		{ 
			aTimer = burstV;
			//set = 6;
		}

        public void Waiting()
        {
            rTimer--;
            if (rTimer == 0)
            {
                rTimer = 60;
            }
        }
	}
}
