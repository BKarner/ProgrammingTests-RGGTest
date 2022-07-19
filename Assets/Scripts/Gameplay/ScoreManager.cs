using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int currentScore;

    // Start is called before the first frame update
    public void Start()
    {
        // Set our score to 0 initially.
        UpdateScore(0);
    }

    // Update our score at the top part of the screen.
    public void UpdateScore(int value)
    {
        currentScore = value;
        scoreText.text = "Score: " + value;
    }

    // Finalise our score and try add it to the High Scores.
    public void FinishScore()
    {
        HighScores.AddEntry(currentScore);
    }
}
