using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int level;
    public new string name;
    public float health;

    public void SavePlayer()
    {
        Save.SavePlayerData(this);
    }
    public void LoadPlayer()
    {
        DataToSave data = Save.LoadPlayerData();
        level = data.level;
        name = data.playerName;
        health = data.health;

    }
}
