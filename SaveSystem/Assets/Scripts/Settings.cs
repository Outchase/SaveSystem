using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Serialization;

[Serializable]
public struct AudioSettings
{
    public float MasterVolume;
    public float BGMVolume;
    public float SFXVolume;

    public AudioSettings(float masterVolume, float sfxVolume, float bgmVolume)
    {
        MasterVolume = masterVolume;
        SFXVolume = sfxVolume;
        BGMVolume = bgmVolume;
    }
}

[Serializable]
public struct GraphicSettings
{
    public int Quality;
    public int IsFullScreen;
    public int ResolutionWidth;
    public int ResulutionHeight;

    public GraphicSettings(int quality, int isFullScreen, int resolutionWidth, int resulutionHeight)
    {
        Quality = quality;
        IsFullScreen = isFullScreen;
        ResolutionWidth = resolutionWidth;
        ResulutionHeight = resulutionHeight;
    }
}


[CreateAssetMenu(menuName = "Game Settings")]

public class Settings : ScriptableObject
{
 
    [SerializeField] private string _fileName;
    [FormerlySerializedAs("SettingsData")] public AudioSettings audioSettings;
    [FormerlySerializedAs("SettingsData")] public GraphicSettings graphicSettings;

    public float MasterVolume
    {
        get => audioSettings.MasterVolume;
        set => audioSettings.MasterVolume = value;
    }

    public float SFXVolume
    {
        get => audioSettings.SFXVolume;
        set => audioSettings.SFXVolume = value;
    }
    public float BGMVolume
    {
        get => audioSettings.BGMVolume;
        set => audioSettings.BGMVolume = value;
    }

    private string _filePath => $"{Path.Combine(Application.persistentDataPath, _fileName)}";

    public void Save()
    {
        var jsonAudioData = JsonUtility.ToJson(audioSettings);
        var jsonGraphicData = JsonUtility.ToJson(graphicSettings);
        File.WriteAllText(_filePath, jsonAudioData);
        File.AppendAllText(_filePath, jsonGraphicData);
    }

    public void Load()
    {
        if (File.Exists(_filePath))
        {
            var jsonData = File.ReadAllText(_filePath);
            var data = JsonUtility.FromJson<AudioSettings>(jsonData);
            audioSettings = data;
        }
    }
}
