using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    private int score;
    private void Start()
    {
        Coin.OnScore += OnScoreAdd;
    }
    public void ShowScore(TextMeshProUGUI scoreText)
    {
        scoreText.text = $"Score = {score}";
    }
    private void OnScoreAdd()
    {
        score++;
    }
}
