using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuPopupController : MonoBehaviour
{
    [SerializeField]
    private Button openMenuButton;

    [SerializeField]
    private Button bgButton;

    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private Button restartButton;

    [SerializeField]
    private Button playButton;

    [SerializeField]
    private GameObject menuPopupContainer;

    private void Start()
    {
        openMenuButton.onClick.AddListener(Open);
        bgButton.onClick.AddListener(Close);
        mainMenuButton.onClick.AddListener(GameController.Instance.GoMainmenu);
        restartButton.onClick.AddListener(GameController.Instance.GoPlayGame);
        playButton.onClick.AddListener(Close);

        Close();
    }

    private void OnDestroy()
    {
        openMenuButton.onClick.RemoveListener(Open);
        bgButton.onClick.RemoveListener(Close);
        mainMenuButton.onClick.RemoveListener(GameController.Instance.GoMainmenu);
        restartButton.onClick.RemoveListener(GameController.Instance.GoPlayGame);
        playButton.onClick.RemoveListener(Close);
    }

    private void Open() => menuPopupContainer.SetActive(true);

    private void Close() => menuPopupContainer.SetActive(false);
}
