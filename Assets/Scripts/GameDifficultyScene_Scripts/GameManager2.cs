using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance { get; private set; }

    private LevelGrid2 levelGrid;
    private Snake2 snake;


    private bool isPaused;

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }

    private void Start()
    {
        SoundManager.CreateSoundManagerGameObject();

        // Configuración de la cabeza de serpiente
        GameObject snakeHeadGameObject = new GameObject("Snake Head");
        SpriteRenderer snakeSpriteRenderer = snakeHeadGameObject.AddComponent<SpriteRenderer>();
        snakeSpriteRenderer.sprite = GameAssets2.Instance.snakeHeadSprite;
        snake = snakeHeadGameObject.AddComponent<Snake2>();

        // Configurar el LevelGrid
        levelGrid = new LevelGrid2(20, 20);
        snake.Setup(levelGrid);
        levelGrid.Setup(snake);

        // Inicializo tema score
        Score.InitializeStaticScore();

        isPaused = false;
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     Loader.Load(Loader.Scene.Game);
        // }

        // Lógica de Pause con tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void SnakeDied()
    {
        GameOverUI2.Instance.Show(Score.TrySetNewHighScore());
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseUI2.Instance.Show();
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseUI2.Instance.Hide();
        isPaused = false;
    }
}
