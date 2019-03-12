using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject options;
    public GameObject keybinds;
	public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
	}
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void ToggleSettings(int toggle)
    {
        if (toggle == 0)
        {
            menu.SetActive(false);
            options.SetActive(true);
        }
        else if (toggle == 1 || Input.GetButton("Cancel"))
        {
            menu.SetActive(true);
            options.SetActive(false);
        }
        else if (toggle == 2 || Input.GetButton("Cancel"))
        {

        }
    }
}
