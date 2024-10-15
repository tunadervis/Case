using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 1f;
    public float detectionDistance = 10f;
    public float attackDistance = 0.5f;
    public AudioClip screamSound;
    private AudioSource audioSource;
    private bool isMoving = true; 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        Debug.Log("Distance to Player: " + distanceToPlayer);

        
        if (IsPlayerLookingAtMonster())
        {
            isMoving = false; 
        }
        else
        {
            isMoving = true;
        }

        if (isMoving && distanceToPlayer < detectionDistance)
        {
            Vector3 moveDirection = directionToPlayer.normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        if (distanceToPlayer < attackDistance)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(screamSound);
            }
            LoseGame();
        }
    }

    private bool IsPlayerLookingAtMonster()
    {
        
        Vector3 playerForward = player.forward;
        
        Vector3 directionToMonster = (transform.position - player.position).normalized;

        
        float angle = Vector3.Angle(playerForward, directionToMonster);

        
        return angle < 45f;
    }

    private void LoseGame()
    {
        
        // SceneManager.LoadScene("LoseScene");
        Debug.Log("Kaybettin!");
    }
}