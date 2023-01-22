using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenuUI;
    //[SerializeField] private GameObject controlsMenuUI;
    [SerializeField] private GameObject soundMenuUI;
    [SerializeField] private GameObject graphicsMenuUI;
    [SerializeField] private GameObject creditsMenuUI;
    [SerializeField] private GameObject returnMenuUI;

    /*public void OpenControlsMenu()
    {
        optionsMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
    }*/

    public void OpenSoundsMenu()
    {
        optionsMenuUI.SetActive(false);
        soundMenuUI.SetActive(true);
    }
    public void OpenGraphicsMenu()
    {
        optionsMenuUI.SetActive(false);
        graphicsMenuUI.SetActive(true);
    }
    public void CloseOptionsMenu()
    {
        returnMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    public void OpenCreditsMenu()
    {
        optionsMenuUI.SetActive(false);
        creditsMenuUI.SetActive(true);
    }
}
