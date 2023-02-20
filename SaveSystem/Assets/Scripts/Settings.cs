using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Serialization;
using static UnityEngine.Rendering.DebugUI;

[Serializable]
public struct SettingsPref
{
    public float MasterVolume;
    public float BGMVolume;
    public float SFXVolume;
    public int QualityIndex;
    public Vector3Int Resolution;

    public SettingsPref( float masterVolume, float sfxVolume, float bgmVolume, int qualityIndex, Vector3Int resolution)
    {
        MasterVolume = masterVolume;
        SFXVolume = sfxVolume;
        BGMVolume = bgmVolume;
        QualityIndex = qualityIndex;
        Resolution = resolution;
    }
}


[CreateAssetMenu(menuName = "Game Settings")]

public class Settings : ScriptableObject
{
 
    [SerializeField] private string _fileName;
    [FormerlySerializedAs("SettingsData")] public SettingsPref settingsPref;

    public float MasterVolume
    {
        get => settingsPref.MasterVolume;
        set => settingsPref.MasterVolume = value;
    }

    public float SFXVolume
    {
        get => settingsPref.SFXVolume;
        set => settingsPref.SFXVolume = value;
    }
    public float BGMVolume
    {
        get => settingsPref.BGMVolume;
        set => settingsPref.BGMVolume = value;
    }

    public int Quality
    {
        get => settingsPref.QualityIndex;
        set => settingsPref.QualityIndex = (int)value;
    }

    public Vector3Int Resolution
    {
        get => settingsPref.Resolution;
        set => settingsPref.Resolution = value;
    }

    private string _filePath => $"{Path.Combine(Application.persistentDataPath, _fileName)}";

    public void Save()
    {
        //var jsonData = JsonUtility.ToJson("[\"Audio\":" + audioSettings + "}", true);
        var jsonData = JsonUtility.ToJson(settingsPref, true);
        //jsonData += JsonUtility.ToJson(graphicSettings, true);
        File.WriteAllText(_filePath, jsonData);
    }

    public void Load()
    {
        if (File.Exists(_filePath))
        {
            var jsonData = File.ReadAllText(_filePath);
            var data = JsonUtility.FromJson<SettingsPref>(jsonData);
            settingsPref = data;
        }
    }

}
