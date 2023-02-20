using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    [SerializeField] private GameObject controlsMenuUI;
    [SerializeField] private GameObject returnMenuUI;

    public void CloseControlsMenu()
    {
        returnMenuUI.SetActive(true);
        controlsMenuUI.SetActive(false);
    }
}
