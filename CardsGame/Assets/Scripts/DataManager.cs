using UnityEngine;

/// <summary>
/// Class to manage data
/// </summary>
public class DataManager : MonoBehaviour
{
    /// <summary>
    /// Get and set instance of data manager
    /// </summary>
    public static DataManager Instance { get; private set; }
    
    public string nickName;
    public DifficultyLevelsList difficultyLevelsList = null;
    public DifficultyLevel difficultyLevel = null;
    public bool IsWin = false;


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
