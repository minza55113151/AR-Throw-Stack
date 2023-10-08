using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField]
    private string gameplaySceneName;

    [SerializeField]
    private string mainMenuSceneName;

    public event Action OnRestartGame;

    public bool isInMainMenu => SceneManager.GetActiveScene().name == mainMenuSceneName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
    }

    private void Start()
    {

    }

    public void GoPlayGame()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }

    public void GoMainmenu()
    {
        LoaderUtility.Deinitialize();
        LoaderUtility.Initialize();
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void GameOver()
    {
        UIGameOverPopupController.Instance.Open();
    }

    public void RestartGame()
    {
        OnRestartGame?.Invoke(); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
