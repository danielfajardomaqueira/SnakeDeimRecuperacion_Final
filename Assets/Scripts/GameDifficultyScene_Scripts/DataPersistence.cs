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
    /// Coloca la dificultad selecionada por el jugador
    /// </summary>
    /// <param name="difficulty">Guarda el valor de la velocidad selecionado</param>
    public void SetDifficulty(DifficultyMode.Modes difficulty)
    {
        this.difficulty = difficulty;
    }
    /// <summary>
    /// Obtiene el valor de dificultad selecionado
    /// </summary>
    /// <returns>devuelve el valor para que se la velocidad a la que se mueve la serpiente cuando inicie el juego</returns>
    public DifficultyMode.Modes GetDifficulty()
    {
        return difficulty;
    }
}
