using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public int difficulty;
    private Button button;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        gameManager = FindObjectOfType<GameManager>();
        
    }

    public void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
