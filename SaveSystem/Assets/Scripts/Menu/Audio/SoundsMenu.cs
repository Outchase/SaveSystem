using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundsMenu : MonoBehaviour
{
    [SerializeField] private Settings settingPref;
    [SerializeField] private GameObject soundsMenuUI;
    [SerializeField] private GameObject returnMenuUI;

    [SerializeField] private float defaultVolumeValue = 1.0f;
    [SerializeField] private float masterVolumeValue;
    [SerializeField] private float bgmVolumeValue;
    [SerializeField] private float sfxVolumeValue;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider = null;
    [SerializeField] private Slider bgmSlider = null;
    [SerializeField] private Slider sfxSlider = null;

    //[SerializeField] private AudioMixer mainMixer;
    [SerializeField] private GameObject confirmationPrompt = null;


    public void Awake()
    {
        //var eventSystem = FindObjectOfType<EventSystem>();

        masterSlider.value = settingPref.MasterVolume;
        sfxSlider.value = settingPref.SFXVolume;
        bgmSlider.value = settingPref.BGMVolume;

        masterSlider.onValueChanged.AddListener(OnMasterSliderChange);
        bgmSlider.onValueChanged.AddListener(OnBGMSliderChange);
        sfxSlider.onValueChanged.AddListener(OnSFXSliderChange);

        //mainMixer.GetFloat("MainVolume", out float value);
        //bgmVolumeSlider.value = Mathf.Pow(10, value * 0.05f);
        //sfxVolumeSlider.value = Mathf.Pow(10, value * 0.05f);
    }

    public void OnMasterSliderChange(float value)
    {
        masterVolumeValue= value;
        audioMixer.SetFloat("MasterVolume", value);
        //audioSettings.MasterVolume = value;

    }

    public void OnBGMSliderChange(float value)
    {
        bgmVolumeValue= value;
        audioMixer.SetFloat("BGMVolume", value);
        //audioSettings.BGMVolume = value;
    }

    public void OnSFXSliderChange(float value)
    {
        sfxVolumeValue= value;
        audioMixer.SetFloat("SFXVolume", value);
        //audioSettings.SFXVolume = value;
    }

    public void CloseSoundsMenu()
    {
        returnMenuUI.SetActive(true);

        masterSlider.value = settingPref.MasterVolume;
        sfxSlider.value = settingPref.SFXVolume;
        bgmSlider.value = settingPref.BGMVolume;

        soundsMenuUI.SetActive(false);
    }

    public void VolumeApply()
    {
        //PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);


        StartCoroutine(ConfirmationBox());

        audioMixer.SetFloat("MasterVolume", masterVolumeValue);
        audioMixer.SetFloat("BGMVolume", bgmVolumeValue);
        audioMixer.SetFloat("SFXVolume", sfxVolumeValue);

        settingPref.MasterVolume = masterVolumeValue;
        settingPref.BGMVolume = bgmVolumeValue;
        settingPref.SFXVolume = sfxVolumeValue;



        settingPref.Save();
        // Debug.Log(PlayerPrefs.GetFloat("masterVolume", AudioListener.volume));

        //Debug.Log("Applied Sound Settings");
    }

    public void ResetSettings(string _menuType)
    {
        if (_menuType == "Audio")
        {
            /*AudioListener.volume = defaultVolume;*/
            audioMixer.SetFloat("MasterVolume", defaultVolumeValue);
            audioMixer.SetFloat("BGMVolume", defaultVolumeValue);
            audioMixer.SetFloat("SFXVolume", defaultVolumeValue);

            settingPref.MasterVolume= defaultVolumeValue;
            settingPref.BGMVolume= defaultVolumeValue;
            settingPref.SFXVolume = defaultVolumeValue;

            masterSlider.value = settingPref.MasterVolume;
            sfxSlider.value = settingPref.SFXVolume;
            bgmSlider.value = settingPref.BGMVolume;

            VolumeApply();

        }
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
