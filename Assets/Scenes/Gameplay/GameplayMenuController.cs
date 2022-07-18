using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenuController : GenericUIController
{
    /**
     * Generic "Start".
     * 
     * TODO: Remove this method implementation once we have a gameplay controller.
     */
    public void Start()
    {
        base.Start();
        GenerateScores(5, 0, 100);
    }

    /**
     * Generate a given number of scores between the minimum and maximum score.
     * 
     * TODO: Remove this once we're fully happy with the high scores.
     */
    public void GenerateScores(int count, int minScore, int maxScore)
    {
        for (int i = 0; i < count; ++i)
        {
            // Generate our random number.
            int score = Random.Range(minScore, maxScore);

            // Try to add our current score to the high scores sheet.
            HighScores.AddEntry(score);
        }
    }

    /**
     * Reset the level by re-opening the scene.
     */
    public void ResetGame()
    {
        // Reload our scene.
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
