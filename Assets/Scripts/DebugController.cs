using TMPro;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI debugText;

    [SerializeField]
    private Camera playerCam;

    private bool isShowDebugUI;

    private void Start()
    {
        isShowDebugUI = PlayerPrefs.GetInt(PlayerPrefsKeys.showDebugUI, 0) == 1;
        if (!isShowDebugUI)
        {
            debugText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(!isShowDebugUI)
        {
            return;
        }

        debugText.text = "Debug\n";
        debugText.text += $"Distance to stack: {PlayerController.Instance.DistanceToStack}\n";
        debugText.text += $"Player position: {playerCam.transform.position}\n";
    }
}
