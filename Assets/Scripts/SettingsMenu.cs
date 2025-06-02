using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public static string openedFrom = "";

    public AudioMixer audioMixer;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    public GameObject panel;
    public GameObject mainMenuPanel;
    public GameObject pausePanel;

    // 16:9 해상도 리스트
    private Resolution[] customResolutions = new Resolution[]
    {
        new Resolution { width = 1920, height = 1080 },
        new Resolution { width = 1600, height = 900 },
        new Resolution { width = 1280, height = 720 }
    };

    void Start()
    {
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);

        resolutionDropdown.ClearOptions();
        var options = new System.Collections.Generic.List<string>();
        int currentIndex = 0;

        for (int i = 0; i < customResolutions.Length; i++)
        {
            var res = customResolutions[i];
            string option = res.width + " x " + res.height;
            options.Add(option);

            if (res.width == Screen.currentResolution.width &&
                res.height == Screen.currentResolution.height)
            {
                currentIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentIndex;
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        fullscreenToggle.isOn = Screen.fullScreen;
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    public void SetBgmVolume(float value)
    {
        if (value <= 0.0001f) value = 0.0001f;
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(value) * 20);
    }

    public void SetSfxVolume(float value)
    {
        if (value <= 0.0001f) value = 0.0001f;
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }

    public void SetResolution(int index)
    {
        Resolution res = customResolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void CloseSettings()
    {
        panel.SetActive(false);

        if (openedFrom == "MainMenu" && mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        if (openedFrom == "PauseMenu" && pausePanel != null)
            pausePanel.SetActive(true);

        openedFrom = "";
    }
}
