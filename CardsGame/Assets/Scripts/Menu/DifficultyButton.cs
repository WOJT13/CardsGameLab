using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Represents a UI button for selecting a game difficulty level.
/// </summary>
public class DifficultyButton : MonoBehaviour
{
    /// <summary>
    /// The GameObject that serves as the difficulty button.
    /// </summary>
    public GameObject button;

    /// <summary>
    /// Called when the difficulty button is clicked.
    /// Sets the current game's difficulty level based on the button's text.
    /// </summary>
    public void OnDifficultyButtonClick()
    {
        DataManager.Instance.difficultyLevel = DataManager.Instance.difficultyLevelsList.GetByName(button.GetComponentInChildren<TMP_Text>().text);
    }
}
