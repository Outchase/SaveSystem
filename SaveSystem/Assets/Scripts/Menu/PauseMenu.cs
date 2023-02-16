using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneLoader.Instance.UnloadCurrentScene();
    }

    public void OpenSettings()
    {
        SceneLoader.Instance.LoadScene(SceneIndices.Settings, LoadSceneMode.Additive);
    }

    public void OpenSaveMenu()
    {
        SceneLoader.Instance.LoadScene(SceneIndices.SaveFiles, LoadSceneMode.Additive);
    }

    public void ReturnMainMenu()
    {
        SceneLoader.Instance.LoadSceneAsync(SceneIndices.MainMenu, showProgress: true);
    }

    public void Quit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif

#if UNITY_STANDALONE
        Application.Quit();
#endif
    }

}
