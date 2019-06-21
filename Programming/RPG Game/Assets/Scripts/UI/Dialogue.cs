using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public bool showDlg;
    //public Vector2 scrt;
    public string[] dlgText = new string[5];
    public int index;
    //public int optionsIndex;
    public GameObject dialogue;
    public Text reference;
    //public GameObject customizer;
    public GameObject accept, decline, next;        
    public GameObject display;
    public GameObject player;

    public void Start()
    {
        showDlg = false;
        dlgText[0] = "Hello " + CustomisationSet.characterName + ", would you be able to help me?";
        dlgText[1] = "I need some help finding how you're meant to play this game.";
        dlgText[2] = "Excelent! Please press f to collect and complete your objective.";
        dlgText[3] = "That's a shame. Oh well, have a nice day!";
    }

    public void Update()
    {
        //reference.text = dlgText[index];
        if (Input.GetKeyDown(KeyCode.H))
        {
            showDialogue();
        }
    }

    public void showDialogue()
    {
        if (showDlg == true)
        {
            dialogue.SetActive(false);
            display.SetActive(true);
            Movement.canMove = true;
            index = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            player.GetComponent<MouseLook>().enabled = true;
            showDlg = false;
        }
        else
        {
            dialogue.SetActive(true);
            display.SetActive(false);
            reference.text = dlgText[index];
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            player.GetComponent<MouseLook>().enabled = false;
            showDlg = true;
        }
    }

    public void Next()
    {
        if (index < 1)
        {
            index++;
            reference.text = dlgText[index];
        }
        else if (index == 1)
        {
            accept.SetActive(true);
            decline.SetActive(true);
            next.SetActive(false);
            reference.text = dlgText[index];
        }
        else if (index >= 2)
        {
            showDialogue();
        }
    }

    public void Decline()
    {
        index = 3;
        reference.text = dlgText[index];
        accept.SetActive(false);
        decline.SetActive(false);
        next.SetActive(true);
    }

    public void Accept()
    {
        index++;
        reference.text = dlgText[index];
        accept.SetActive(false);
        decline.SetActive(false);
        next.SetActive(true);
    }
    //private void OnGUI()
    //{
    //    if (showDlg)
    //    {
    //        if (scrt.x != Screen.width / 16 || scrt.y != Screen.height / 9)
    //        {
    //            scrt.x = Screen.width / 16;
    //            scrt.y = Screen.height / 9;
    //        }
    //        GUI.Box(new Rect(0, 6 * scrt.y, Screen.width, 3 * scrt.y), dlgText[index]);
    //        if (!(index >= dlgText.Length - 1 || index == optionsIndex))
    //        {
    //            if (GUI.Button(new Rect(scrt.x * 15, scrt.y * 8.5f, scrt.x, scrt.y * 0.5f), "Neat"))
    //            {
    //                index++;
    //            }
    //        }
    //        else if (index == optionsIndex)
    //        {
    //            if (GUI.Button(new Rect(scrt.x * 13, scrt.y * 8.5f, scrt.x, scrt.y * 0.5f), "NeatYa"))
    //            {
    //                index++;
    //            }
    //            if (GUI.Button(new Rect(scrt.x * 14, scrt.y * 8.5f, scrt.x, scrt.y * 0.5f), "NeatNay"))
    //            {
    //                index = dlgText.Length - 1;
    //            }
    //        }
    //        else
    //        {
    //            if (GUI.Button(new Rect(scrt.x * 15, scrt.y * 8.5f, scrt.x, scrt.y * 0.5f), "Neat"))
    //            {
    //                Movement.canMove = true;
    //                index = 0;
    //                showDlg = false;
    //                Cursor.lockState = CursorLockMode.Locked;
    //                Cursor.visible = false;

    //            }
    //        }

    //    }

    //}
}
