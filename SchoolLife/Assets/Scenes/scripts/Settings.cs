using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    public FloatValue playerHealth;
    public FloatValue playerEnergy;
    public FloatValue playerHappiness;
    public FloatValue playerKnowledge;
    public FloatValue playerMoney;
    public InventoryItem chocalate;
    public InventoryItem smallpill;
    public InventoryItem energydrink;

    private int _qualityLevel;
    private bool _isFullscreen;

    public Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
       
        int currentResolutionIndex = 0;

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

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        if(resolution.refreshRate == 60 || resolution.refreshRate == 75 || resolution.refreshRate == 120 || resolution.refreshRate == 144 || resolution.refreshRate == 165 || resolution.refreshRate == 240 || resolution.refreshRate == 360)
        {
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
        }        
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    }

    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        _isFullscreen = isFullscreen;
        PlayerPrefs.SetInt("masterFullscreen", (_isFullscreen ? 1 : 0));
        Screen.fullScreen = _isFullscreen;
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("MainMenu");
        playerEnergy.initialValue = 50;
        playerHealth.initialValue = 70;
        playerKnowledge.initialValue = 0;
        playerMoney.initialValue = 10;
        playerHappiness.initialValue = 50;
        chocalate.numberHeld = 1;
        energydrink.numberHeld = 1;
        smallpill.numberHeld = 1;
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        SceneManager.UnloadSceneAsync(2);
    }
}
