using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
	public class Boss : MonoBehaviour 
	{
		//Integers:
		private int tTimer = 0; //Tick rate timer
		private int sTimer = 0; //Start timer
		private int aTimer = 0; //Attack timer
		private int baTimer = 0; //Basic Attack timer
		private int jTimer = 0; //Jump timer
		private int cTimer = 0; //Charge timer
		private int bTimer = 0; //Burst timer
		private int basicV = 0; //Basic Attack's value
		private int jumpV = 0; //Jump Attack's value
		private int chargeV = 0; //Charge Attack's value
		private int burstV = 0; //Burst Attack's value
		private int phase = 0; //Determines the difficulty of the boss
        private int move = 0; //Counts up everytime an ability is used

        //Floats:
        public float distanceFP = 0f; //Tracks how far away the Player is from the boss
        public static int Range = 0; //Used to randomly select an attack pattern
	 
		//Booleans:
		private bool startPeriod = true; //Checks whether or not it's the start of an instance
		private bool canAttack = false; //Checks whether or not the boss is allowed to attack
		private bool jumpAttack = false; //Checks whether or not a jump attack has been selected
		private bool chargeAttack = false; //Checks whether or not a charge attack has been selected
		private bool burstAttack = false; //Checks whether or not a burst attack has been selected
		private bool secondPhase = false; //Checks whether or not the second phase has activated
        private bool attackPossible = true; //Checks whether or no an attack is avaliable for use

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
			else 
			{
			CalcAttack();
			}
		}

		public void CalcAttack()
		{ 
			if (aTimer == 0 && attackPossible == true)
			{
				aTimer--;
                if (distanceFP <= 10)
                {
                    if (Random.Range(1, 3))
                    Basic();
                    Charge();
                    if (secondPhase == true)
                    {
                        Burst();
                    }
                }
				//set = 2;
				Basic();
				Charge();
				Jump();
				Burst();
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
	}
}
