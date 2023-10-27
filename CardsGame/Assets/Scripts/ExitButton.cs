using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to quit the game
/// </summary>
public class ExitButton : MonoBehaviour
{
    /// <summary>
    /// Method handles click operation
    /// </summary>
    public void ExitClick()
    {
        Application.Quit();
    }
}
