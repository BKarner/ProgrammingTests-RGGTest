using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenuController : MonoBehaviour
{
    public void Start()
    {
        GenerateScores(5, 0, 100);
    }

    public void GenerateScores(int count, int minScore, int maxScore)
    {
        for (int i = 0; i < count; ++i)
        {
            int score = ~~Random.Range(minScore, maxScore);
            HighScores.AddEntry(score);
        }
    }

    public void ResetGame()
    {
        // Reload our scene.
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
