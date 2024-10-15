using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty difficulty;

    [HideInInspector]
    public int lightUses;
    [HideInInspector]
    public float lightDuration;

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
    }

    public float GetLightDuration()
    {
        return lightDuration;
    }
}
