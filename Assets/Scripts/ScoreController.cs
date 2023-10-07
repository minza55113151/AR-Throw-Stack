using System.Collections;
using System.Collections.Generic;
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
        var highScore = PlayerPrefs.GetInt(PlayerPrefsKeys.HighScore, 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.HighScore, score);
        }
    }
}
