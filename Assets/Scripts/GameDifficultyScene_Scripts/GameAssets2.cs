using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameAssets2 : MonoBehaviour
{

    public static GameAssets2 Instance { get; private set; }

    public Sprite snakeHeadSprite;
    public Sprite snakeBodySprite;
    public Sprite foodSprite;

    public Sprite powerUpShield;

    

    

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }
}
