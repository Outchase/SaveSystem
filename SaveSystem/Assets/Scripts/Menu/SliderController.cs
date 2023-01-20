using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private string faderName;
    [SerializeField] private AudioMixerGroup fader;
    [SerializeField] private TextMeshProUGUI volumeTextValue = null;
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private bool isSFXCheck = false;

    public void SetVolume(float volume)
    {
        if (isSFXCheck)
        {
            audioSource.Play();
        }

        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0");

        fader.audioMixer.SetFloat(faderName, Mathf.Log10(volume) * 20);
    }
}