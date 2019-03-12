using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SliderHealth
{
	[AddComponentMenu("Linear Health")]
	public class SliderHealth : MonoBehaviour 
	{
		[Header("Player Health")]
		public int maxHealth = 100;
		public int curHealth;

		[Header("UI Reference")]
		public Slider healthBar;
		public Image sliderFill;

		public void Start()
		{
			curHealth = maxHealth;
		}
		public void Update () 
		{
			healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
		}	
		public void HealthManager()
		{
			if (curHealth <= 0 && sliderFill.enabled)
			{
				Debug.Log("Dead");
				sliderFill.enabled = false;
			}
			else if (!sliderFill.enabled && curHealth > 0)
			{
				Debug.Log("Revived");
				sliderFill.enabled = true;
			}
		}

	}
}
