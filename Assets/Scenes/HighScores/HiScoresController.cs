using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HiScoresController : MonoBehaviour
{
    public GameObject scoreTableParent;
    public Canvas scoreTemplate;

    private List<Canvas> createdScores;

    public void Start()
    {
        LoadScores();
    }

    /**
     * Go through each of the score entries and delete them.
     */
    public void LoadScores()
    {
        if (HighScores.highScoreList == null)
        {
            return;
        }

        int considered = 0;
        for (int i = considered; i < HighScores.highScoreList.Count; ++i)
        {
            Canvas existingCanvas = createdScores[i];

            // If our canvas doesnt exist for this, create a new one and align it.
            if (!existingCanvas) {
                existingCanvas = GameObject.Instantiate(scoreTemplate);
                existingCanvas.transform.Translate(new Vector3(0.0f, scoreTemplate.pixelRect.height));

                // Update our position text.
                Text position = existingCanvas.gameObject.transform.Find("Position").GetComponent<Text>();
                position.text = ("#" + (i + 1));
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
