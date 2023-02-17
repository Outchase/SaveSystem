using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuButtons : MonoBehaviour
{
    //initalize the UIs
    [SerializeField] private GameObject mainMenuUI;

    //change scene on the given sceneID
    public void OnNewGame()
    {
        SceneLoader.Instance.LoadSceneAsync(SceneIndices.Game, showProgress: true);
    }

    public void OpenSaveMenu()
    {
        SceneLoader.Instance.LoadScene(SceneIndices.SaveFiles, LoadSceneMode.Additive);
    }

    //open options menu
    public void OpenOptionsMenu()
    {
        SceneLoader.Instance.LoadScene(SceneIndices.Settings, LoadSceneMode.Additive);
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
