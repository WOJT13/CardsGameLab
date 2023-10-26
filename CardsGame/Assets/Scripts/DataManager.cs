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

    /// <summary>
    /// Card object
    /// </summary>
    public Card card = null;
    /// <summary>
    /// List of cards object
    /// </summary>
    public CardsList cardList = null;


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
