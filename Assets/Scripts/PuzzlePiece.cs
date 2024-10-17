using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzlePiece : MonoBehaviour
{
    public Transform correctSocket; 
    private Vector3 originalPosition; 
    private Quaternion originalRotation; 

    private void Start()
    {
        
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform == correctSocket)
        {
            
            transform.position = correctSocket.position;
            transform.rotation = correctSocket.rotation;
        }
        else
        {
            
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
    }
}