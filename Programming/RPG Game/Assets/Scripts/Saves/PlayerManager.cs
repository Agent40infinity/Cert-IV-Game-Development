using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int level;
    public new string name;
    public float health;
    public SliderHealth.SliderHealth SliderHealth;
    public CheckPoint CheckPoint;
    public float x, y, z;
    public int[] stats = new int[6];
    public GameObject customizer;


    public void SavePlayer()
    {
        health = SliderHealth.curHealth;
        x = CheckPoint.curCheckpoint.x;
        y = CheckPoint.curCheckpoint.y;
        z = CheckPoint.curCheckpoint.z;
        name = CustomisationSet.characterName;
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = customizer.GetComponent<CustomisationSet>().stats[i];
        }
        Save.SavePlayerData(this);
    }
    public void LoadPlayer()
    {
        DataToSave data = Save.LoadPlayerData();
        level = data.level;
        name = data.playerName;
        health = data.health;
        x = data.x;
        y = data.y;
        z = data.z;
        this.transform.position = new Vector3(x, y, z);
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = data.stats[i];
        }
    }
}
