using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore()
    {
        var score = StackController.Instance.Score;
        var highScore = PlayerPrefs.GetInt(PlayerPrefsKeys.highScore, 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.highScore, score);
        }
    }
}
