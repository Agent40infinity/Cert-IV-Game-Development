using UnityEngine;
using System.Collections;
//23 errors
public class Dialogue : MonoBehaviour
{
    public string[] text = new string[5];
    public int index, option;
    public bool showDlg;
    public float scrW, scrH;
    public GameObject player, mainCam;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //mainCam = GameObject.FindGameObjectWithTag("Main Camera");
    }

    public void OnGUI()
	{
        if (showDlg == true)
        {
            scrW = Screen.width / 16;
            scrH = Screen.height / 9;
        
            GUI.Box(new Rect(0, 6 * scrH, Screen.width, 3 * scrH), text[index]);
            if (!(index >= text.Length - 1 || index == option))
            {
                if (GUI.Button(new Rect(15 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "Next"))
                {
                    index++;
                }
            }
            else if (index == option)
            {
                if (GUI.Button(new Rect(14 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "Accept"))
                {
                    index++;
                }
                if (GUI.Button(new Rect(15 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "Decline"))
                {
                    index = text.Length - 1;
                }
            }
            else
            {
                if (GUI.Button(new Rect(15 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "Bye"))
                {
                    index = 0;
                    showDlg = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }

    }
}
