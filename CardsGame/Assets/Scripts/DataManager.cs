using UnityEngine;

/// <summary>
/// Manages and stores game data and settings between scenes.
/// </summary>
public class DataManager : MonoBehaviour
{
    /// <summary>
    /// Get and set the singleton instance of the DataManager.
    /// </summary>
    public static DataManager Instance { get; private set; }

    /// <summary>
    /// The player's nickname.
    /// </summary>
    public string nickName;

    /// <summary>
    /// The list of available difficulty levels.
    /// </summary>
    public DifficultyLevelsList difficultyLevelsList = null;

    /// <summary>
    /// The currently selected game difficulty level.
    /// </summary>
    public DifficultyLevel difficultyLevel = null;

    /// <summary>
    /// A flag indicating whether the player has won the game.
    /// </summary>
    public bool IsWin = false;

    /// <summary>
    /// Called on object initialization.
    /// Initializes the DataManager and ensures it persists between scenes.
    /// </summary>
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
