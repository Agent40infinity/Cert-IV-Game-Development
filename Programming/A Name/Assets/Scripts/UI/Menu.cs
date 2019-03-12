using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu, options;
	public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
	}
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void ToggleOptions(bool toggle)
    {
        if (toggle == true)
        {
            menu.SetActive(false);
            options.SetActive(true);
        }
        else if (toggle == false ||  Input.GetKey(KeyCode.Escape))
        {
            menu.SetActive(true);
            options.SetActive(false);
        }
    }
}
