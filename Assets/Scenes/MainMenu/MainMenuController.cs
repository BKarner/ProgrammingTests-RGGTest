using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : GenericUIController
{
    // Close the current game instance.
    public void CloseGame()
    {
        // Application.Quit() doesn't work in editor, only for built .exe's.
        Application.Quit();
    }
}
