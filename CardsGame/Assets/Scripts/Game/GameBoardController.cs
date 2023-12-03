using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the game board and related data and actions.
/// </summary>
public class GameBoardController : MonoBehaviour
{
    /// <summary>
    /// Get and set the singleton instance of the GameBoardController.
    /// </summary>
    public static GameBoardController Instance { get; private set; }

    /// <summary>
    /// Reference to a single card object.
    /// </summary>
    public Card card = null;

    /// <summary>
    /// Reference to a list of card objects.
    /// </summary>
    public CardsList cardList = null;

    /// <summary>
    /// List of coordinates representing the game board's layout.
    /// </summary>
    public CoordinatesList coordinatesList = new CoordinatesList();

    /// <summary>
    /// List of neighor coordinates of building models
    /// </summary>
    public CoordinatesList neigbborList = new CoordinatesList();
    
    /// <summary>
    /// Flag indicating whether the player can destroy buildings on the game board.
    /// </summary>
    public bool canDestroy = false;

    /// <summary>
    /// The number of bombs left for the player to use.
    /// </summary>
    public int bombsLeft;

    /// <summary>
    /// Flag indicating whether the player can move on the game board.
    /// </summary>
    public bool canWalk = false;

    /// <summary>
    /// Method for instantiating controller
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
        }
    }
}
