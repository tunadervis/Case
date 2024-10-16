using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class VRSceneTransition : MonoBehaviour
{
    public string sceneName = "MidnightEscape"; 

    private void Start()
    {
        
        GetComponent<XRBaseInteractable>().selectEntered.AddListener(OnButtonPressed);
    }

    
    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        SceneManager.LoadScene(sceneName); 
    }

    private void OnDestroy()
    {
        
        GetComponent<XRBaseInteractable>().selectEntered.RemoveListener(OnButtonPressed);
    }
}