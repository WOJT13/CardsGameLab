using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class represent list of coordinates of building
/// </summary>
public class CoordinatesList
{
    /// <summary>
    /// List of building placement points
    /// </summary>
    public List<Vector2Int> coordinatesList = new List<Vector2Int>();

    /// <summary>
    /// Method which add element to the list
    /// </summary>
    /// <param name="coordinates"></param>
    public void AddToList(Vector2Int coordinates)
    {
        coordinatesList.Add(coordinates);
    }

    /// <summary>
    /// Method which check if element is already in list
    /// </summary>
    /// <param name="coordinates"></param>
    /// <returns>Information that element is in list or not</returns>
    public bool CheckList(Vector2Int coordinates)
    {
        bool OnList=false;
        foreach(Vector2Int c in coordinatesList)
        {
            if(coordinates == c)
            {
                OnList=true;
            }
        }
        return OnList;
    }

    /// <summary>
    /// Method returns list size
    /// </summary>
    /// <returns>Numbers of elements in list</returns>
    public int Count()
    {
        return coordinatesList.Count;
    }

    public void RemoveFromList(Vector2Int coordinates)
    {
        coordinatesList.Remove(coordinates);
    }
}
