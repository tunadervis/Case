using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty difficulty;

    [HideInInspector]
    public int lightUses;
    [HideInInspector]
    public float lightDuration;

    public static event Action OnDifficultyChanged; 

    public void SetDifficulty()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                lightUses = 10;
                lightDuration = 10f;
                break;
            case Difficulty.Medium:
                lightUses = 7;
                lightDuration = 7f;
                break;
            case Difficulty.Hard:
                lightUses = 5;
                lightDuration = 5f;
                break;
        }

        
        OnDifficultyChanged?.Invoke();
    }

    public float GetLightDuration()
    {
        return lightDuration;
    }
}
