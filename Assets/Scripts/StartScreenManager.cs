using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour
{
    public TMP_Text difficultyInfoText;
    private GameSettings gameSettings;
    public Dropdown difficultyDropdown;

    private void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();

        
        difficultyDropdown.options.Clear();
        difficultyDropdown.options.Add(new Dropdown.OptionData("Easy"));
        difficultyDropdown.options.Add(new Dropdown.OptionData("Medium"));
        difficultyDropdown.options.Add(new Dropdown.OptionData("Hard"));

        
        difficultyDropdown.onValueChanged.AddListener(delegate { OnDifficultyChanged(); });

        
        UpdateDifficultyInfo();
    }

    public void OnDifficultyChanged()
    {
       
        switch (difficultyDropdown.value)
        {
            case 0:
                gameSettings.difficulty = GameSettings.Difficulty.Easy;
                break;
            case 1:
                gameSettings.difficulty = GameSettings.Difficulty.Medium;
                break;
            case 2:
                gameSettings.difficulty = GameSettings.Difficulty.Hard;
                break;
        }

        
        gameSettings.SetDifficulty();

        
        UpdateDifficultyInfo();
    }

    public void UpdateDifficultyInfo()
    {
        
        string info = "";
        switch (gameSettings.difficulty)
        {
            case GameSettings.Difficulty.Easy:
                info = "Easy Mode: 10 Light Uses, 10 Seconds per Light Use, 15 minutes to escape!";
                break;
            case GameSettings.Difficulty.Medium:
                info = "Medium Mode: 7 Light Uses, 7 Seconds per Light Use, 10 minutes to escape!";
                break;
            case GameSettings.Difficulty.Hard:
                info = "Hard Mode: 5 Light Uses, 5 Seconds per Light Use, 7 minutes to escape!";
                break;
        }
        difficultyInfoText.text = info; 
    }
}