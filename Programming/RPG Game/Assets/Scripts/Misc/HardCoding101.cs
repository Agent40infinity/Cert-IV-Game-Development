using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardCoding101 : MonoBehaviour
{
    public Vector2 scrt;
    private void OnGUI()
    {
        if (scrt.x != Screen.width / 16)
        {
            scrt.x = Screen.width / 16;
            scrt.y = Screen.height / 9;
        }

        for (int x = 0; x < 17; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                GUI.Box(new Rect(scrt.x * x, scrt.y * y, scrt.x, scrt.y), "");
                //GUI.Box(new Rect((scrt.x * x) - scrt * , 0, scrt.x, scrt.y), "");
            }
        }
    }
}
