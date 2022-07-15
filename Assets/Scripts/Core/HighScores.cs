using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScores
{
    public static List<HighScoreEntry> highScoreList;
    public static int maxScores = 10;

    /**
     * When we awake, load out high scores.
     */
    public static void Awake()
    {
        string listJSON = PlayerPrefs.GetString("highScoreTable");
        highScoreList = JsonUtility.FromJson<List<HighScoreEntry>>(listJSON);
    }

    /**
     * Save our high scores list off into the player prefs.
     */
    public static void Save()
    {
        // Turn our serializable list into a string so we can save it.
        string listJSON = JsonUtility.ToJson(highScoreList);
        PlayerPrefs.SetString("highScoreTable", listJSON);
        PlayerPrefs.Save();
    }

    /**
     * Reset our High Scores list.
     */
    public static void Reset()
    {
        // Create an empty string to become the high score table.
        string listJSON = "";
        PlayerPrefs.SetString("highScoreTable", listJSON);
        PlayerPrefs.Save();

        highScoreList = JsonUtility.FromJson<List<HighScoreEntry>>(listJSON);
    }

    /**
     * Add an entry to our high scores.
     */
    public static void AddEntry(int score)
    {
        HighScoreEntry newEntry = new HighScoreEntry { score = score };

        for (int i = 0; i < highScoreList.Count; ++i)
        {
            HighScoreEntry entry = highScoreList[i];

            // We don't want to do anything in this comparison if the score is less.
            if (newEntry.score < entry.score) { 
                continue;
            } else {
                // Must at this point be more than or equal to another score.
                highScoreList.Insert(i, entry);
                
                // Remove our lowest score.
                if (highScoreList.Count > maxScores)
                {
                    highScoreList.RemoveAt(maxScores);
                }

                Save();
                return;
            }
        }

        // Insert anyway if room.
        if (highScoreList.Count < maxScores)
        {
            highScoreList.Add(newEntry);
            Save();
        }
    }
}

/**
 * Create an entry for the high score. Struct it, for the event of further expansion. (Names etc).
 */
public struct HighScoreEntry
{
    public int score;
}