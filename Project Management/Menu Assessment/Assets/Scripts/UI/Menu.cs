using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //General:
    public GameObject menu, options;
    public bool toggle = false;

    //Settings:
    public AudioMixer mainMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    #region General
    public void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions(); 

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }   

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.M) == true)
        {
            toggle = false;
        }
    }
    #endregion
    #region Main
    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void Exit()  
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void ToggleOptions(bool toggle)
    {
        if (toggle == true)
        {
            menu.SetActive(false);
            options.SetActive(true);
        }
        else if (toggle == false)
        {
            menu.SetActive(true);
            options.SetActive(false);
        }
    }
    #endregion
    #region Menu_Settings
    public void ChangeVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }

    public void ChangeQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ChangeResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    #endregion
}
