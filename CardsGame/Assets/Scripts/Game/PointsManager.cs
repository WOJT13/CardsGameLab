using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages and stores points related to game parameters.
/// </summary>
public class PointsManager : MonoBehaviour
{
    /// <summary>
    /// Get and set the singleton instance of the PointsManager.
    /// </summary>
    public static PointsManager Instance { get; private set; }

    /// <summary>
    /// The list of game parameters with associated points.
    /// </summary>
    public List<ParameterWithPoints> Parameters = null;

    /// <summary>
    /// Called on object initialization.
    /// Initializes the PointsManager.
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

/// <summary>
/// Represents a game parameter with associated points.
/// </summary>
public class ParameterWithPoints
{
    /// <summary>
    /// The name of the parameter.
    /// </summary>
    public string name;

    /// <summary>
    /// The points associated with the parameter.
    /// </summary>
    public int points;
}
