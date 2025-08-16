using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI winnerText; 

    private int player1Score = 0;
    private int player2Score = 0;

    public bool gameOver = false; 

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int player)
    {
        if (gameOver) return; 

        if (player == 1)
            player1Score++;
        else
            player2Score++;

        UpdateScoreUI();
        CheckWinner();
    }

    void UpdateScoreUI()
    {
        player1ScoreText.text = "Player 1: " + player1Score;
        player2ScoreText.text = "Player 2: " + player2Score;
    }

    void CheckWinner()
    {
        if (player1Score >= 10)
        {
            gameOver = true;
            winnerText.text = "Player 1 Wins!";
        }
        else if (player2Score >= 10)
        {
            gameOver = true;
            winnerText.text = "Player 2 Wins!";
        }

        if (gameOver)
        {
           
            winnerText.gameObject.SetActive(true);

           
            Movement[] players = FindObjectsOfType<Movement>();
            foreach (Movement p in players)
            {
                p.enabled = false;
            }
        }
    }
}