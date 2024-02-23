using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameAssets2 : MonoBehaviour
{
    [Serializable]

    public class SoundAudioClip2
    {
        public SoundManager2.Sound sound2;
        public AudioClip audioClip;
    }

    public static GameAssets2 Instance { get; private set; }

    public Sprite snakeHeadSprite;
    public Sprite snakeBodySprite;
    public Sprite foodSprite;

    public Sprite powerUpShield;

    public SoundAudioClip2[] soundAudioClipsArray;


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
