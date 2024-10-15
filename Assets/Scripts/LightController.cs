using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject lightObject; 
    private GameSettings gameSettings; 

    private void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>(); 
        lightObject.SetActive(false); 
    }

    private void Update()
    {
        
        if (Input.GetDown(Input.Button.One)) 
        {
            ToggleLight();
        }
    }

    private void ToggleLight()
    {
        if (gameSettings.lightUses > 0) 
        {
            lightObject.SetActive(!lightObject.activeSelf); 

            if (lightObject.activeSelf) 
            {
                gameSettings.lightUses--;
            }
        }
    }
}