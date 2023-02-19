using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    private int tmpQualityLevel;
    private bool tmpIsFullscreen;

    [SerializeField] private Settings graphicSettings;
    [SerializeField] private GameObject graphicsMenuUI;
    [SerializeField] private GameObject returnMenuUI;



    [SerializeField] private GameObject confirmationPrompt = null;

    public TMP_Dropdown resolutionDropDown;
    [SerializeField] private TMP_Dropdown qualityDropDown;
    [SerializeField] private Toggle fullScreenToggle;
    private Resolution[] resolutions;
    Resolution resolution;
    private void Awake()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        List<string> options = new();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        resolution = resolutions[resolutionIndex];
        Debug.Log(resolution);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        tmpIsFullscreen = isFullscreen;
    }

    public void SetQuality(int quatlyIndex)
    {
        tmpQualityLevel = quatlyIndex;
    }

    public void GraphicsApply()
    {
        //PlayerPrefs.SetInt("masterQuality", tmpQualityLevel);

        //PlayerPrefs.SetInt("masterFullscreen", (tmpIsFullscreen ? 1 : 0));

        StartCoroutine(ConfirmationBox());

        Screen.fullScreen = tmpIsFullscreen;
        QualitySettings.SetQualityLevel(tmpQualityLevel);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);



        //Debug.Log(PlayerPrefs.GetInt("masterFullscreen"));

        //Debug.Log("Applied Graphic Settings");

    }
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
    public void CloseGraphicsMenu()
    {
        returnMenuUI.SetActive(true);
        graphicsMenuUI.SetActive(false);
    }

    public void ResetGraphicSettings(string _menuType)
    {
        if (_menuType == "Graphics")
        {
            /*qualityDropDown.value = 1;
            QualitySettings.SetQualityLevel(1);

            fullScreenToggle.isOn = false;
            Screen.fullScreen = false;

            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropDown.value = resolutions.Length;*/

            //Debug.Log(_menuType);
            //Debug.Log("Reset Settrings");

            //GraphicsApply();
        }
    }
}
