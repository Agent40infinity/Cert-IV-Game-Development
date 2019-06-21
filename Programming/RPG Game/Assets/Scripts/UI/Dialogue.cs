using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public bool showDlg, grid;
    public Vector2 scrt;
    public string[] dlgText;
    public int index;
    public int optionsIndex;

    private void OnGUI()
    {
        if (showDlg)
        {
            if (scrt.x != Screen.width / 16 || scrt.y != Screen.height / 9)
            {
                scrt.x = Screen.width / 16;
                scrt.y = Screen.height / 9;
            }
            GUI.Box(new Rect(0, 6 * scrt.y, Screen.width, 3 * scrt.y), dlgText[index]);
            if (!(index >= dlgText.Length - 1 || index == optionsIndex))
            {
                if (GUI.Button(new Rect(scrt.x * 15, scrt.y * 8.5f, scrt.x, scrt.y * 0.5f), "Neat"))
                {
                    index++;
                }
            }
            else if (index == optionsIndex)
            {
                if (GUI.Button(new Rect(scrt.x * 13, scrt.y * 8.5f, scrt.x, scrt.y * 0.5f), "NeatYa"))
                {
                    index++;
                }
                if (GUI.Button(new Rect(scrt.x * 14, scrt.y * 8.5f, scrt.x, scrt.y * 0.5f), "NeatNay"))
                {
                    index = dlgText.Length - 1;
                }
            }
            else
            {
                if (GUI.Button(new Rect(scrt.x * 15, scrt.y * 8.5f, scrt.x, scrt.y * 0.5f), "Neat"))
                {
                    Movement.canMove = true;
                    index = 0;
                    showDlg = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;

                }
            }

        }

    }
}
