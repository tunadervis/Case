using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPuzzle : MonoBehaviour
{
    public GameObject carObject; 
    private float timeSpentInTrigger = 0f;
    public float requiredTime = 5f; 

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            timeSpentInTrigger += Time.deltaTime;

            if (timeSpentInTrigger >= requiredTime)
            {
                carObject.SetActive(true); 
                Debug.Log("Car aktif edildi!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            timeSpentInTrigger = 0f;
        }
    }
}
