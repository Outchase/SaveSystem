using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundsMenu : MonoBehaviour
{
    [SerializeField] private GameObject soundsMenuUI;
    [SerializeField] private GameObject returnMenuUI;
    //[SerializeField] private float defaultVolume = 1.0f;

    //[SerializeField] private Slider bgmVolumeSlider = null;
    //[SerializeField] private Slider sfxVolumeSlider = null;
    //[SerializeField] private AudioMixer mainMixer;
    [SerializeField] private GameObject confirmationPrompt = null;


    public void Awake()
    {
        //mainMixer.GetFloat("MainVolume", out float value);
        //bgmVolumeSlider.value = Mathf.Pow(10, value * 0.05f);
        //sfxVolumeSlider.value = Mathf.Pow(10, value * 0.05f);
    }

    public void CloseSoundsMenu()
    {
        returnMenuUI.SetActive(true);
        soundsMenuUI.SetActive(false);
    }

    public void VolumeApply()
    {
        //PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
        // Debug.Log(PlayerPrefs.GetFloat("masterVolume", AudioListener.volume));

        Debug.Log("Applied Settings");
    }

    public void ResetSettings(string _menuType)
    {
        if (_menuType == "Audio")
        {
            /*AudioListener.volume = defaultVolume;
            VolumeApply();*/

            Debug.Log(_menuType);
            Debug.Log("Reset Audio");
        }
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
