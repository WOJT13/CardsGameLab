using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardController : MonoBehaviour
{
    /// <summary>
    /// Get and set instance of data manager
    /// </summary>
    public static GameBoardController Instance { get; private set; }
        /// <summary>
    /// Card object
    /// </summary>
    public Card card = null;
    /// <summary>
    /// List of cards object
    /// </summary>
    public CardsList cardList = null;

    /// <summary>
    /// List of coordinates
    /// </summary>
    public CoordinatesList coordinatesList = new CoordinatesList();


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }
}
