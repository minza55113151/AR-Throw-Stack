using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverPopupController : MonoBehaviour
{
    public static UIGameOverPopupController Instance { get; private set; }

    [SerializeField]
    private Button bgButton;

    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private Button restartButton;

    [SerializeField]
    private GameObject gameOverPopupContainer;

    [SerializeField]
    private TextMeshProUGUI yourScoreText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        bgButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(GameController.Instance.GoMainmenu);
        restartButton.onClick.AddListener(RestartGame);

        Close();
    }

    private void OnDestroy()
    {
        bgButton.onClick.RemoveListener(RestartGame);
        mainMenuButton.onClick.RemoveListener(GameController.Instance.GoMainmenu);
        restartButton.onClick.RemoveListener(RestartGame);
    }

    private void RestartGame()
    {
        GameController.Instance.RestartGame();
        Close();
    }

    public void Open()
    {
        yourScoreText.text = $"Your score: {StackController.Instance.Score}";
        highScoreText.text = $"High score: {PlayerPrefs.GetInt(PlayerPrefsKeys.highScore)}";

        gameOverPopupContainer.SetActive(true);
    }

    private void Close() => gameOverPopupContainer.SetActive(false);
}
