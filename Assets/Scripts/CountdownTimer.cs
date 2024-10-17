using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float timeRemaining;
    private bool isGameOver = false;
    private GameSettings gameSettings;

    public GameObject monsterPrefab;
    public Transform player;
    public Animator monsterAnimator;
    public float attackDistance = 1f;

    private void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
        SetInitialTime();
        StartCoroutine(StartCountdown());
    }

    private void SetInitialTime()
    {
        switch (gameSettings.difficulty)
        {
            case GameSettings.Difficulty.Easy:
                timeRemaining = 15 * 60f;
                break;
            case GameSettings.Difficulty.Medium:
                timeRemaining = 10 * 60f;
                break;
            case GameSettings.Difficulty.Hard:
                timeRemaining = 7 * 60f;
                break;
        }
    }

    private IEnumerator StartCountdown()
    {
        while (timeRemaining > 0 && !isGameOver)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
            yield return null;
        }

        if (timeRemaining <= 0 && !isGameOver)
        {
            GameOver();
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        isGameOver = true;
        

        SpawnMonster();
        StartCoroutine(MonsterChasePlayer());
    }

    private void SpawnMonster()
    {
        monsterPrefab.SetActive(true); 
    }

    private IEnumerator MonsterChasePlayer()
    {
        while (!isGameOver)
        {
            Vector3 direction = (player.position - monsterPrefab.transform.position).normalized;
            monsterPrefab.transform.position += direction * Time.deltaTime * 3f;

            float distanceToPlayer = Vector3.Distance(monsterPrefab.transform.position, player.position);

            if (distanceToPlayer <= attackDistance)
            {
                monsterAnimator.SetTrigger("Attack");

                yield return new WaitForEndOfFrame();
                AnimatorStateInfo animInfo = monsterAnimator.GetCurrentAnimatorStateInfo(0);

                
                while (animInfo.IsName("Attack") && animInfo.normalizedTime < 1.0f)
                {
                    yield return null;
                    animInfo = monsterAnimator.GetCurrentAnimatorStateInfo(0); 
                }

                Debug.Log("Süre bitti! Oyunu kaybettin.");
                Application.Quit();
                yield break;
            }
            Debug.Log("Süre bitti! Oyunu kaybettin22.");
            yield return null;
        }
    }
}