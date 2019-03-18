using UnityEngine;
using System.Collections;
[AddComponentMenu("IntroPRG/RPG/Player Checkpoints")]
public class CheckPoint : MonoBehaviour 
{
    #region Variables
    [Header("Check Point Elements")]
    //transform for our currentCheck
    public Vector3 curCheckpoint;
    [Header("Character Health")]
    //character Health script that holds the players health
    public SliderHealth.SliderHealth health;
    #endregion
    #region Start
    public void Start()
    {
        health = GetComponent<SliderHealth.SliderHealth>();
        //Reference to the character health script component attached to our player
    }
    #endregion
    #region Update
    public void Update()
    {
        if (health.curHealth >= 0)
        {
            transform.position = curCheckpoint;
            //health.curHealth = SliderHealth.maxHealth;
        }
        //if our characters health is less than or equal to 0
        //our transform.position is equal to that of the checkpoint or float x,y,z
        //our characters health is equal to full health
        //character is alive
        //characters controller is active	
    }
    #endregion
    #region OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            curCheckpoint = other.transform.position;
            PlayerManager player = GetComponent<PlayerManager>();
            player.SavePlayer();
        }
    }

    //Collider other
    //if our other objects tag when compared is CheckPoint
    //our checkpoint is equal to the other objects transform
    //save our SpawnPoint as the name of the check point or float x,y,z
    #endregion
}





