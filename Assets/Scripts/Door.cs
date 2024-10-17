using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    public XRSocketInteractor socket; 
    public GameObject door; 
    public float openSpeed = 2f; 
    public float openHeight = 5f; 
    private bool isOpen = false; 
    private Vector3 initialPosition;
    private PuzzleManager puzzle;

    void Start()
    {
        puzzle = FindObjectOfType<PuzzleManager>();

        socket.selectEntered.AddListener(OnObjectPlaced);

        
        initialPosition = door.transform.position;
    }

    void OnObjectPlaced(SelectEnterEventArgs args)
    {
        
        if (!isOpen)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        isOpen = true;

        Vector3 targetPosition = initialPosition + new Vector3(0, openHeight, 0); 

        float elapsedTime = 0;
        while (elapsedTime < 1f)
        {
            door.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime * openSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        puzzle.CompletePuzzle();




        door.transform.position = targetPosition;
    }
}
