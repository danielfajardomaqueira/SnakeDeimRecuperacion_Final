using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Snake/Food")]
public class FoodScriptableObject : ScriptableObject
{

    public int points;
    public Sprite sprite;

    public GameObject floatingPoints;

}
