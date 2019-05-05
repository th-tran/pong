using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer musicMixer;
	public AudioMixer soundMixer;

	public Slider musicSlider;
    public Slider soundSlider;

    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;

	public Toggle fullscreenToggle;

    private Resolution[] resolutions;

    void Start () {
        musicSlider.value = PlayerPrefs.GetFloat("MMusic", 1f);
		soundSlider.value = PlayerPrefs.GetFloat("MSound", 1f);
		musicMixer.SetFloat("music", PlayerPrefs.GetFloat("MMusic"));
		soundMixer.SetFloat("sound", PlayerPrefs.GetFloat("MSound"));

        qualityDropdown.value = PlayerPrefs.GetInt("Quality");

		resolutions = Screen.resolutions;
        
		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

        int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) {
			string option = resolutions[i].width + " x " + resolutions[i].height;
			if (!options.Contains(option)) {
				options.Add(option);

				if (resolutions[i].width == Screen.currentResolution.width &&
					resolutions[i].height == Screen.currentResolution.height) {
					currentResolutionIndex = i;
				}
			}
		}
		
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}

    public void SetResolution (int resolutionIndex) {
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	public void SetMusicVolume (float volume) {
		PlayerPrefs.SetFloat("MMusic", volume);
        musicMixer.SetFloat("music", PlayerPrefs.GetFloat("MMusic", volume));
	}

	public void SetSoundVolume (float volume) {
		PlayerPrefs.SetFloat("MSound", volume);
        soundMixer.SetFloat("sound", PlayerPrefs.GetFloat("MSound", volume));
	}

	public void SetQuality (int qualityIndex) {
		PlayerPrefs.SetInt("Quality", qualityIndex);
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void SetFullscreen (bool isFullscreen) {
		Screen.fullScreen = isFullscreen;
	}
}
