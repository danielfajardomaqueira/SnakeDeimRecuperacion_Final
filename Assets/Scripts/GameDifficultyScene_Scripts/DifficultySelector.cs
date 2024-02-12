using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    private Snake2 snake;


    public void SetDifficultyEasy()
    {

        DataPersistence.Instance.SetDifficulty(DifficultyMode.Modes.Easy);
        //SceneManager.LoadScene(0);
    }

    public void SetDifficultyMedium()
    {
        DataPersistence.Instance.SetDifficulty(DifficultyMode.Modes.Medium);
        //SceneManager.LoadScene(0);
    }

    public void SetDifficultyHard()
    {
        DataPersistence.Instance.SetDifficulty(DifficultyMode.Modes.Hard);
        //SceneManager.LoadScene(0);
    }

}
