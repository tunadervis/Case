using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameSettings))]
public class GameSettingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameSettings gameSettings = (GameSettings)target;

        
        gameSettings.difficulty = (GameSettings.Difficulty)EditorGUILayout.EnumPopup("Difficulty", gameSettings.difficulty);

        
        if (GUILayout.Button("Set Difficulty"))
        {
            gameSettings.SetDifficulty();
        }

        
        EditorGUILayout.LabelField("Light Uses: " + gameSettings.lightUses);
        EditorGUILayout.LabelField("Light Duration: " + gameSettings.lightDuration + " seconds");

        
        if (GUI.changed)
        {
            EditorUtility.SetDirty(gameSettings);
        }
    }
}