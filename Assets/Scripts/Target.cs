using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float lifeTime = 2f;
    private GameManager gameManager;

    public int points;
    public ParticleSystem explosionParticles;

    void Start()
    {
        Destroy(gameObject, lifeTime);
        gameManager = FindObjectOfType<GameManager>();
        lifeTime = gameManager.spawnRate;
    }

    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (!gameManager.isGameOver)
        {
            gameManager.UpdateScore(points);
            Instantiate(explosionParticles, transform.position, transform.rotation);

            Destroy(gameObject);
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
        }
        
    }
    private void OnDestroy()
    {
        gameManager.targetPosition.Remove(transform.position);
    }
}
