using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI debugText;

    [SerializeField]
    private Camera playerCam;

    private void Start()
    {
        
    }

    private void Update()
    {
        debugText.text = "Debug\n";
        debugText.text += $"Distance to stack: {PlayerController.Instance.DistanceToStack}\n";
        debugText.text += $"Player position: {playerCam.transform.position}\n";

    }
}
