using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HighScoresController : MonoBehaviour
{
    public GameObject scoreTableParent;
    public Canvas scoreTemplate;

    private List<Canvas> createdScores = new List<Canvas>();

    public void Start()
    {
        LoadScores();
    }

    /**
     * Go through each of the score entries and delete them.
     */
    public void LoadScores()
    {
        int considered = 0;
        float templateHeight = scoreTemplate.GetComponent<RectTransform>().rect.height;

        for (int i = considered; i < HighScores.highScoreList.Count; ++i)
        {
            Canvas existingCanvas;

            // If our canvas doesnt exist for this, create a new one and align it.
            if (i < createdScores.Count) {
                existingCanvas = createdScores[i];
            } 
            else
            {
                existingCanvas = GameObject.Instantiate(scoreTemplate, scoreTableParent.transform);
                existingCanvas.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -templateHeight * (i + 1));

                // Update our position text.
                Text position = existingCanvas.gameObject.transform.Find("Position").GetComponent<Text>();
                position.text = ("#" + (i + 1));

                createdScores.Add(existingCanvas);
            }

            // Update our Score value.
            Text score = existingCanvas.gameObject.transform.Find("Score").GetComponent<Text>();
            score.text = HighScores.highScoreList[i].score.ToString();

            considered++;
        }

        // Go through the remaining existing canvases and make them inactive.
        for (int i = considered; i < createdScores.Count; ++i)
        {
            Canvas existingCanvas = createdScores[i];
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

    /**
     * Open a scene with the given name.
     */
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
