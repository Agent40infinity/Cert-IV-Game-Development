using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public static int money;
    public Item selectedItem;
    public string[] sortTypes;
    public string selectedType;

    public Vector2 scrt;
    public Vector2 scrollPos;
    public Transform[] equippedLocation; // 0 = right, 1 = left (hand)
    public Transform dropLocation;
    public GameObject curWeapon;
    public GameObject curHelmet;

    void Start()
    {
        sortTypes = new string[] { "All", "Food", "Weapon", "Apparel", "Crafting", "Quest", "Ingredients", "Potion", "Scroll" };
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(101));
        inv.Add(ItemData.CreateItem(202));

        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].Name);
        }
    }

    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Movement.canMove = true;
            return false;
        }
        else
        {
            if (scrt.x != Screen.width / 16 || scrt.y != Screen.height / 9)
            {
                scrt.x = Screen.width / 16;
                scrt.y = Screen.height / 9;
            }
            showInv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Movement.canMove = false;
            return true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInv();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            inv.Add(ItemData.CreateItem(0));
            inv.Add(ItemData.CreateItem(101));
            inv.Add(ItemData.CreateItem(202));
        }
    }

    void DisplayInv(string sortType)
    {
        if (!(sortType == "All" || sortType == ""))
        {
            ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);
            int a = 0; //Amount
            int s = 0; //Slot
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].Type == type)
                {
                    a++;
                }
            }
            if (a <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)
                    {
                        if (GUI.Button(new Rect(0.5f * scrt.x, 0.25f * scrt.y + s * (0.25f * scrt.y), 3f * scrt.x, 0.25f * scrt.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        s++;
                    }
                }
            }
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scrt.x, 0.25f * scrt.y, 3.5f * scrt.x, 8.5f * scrt.y), scrollPos, new Rect(0, 0, 0, 8.5f * scrt.y + (a - 34 * (0.25f * scrt.y))), false, true);
                GUI.EndScrollView();

                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)
                    {
                        if (GUI.Button(new Rect(0, s * (0.25f * scrt.y), 3f * scrt.x, 0.25f * scrt.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                            s++;
                        }
                    }
                    GUI.EndScrollView();
                }
            }
        }
        else
        {
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scrt.x, 0.25f * scrt.y + i * (0.25f * scrt.y), 3f * scrt.x, 0.25f * scrt.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }

                }
            }

            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scrt.x, 0.25f * scrt.y, 3.5f * scrt.x, 8.5f * scrt.y), scrollPos, new Rect(0, 0, 0, 8.5f * scrt.y + (inv.Count - 34 * (0.25f * scrt.y))), false, true);
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0 * scrt.x, 0 * scrt.y + i * (0.25f * scrt.y), 3f* scrt.x, 0.25f * scrt.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
                GUI.EndScrollView();
            }
        }
    }

    void OnGUI()
    {
        if (showInv)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
            for (int i = 0; i < sortTypes.Length; i++)
            {
                if (GUI.Button(new Rect(5.5f * scrt.x + i * (scrt.x), 0.25f * scrt.y, scrt.x, 0.25f * scrt.y), sortTypes[i]))
                {
                    selectedType = sortTypes[i];
                }
            }
            DisplayInv(selectedType);
            if (selectedItem != null)
            {
                GUI.DrawTexture(new Rect(11 * scrt.x, 1.5f * scrt.y, 2 * scrt.x, 2 * scrt.y), selectedItem.Icon);
            }
        }
    }
}
