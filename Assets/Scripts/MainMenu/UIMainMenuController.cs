using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMainMenuController : MonoBehaviour
{
    #region struct
    [System.Serializable]
    struct Menu
    {
        public MenuName name;
        public RectTransform rectTransform;
    }

    enum MenuName {
        MainMenu,
        Settings,
        HowToPlay,
        WarningPlay
    }
    #endregion

    public static UIMainMenuController Instance { get; private set; }
 
    
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button settingsButton;

    [SerializeField]
    private Button howToPlayButton; 
    
    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private Button realPlayButton;

    [SerializeField]
    private List<Menu> menus = new List<Menu>();


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        howToPlayButton.onClick.AddListener(OnHowToPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        realPlayButton.onClick.AddListener(OnRealPlayButtonClicked);

        OpenMenu(MenuName.MainMenu);
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
        howToPlayButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        realPlayButton.onClick.RemoveAllListeners();
    }

    #region OnClicked
    private void OnPlayButtonClicked()
    {
        OpenMenu(MenuName.WarningPlay);
    }

    private void OnSettingsButtonClicked()
    {
        OpenMenu(MenuName.Settings);
    }

    private void OnHowToPlayButtonClicked()
    {
        OpenMenu(MenuName.HowToPlay);
    }

    private void OnExitButtonClicked()
    {
        GameController.Instance.ExitGame();
    }

    public void OnBackButtonClicked()
    {
        OpenMenu(MenuName.MainMenu);
    }

    private void OnRealPlayButtonClicked()
    {
        GameController.Instance.GoPlayGame();
    }
    #endregion

    private void OpenMenu(MenuName menuName)
    {
        foreach (var menu in menus)
        {
            if (menu.name == menuName)
            {
                menu.rectTransform.gameObject.SetActive(true);
            }
            else
            {
                menu.rectTransform.gameObject.SetActive(false);
            }
        }
    }
}
