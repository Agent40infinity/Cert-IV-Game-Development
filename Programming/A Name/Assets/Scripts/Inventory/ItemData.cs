using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static Item CreateItem(int itemID)
    {
        string name = " "; 
        int value = 0; 
        string description = " "; 
        string icon = " "; 
        string mesh = " ";
        ItemType type = ItemType.Food; 
        int heal = 0;
        int damage = 0;
        int armour = 0;
        int amount = 0;

        switch (itemID)
        {
            default:
                itemID = 0;
                name = "Apple";
                value = 5;
                description = "Munchy and Crunchy";
                icon = "Food/1";
                mesh = "Food/1_Mesh";
                type = ItemType.Food;
                heal = 5;
                amount = 1;
                break;
            #region Food 0-99
            case 0:
                itemID = 0000;
                name = "Apple";
                value = 5;
                description = "Munchy and Crunchy";
                icon = "Food/1";
                mesh = "Food/1_Mesh";
                type = ItemType.Food;
                heal = 5;
                amount = 1;
                break;
            case 1:
                itemID = 0001;
                name = "Common Shell";
                value = 0;
                description = "";
                icon = "Food/2";
                mesh = "Food/2_Mesh";
                type = ItemType.Food;
                heal = 0;
                amount = 1;
                break;
            case 2:
                itemID = 0002;
                name = "Package";
                value = 0;
                description = "";
                icon = "Food/3";
                mesh = "Food/3_Mesh";
                type = ItemType.Food;
                heal = 0;
                amount = 1;
                break;
                #endregion
                #region Weapon 100-199
            case 100:
                itemID = 0100;
                name = "Golden Knife";
                value = 0;
                description = "";
                icon = "Weapons/1";
                mesh = "Weapons/1_Mesh";
                type = ItemType.Weapon;
                damage = 0;
                amount = 1;
                break;
            case 101:
                itemID = 0101;
                name = "Sharp Sword";
                value = 0;
                description = "";
                icon = "Weapons/2";
                mesh = "Weapons/2_Mesh";
                type = ItemType.Weapon;
                damage = 0;
                amount = 1;
                break;
            case 102:
                itemID = 0102;
                name = "Default Sword";
                value = 0;
                description = "";
                icon = "Weapons/3";
                mesh = "Weapons/3_Mesh";
                type = ItemType.Weapon;
                damage = 0;
                amount = 1;
                break;
            #endregion
            #region Apparel 200-299
            case 200:
                itemID = 0200;
                name = "Royal Mage Gloves";
                value = 0;
                description = "";
                icon = "Apparel/1";
                mesh = "Apparel/1_Mesh";
                type = ItemType.Apparel;
                armour = 0;
                amount = 1;
                break;
            case 201:
                itemID = 0201;
                name = "Royal Mage Robes";
                value = 0;
                description = "";
                icon = "Apparel/2";
                mesh = "Apparel/2_Mesh";
                type = ItemType.Apparel;
                armour = 0;
                amount = 1;
                break;
            case 202:
                itemID = 0202;
                name = "Royal Mage Celtic";
                value = 0;
                description = "";
                icon = "Apparel/3";
                mesh = "Apparel/3_Mesh";
                type = ItemType.Apparel;
                armour = 0;
                amount = 1;
                break;
            #endregion
            #region Crafting 300-399
            case 300:
                itemID = 0300;
                name = "Hammer";
                value = 0;
                description = "";
                icon = "Crafting/1";
                mesh = "Crafting/1_Mesh";
                type = ItemType.Crafting;
                amount = 1;
                break;
            case 301:
                itemID = 0301;
                name = "Bomb";
                value = 0;
                description = "";
                icon = "Crafting/2";
                mesh = "Crafting/2_Mesh";
                type = ItemType.Crafting;
                amount = 1;
                break;
            case 302:
                itemID = 0302;
                name = "Spring";
                value = 0;
                description = "";
                icon = "Crafting/3";
                mesh = "Crafting/3_Mesh";
                type = ItemType.Crafting;
                amount = 1;
                break;
            #endregion
            #region Quest 400-499
            case 400:
                itemID = 0400;
                name = "Artifact 001";
                value = 0;
                description = "";
                icon = "Quests/1";
                mesh = "Quests/1_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            case 401:
                itemID = 0401;
                name = "Artifact 002";
                value = 0;
                description = "";
                icon = "Quests/2";
                mesh = "Quests/2_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            case 402:
                itemID = 0402;
                name = "Artifact 003";
                value = 0;
                description = "";
                icon = "Quests/3";
                mesh = "Quests/3_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            #endregion
            #region Ingredients 500-599
            case 500:
                itemID = 0500;
                name = "Grass";
                value = 0;
                description = "";
                icon = "Ingredients/1";
                mesh = "Ingredients/1_Mesh";
                type = ItemType.Ingredient;
                amount = 1;
                break;
            case 501:
                itemID = 0501;
                name = "Stick";
                value = 0;
                description = "";
                icon = "Ingredients/2";
                mesh = "Ingredients/2_Mesh";
                type = ItemType.Ingredient;
                amount = 1;
                break;
            case 502:
                itemID = 0502;
                name = "Iron Ingot";
                value = 0;
                description = "";
                icon = "Ingredients/3";
                mesh = "Ingredients/3_Mesh";
                type = ItemType.Ingredient;
                amount = 1;
                break;
            #endregion
            #region Potions 600-699
            case 600:
                itemID = 0600;
                name = "Healing Potion";
                value = 0;
                description = "";
                icon = "Potions/1";
                mesh = "Potions/1_Mesh";
                type = ItemType.Potion;
                heal = 0;
                amount = 1;
                break;
            case 601:
                itemID = 0601;
                name = "Poison Potion";
                value = 0;
                description = "";
                icon = "Potions/2";
                mesh = "Potions/2_Mesh";
                type = ItemType.Potion;
                damage = 0;
                amount = 1;
                break;
            case 602:
                itemID = 0602;
                name = "Mana Potion";
                value = 0;
                description = "";
                icon = "Potions/3";
                mesh = "Potions/3_Mesh";
                type = ItemType.Potion;
                heal = 0;
                amount = 1;
                break;
            #endregion
            #region Scrolls 700-799
            case 700:
                itemID = 0700;
                name = "Scroll of Binding";
                value = 0;
                description = "";
                icon = "Scrolls/1";
                mesh = "Scrolls/1_Mesh";
                type = ItemType.Scroll;
                amount = 1;
                break;
            case 701:
                itemID = 0701;
                name = "Tablet of Corruption";
                value = 0;
                description = "";
                icon = "Scrolls/2";
                mesh = "Scrolls/2_Mesh";
                type = ItemType.Scroll;
                amount = 1;
                break;
            case 702:
                itemID = 0702;
                name = "Fireblast Spell";
                value = 0;
                description = "";
                icon = "Scrolls/3";
                mesh = "Scrolls/3_Mesh";
                type = ItemType.Scroll;
                damage = 0;
                amount = 1;
                break;
                #endregion
        }
        Item temp = new Item
        {
            Name = name,
            Description = description,
            ID = itemID,
            Value = value,
            Damage = damage,
            Armour = armour,
            Amount = amount,
            Heal = heal,
            Type = type,
            Mesh = Resources.Load("Prefabs/" + mesh) as GameObject,
            Icon = Resources.Load("Icon/" + mesh) as Texture2D
    };
        return temp;
    }
}
