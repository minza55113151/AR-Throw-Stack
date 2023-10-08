using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI distanceText;

    [SerializeField]
    private TextMeshProUGUI forceText;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI angleText;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateDistanceText();
        UpdateForceText();
        UpdateScoreText();
        UpdateAngleText();
    }

    private void UpdateDistanceText()
    {
        distanceText.text = $"Distance: {PlayerController.Instance.DistanceToStack.ToString("F2")} m";
    }
    private void UpdateForceText()
    {
        forceText.text = $"Force: {(int)PlayerController.Instance.Force} N";
    }
    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {StackController.Instance.Score}";
    }
    private void UpdateAngleText()
    {
        angleText.text = $"Angle: {PlayerController.Instance.Angle.ToString("F0")} deg";
    }
}
