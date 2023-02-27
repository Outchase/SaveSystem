using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

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
    [SerializeField] private GameObject continuePrompt;

    private InputOptions inputOptions;
    private bool pressToContinue;


    private Stack<string> sceneStack = new();

    private void Awake()
    {

        pressToContinue = false;
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
        inputOptions = new InputOptions();

        inputOptions.Menu.Enable();

        //inputOptions.Menu.Continue.started += Continue;
    }
    private void OnEnable()
    {
        inputOptions.Menu.Continue.started += Continue;
    }

    private void OnDisable()
    {
        inputOptions.Menu.Continue.started -= Continue;
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

        while (asyncOperation.progress < 0.9f || counter <= minLoadingDuration )
        {
            yield return null;
            counter += Time.unscaledDeltaTime;

            var waitProgress = counter / minLoadingDuration;
            var loadingProgress = asyncOperation.progress / 0.9f;

            fillingBar.fillAmount = Mathf.Min(loadingProgress, waitProgress);

        }

        continuePrompt.SetActive(true);

        asyncOperation.allowSceneActivation = true;

        yield return new WaitUntil(() => asyncOperation.isDone);

        fillingBar.fillAmount = 1f;

        yield return new WaitUntil(() => pressToContinue);
        pressToContinue = false;

        loadingScreen.SetActive(false);

    }

    /*public void UnloadScene(SceneIndices sceneIndex)
    {
        //SceneManager.UnloadSceneAsync()
    }*/

    public void UnloadCurrentScene()
    {
        SceneManager.UnloadSceneAsync(sceneStack.Pop());
    }

    public void Continue(InputAction.CallbackContext context)
    {
        pressToContinue = true;
    }
}
