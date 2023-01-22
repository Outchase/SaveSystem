using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject returnMenuUI;
    [SerializeField] private GameObject loadGameMenuUI;

    public void OnReturn()
    {
        returnMenuUI.SetActive(true);
        loadGameMenuUI.SetActive(false);
    }
}
