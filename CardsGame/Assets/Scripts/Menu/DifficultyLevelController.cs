using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Controls the display and interaction with difficulty level buttons in the game.
/// </summary>
public class DifficultyLevelController : MonoBehaviour
{
    /// <summary>
    /// The prefab used for creating difficulty level buttons.
    /// </summary>
    public GameObject buttonPrefab;

    /// <summary>
    /// The container where the difficulty level buttons are placed.
    /// </summary>
    public Transform buttonContainer;

    /// <summary>
    /// Called when the script is initialized.
    /// Creates and populates difficulty level buttons.
    /// </summary>
    void Start()
    {
        CreateDifficultyButtons();
    }

    /// <summary>
    /// Create and display difficulty level buttons.
    /// </summary>
    void CreateDifficultyButtons()
    {
        foreach (var level in DataManager.Instance.difficultyLevelsList.GetAll())
        {
            // Create a button
            GameObject button = Instantiate(buttonPrefab, buttonContainer);
            button.GetComponentInChildren<TMP_Text>().text = level.name;
            button.GetComponentInChildren<Image>().sprite = level.icon;
        }
    }
}
