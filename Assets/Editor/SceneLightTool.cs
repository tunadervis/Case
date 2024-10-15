using UnityEditor;
using UnityEngine;

public class SceneLightTool : EditorWindow
{
    private int lightCount = 1; 
    private Color lightColor = Color.white; 
    private float lightIntensity = 1f; 

    [MenuItem("Tools/Scene Light Tool")]
    public static void ShowWindow()
    {
        GetWindow<SceneLightTool>("Scene Light Tool");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create Lights", EditorStyles.boldLabel);

        lightCount = EditorGUILayout.IntField("Number of Lights", lightCount);
        lightColor = EditorGUILayout.ColorField("Light Color", lightColor);
        lightIntensity = EditorGUILayout.FloatField("Light Intensity", lightIntensity);

        if (GUILayout.Button("Create Lights"))
        {
            CreateLights();
        }
    }

    private void CreateLights()
    {
        for (int i = 0; i < lightCount; i++)
        {
            GameObject lightObject = new GameObject("Light " + (i + 1));
            Light light = lightObject.AddComponent<Light>();
            light.color = lightColor;
            light.intensity = lightIntensity;
            light.type = LightType.Point; 
            lightObject.transform.position = new Vector3(i * 2, 1, 0); 
        }
    }
}