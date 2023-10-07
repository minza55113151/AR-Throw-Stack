using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField]
    private string gameplaySceneName;

    [SerializeField]
    private string mainMenuSceneName;

    public event Action OnRestartGame;

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
        SceneManager.LoadScene(mainMenuSceneName);
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
