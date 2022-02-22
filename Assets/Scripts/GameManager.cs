using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceJump = 2.5f;

    public bool isGameOver;
    public List<Vector3> targetPosition;
    private float spawnRate = 1f;
    private Vector3 randomPos;

    public TextMeshProUGUI scoreText;
    public int score = 0;
    public GameObject gameOverPanel;

    void Start()
    {
        scoreText.text = $"Score: {score}";
        gameOverPanel.SetActive(false);
        StartCoroutine(SpawnRandomTarget());
        Time.timeScale = 1f;
    }

    private Vector3 RandomSpawnPos()
    {
        int saltosX = Random.Range(0, 4);
        int saltosY = Random.Range(0, 4);

        float spawnPosX = minX + saltosX * distanceJump;
        float spawnPosY = minY + saltosY * distanceJump;

        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomPos = RandomSpawnPos();
            while (targetPosition.Contains(randomPos))
            {
                randomPos = RandomSpawnPos();
            }
            Instantiate(targetPrefabs[randomIndex], randomPos, targetPrefabs[randomIndex].transform.rotation);
            targetPosition.Add(randomPos);
        }
    }

    public void UpdateScore(int addPoints)
    {
        score += addPoints;
        scoreText.text = $"Score: {score}";
        if (score >= 50 || score >= 100 || score >= 250 || score >= 500)
        {
            Time.timeScale += 0.05f;
        }
    }
    public void GameOver()
    {
        isGameOver = true;  
        gameOverPanel.SetActive(true);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
}
