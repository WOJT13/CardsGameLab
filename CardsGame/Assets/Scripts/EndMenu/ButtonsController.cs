using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls UI button interactions and actions in the end menu.
/// </summary>
public class ButtonsController : MonoBehaviour
{
    /// <summary>
    /// Called when the "Play Again" button is clicked.
    /// Goes back to main menu
    /// </summary>
    public void onPlayAgainButtonClick()
    {
        DataManager.Instance.difficultyLevel = null;
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Called when the "Quit" button is clicked.
    /// Quits the application.
    /// </summary>
    public void onQuitButtonClick()
    {
        Application.Quit();
    }
}
