using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuButtons : MonoBehaviour
{
    //initalize the UIs
    [SerializeField] private GameObject optionsMenuUI;
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject loadGameMenuUI;

    //change scene on the given sceneID
    public void OnNewGame(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void OnLoadGame()
    {
        loadGameMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    //open options menu
    public void OpenOptionsMenu()
    {
        optionsMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    //exit application
    public void OnQuitGame()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif

#if UNITY_STANDALONE
        Application.Quit();
#endif
    }
}
