using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHP = 100;   
    public float curHP;
    public Canvas enemyHealth;
    public Slider healthSlider;

    public void Start()
    {
        enemyHealth = this.transform.Find("EnemyHealth").GetComponent<Canvas>();
        healthSlider = enemyHealth.transform.Find("Slider").GetComponent<Slider>();
        curHP = maxHP;
    }
    public void Update ()
    {
        healthSlider.value = Mathf.Clamp01(curHP / maxHP);
        //enemyHealth.transform.LookAt(Camera.main.transform);
	}
}
