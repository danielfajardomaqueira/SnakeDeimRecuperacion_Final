using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI2 : MonoBehaviour
{
    public static PauseUI2 Instance { get; private set; }

    [SerializeField] private Button resumeButton_DifficultyMode;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Instance");
        }

        Instance = this;

        resumeButton_DifficultyMode.onClick.AddListener(() =>
        {
            GameManager2.Instance.ResumeGame();
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            Loader.Load(Loader.Scene.MainMenu);
        });

        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
