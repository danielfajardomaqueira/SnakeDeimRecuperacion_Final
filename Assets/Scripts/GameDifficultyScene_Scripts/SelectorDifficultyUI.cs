using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorDifficultyUI : MonoBehaviour
{
    [SerializeField] private Button easy;
    [SerializeField] private Button medium;
    [SerializeField] private Button hard;

    private void Awake()
    {
        easy.onClick.AddListener(() => { Loader.Load(Loader.Scene.Game_Difficulty); });
        medium.onClick.AddListener(() => { Loader.Load(Loader.Scene.Game_Difficulty); });
        hard.onClick.AddListener(() => { Loader.Load(Loader.Scene.Game_Difficulty); });
    }
}
