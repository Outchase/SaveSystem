using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] private GameObject returnMenuUI;
    [SerializeField] private GameObject creditsMenuUI;

    public void OnReturn()
    {
        returnMenuUI.SetActive(true);
        creditsMenuUI.SetActive(false);
    }
}

