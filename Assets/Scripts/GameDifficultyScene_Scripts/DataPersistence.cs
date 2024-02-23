using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance { get; private set; }
    private DifficultyMode.Modes difficulty;


    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }
    /// <summary>
    /// Set the difficulty selected by the player
    /// </summary>
    /// <param name="difficulty">Save the selected speed value</param>
    public void SetDifficulty(DifficultyMode.Modes difficulty)
    {
        this.difficulty = difficulty;
    }
    /// <summary>
    /// Gets the selected difficulty value
    /// </summary>
    /// <returns>returns the value to be the speed at which the snake moves when the game starts</returns>
    public DifficultyMode.Modes GetDifficulty()
    {
        return difficulty;
    }
}
