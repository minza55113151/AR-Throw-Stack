using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenuController : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button settingsButton;

    [SerializeField]
    private Button howToPlayButton; 
    
    [SerializeField]
    private Button exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        howToPlayButton.onClick.AddListener(OnHowToPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
        howToPlayButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }

    private void OnPlayButtonClicked()
    {

    }

    private void OnSettingsButtonClicked()
    {

    }

    private void OnHowToPlayButtonClicked()
    {

    }

    private void OnExitButtonClicked()
    {

    }
}
