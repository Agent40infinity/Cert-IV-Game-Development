using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataToSave
{
    public int level;
    public string playerName;
    public float health;

    public DataToSave(PlayerManager player)
    {
        level = player.level;
        playerName = player.name;
        health = player.health;
    }
}
