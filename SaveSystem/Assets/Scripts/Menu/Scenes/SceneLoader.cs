using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image fillingBar;
    [SerializeField] private float minLoadingDuration = 2f;


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
        loadingScreen.SetActive(false);
    }

    private void RegisterNewScene(Scene scene, LoadSceneMode node)
    {
        sceneStack.Push(scene.name);

    }

    public void LoadScene(SceneIndices sceneIndex, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene((int)sceneIndex, loadSceneMode);
    }

    public void LoadSceneAsync(SceneIndices sceneIndex, LoadSceneMode loadSceneMode = LoadSceneMode.Single, bool showProgress = false)
    {
        var asyncOperation = SceneManager.LoadSceneAsync((int)sceneIndex, loadSceneMode);

        if (showProgress)
        {
            StartCoroutine(LoadingProgress(asyncOperation));
        }
    }

    private IEnumerator LoadingProgress(AsyncOperation asyncOperation)
    {
        asyncOperation.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        fillingBar.fillAmount = 0f;
        var counter = 0f;

        while (asyncOperation.progress < 0.9f || counter <= minLoadingDuration)
        {
            yield return null;
            counter += Time.unscaledDeltaTime;

            var waitProgress = counter / minLoadingDuration;
            var loadingProgress = asyncOperation.progress / 0.9f;

            fillingBar.fillAmount = Mathf.Min(loadingProgress, waitProgress);
        }

        asyncOperation.allowSceneActivation = true;
        yield return new WaitUntil( () => asyncOperation.isDone);

        fillingBar.fillAmount = 1f;
        loadingScreen.SetActive(false);
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
