using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    /// <summary>
    /// Get and set instance of data manager
    /// </summary>
    public static PointsManager Instance { get; private set; }

    public List<ParameterWithPoints> Parameters = null;


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

public class ParameterWithPoints{
    public string name;
    public int points;
}
