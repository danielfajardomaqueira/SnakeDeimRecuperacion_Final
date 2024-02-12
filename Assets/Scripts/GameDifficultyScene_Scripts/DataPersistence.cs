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

    public void SetDifficulty(DifficultyMode.Modes difficulty)
    {
        this.difficulty = difficulty;
    }

    public DifficultyMode.Modes GetDifficulty()
    {
        return difficulty;
    }
}
