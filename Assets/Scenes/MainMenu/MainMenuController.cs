using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    /**
     * Open a scene from the menu with the given scene name.
     */
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /**
     * Close the current game instance.
     */
    public void CloseGame()
    {
        // Application.Quit() doesn't work in editor, only for built .exe's.
        Application.Quit();
    }
}
