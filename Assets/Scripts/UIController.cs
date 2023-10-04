using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI distanceText;

    [SerializeField]
    private TextMeshProUGUI forceText;
 
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateDistanceText();
        UpdateForceText();
    }

    private void UpdateDistanceText()
    {
        distanceText.text = $"Distance: {PlayerController.Instance.DistanceToStack.ToString("F2")} m";
    }
    private void UpdateForceText()
    {
        forceText.text = $"Force: {(int)PlayerController.Instance.Force} N";
    }
}
