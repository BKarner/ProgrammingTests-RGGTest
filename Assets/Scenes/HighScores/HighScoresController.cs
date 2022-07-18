using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HighScoresController : GenericUIController
{
    /**
     * The parent table to add our generated table entries to.
     */
    public GameObject scoreTableParent;

    /**
     * The template entry for our generated table entries.
     */
    public Canvas scoreTemplate;

    /**
     * Cached references to our generated table entries.
     */
    private List<Canvas> createdCanvases = new List<Canvas>();

    /**
     * Cached references to our generated score texts.
     */
    private List<Text> createdScores = new List<Text>();

    /**
     * Called when the controller is loaded into the scene.
     */
    public void Start()
    {
        base.Start();
        LoadScores();
    }

    /**
     * Go through each of the score entries and delete them.
     */
    public void LoadScores()
    {
        int considered = 0;
        float templateHeight = scoreTemplate.GetComponent<RectTransform>().rect.height;

        // Go through our high scores and correctly update the table.
        for (int i = considered; i < HighScores.highScoreList.Count; ++i)
        {
            Text currentScore;

            // If our canvas doesnt exist for this, create a new one and align it.
            if (i < createdCanvases.Count) {
                currentScore = createdScores[i];
            } 
            else
            {
                // Create a new canvas with a position and score text.
                Canvas currentCanvas = GameObject.Instantiate(scoreTemplate, scoreTableParent.transform);
                currentCanvas.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -templateHeight * (i + 1));

                // Update our position text. We only need to do this i
                Text position = currentCanvas.gameObject.transform.Find("Position").GetComponent<Text>();
                position.text = ("#" + (i + 1));

                // Grab our score.
                currentScore = currentCanvas.gameObject.transform.Find("Score").GetComponent<Text>();


                // Cache both our score and our canvases for the future.
                createdScores.Add(currentScore);
                createdCanvases.Add(currentCanvas);
            }

            // Update our Score value.
            currentScore.text = HighScores.highScoreList[i].score.ToString();

            considered++;
        }

        // Go through the remaining existing canvases and make them inactive.
        for (int i = considered; i < createdCanvases.Count; ++i)
        {
            Canvas existingCanvas = createdCanvases[i];
            existingCanvas.enabled = false;
        }
    }

    /**
     * Reset our static high scores.
     */
    public void ResetScores()
    {
        HighScores.Reset();
        LoadScores();
    }
}
