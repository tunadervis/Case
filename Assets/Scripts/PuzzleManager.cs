using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzles; 
    private int currentPuzzleIndex = 0; 

    private void Start()
    {
        
        foreach (GameObject puzzle in puzzles)
        {
            puzzle.SetActive(false);
        }

        
        ActivatePuzzle(currentPuzzleIndex);
    }

    public void CompletePuzzle()
    {
        
        if (currentPuzzleIndex < puzzles.Length)
        {
            currentPuzzleIndex++; 

            
            if (currentPuzzleIndex < puzzles.Length)
            {
                ActivatePuzzle(currentPuzzleIndex);
            }
        }
    }

    private void ActivatePuzzle(int index)
    {
        if (index < puzzles.Length)
        {
            puzzles[index].SetActive(true);
        }
    }
}
