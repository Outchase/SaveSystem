using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneIndices
{
    LoadingScreen,
    MainMenu,
    Game,
    Settings,
    Pause,
    SaveFiles
}

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    [SerializeField] private SceneIndices startScene;

    private Stack<string> sceneStack = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadScene(startScene);

        SceneManager.sceneLoaded += RegisterNewScene;
    }

    private void RegisterNewScene(Scene scene, LoadSceneMode node)
    {
        sceneStack.Push(scene.name);

    }

    public void LoadScene(SceneIndices sceneIndex, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene((int)sceneIndex, loadSceneMode);
    }

    public void UnloadScene(SceneIndices sceneIndex)
    {
        //SceneManager.UnloadSceneAsync()
    }

    public void UnloadCurrentScene()
    {
        SceneManager.UnloadSceneAsync(sceneStack.Pop());
    }
}
