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


    public void SavePlayer()
    {
        health = SliderHealth.curHealth;
        x = CheckPoint.curCheckpoint.x;
        y = CheckPoint.curCheckpoint.y;
        z = CheckPoint.curCheckpoint.z;
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

    }
}
