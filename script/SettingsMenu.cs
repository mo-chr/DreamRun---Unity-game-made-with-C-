using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    
    Resolution[] resolutions;
  
    public bool JotaroPurshasded = false;
    public TMPro.TMP_Dropdown ResolutionDropdown;
    public AudioMixer audioMixer;
    private int currentResolutionIndex = 0;
    public TextMeshProUGUI PurshaseJotaro;
    


    private void Start()
    {
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();
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
        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void Update()
    {
 
        
    }


    public void jojoClick()
    {
        PlayerPrefs.SetString("CharacterSelected", "JoJo");
       

    }
    public void pinkClick()
    {
        PlayerPrefs.SetString("CharacterSelected", "PinkGuy");
       
    
    }
    public void DreamtClick()
    {
        PlayerPrefs.SetString("CharacterSelected","Dreamt");
       
    }

    public void FroggerClick()
    {
        PlayerPrefs.SetString("CharacterSelected", "Frogger");
      
    }
    public void VRClick()
    {
        PlayerPrefs.SetString("CharacterSelected", "VRMan");
       
    }
    public void MaskClick()
    {
        PlayerPrefs.SetString("CharacterSelected", "MaskDude");
       
    }
    public void MayuhClick()
    {
        PlayerPrefs.SetString("CharacterSelected", "Mayuh");

    }

}
