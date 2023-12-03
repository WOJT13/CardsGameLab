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
    public List<Vector3> coordinatesList = new List<Vector3>();

    /// <summary>
    /// Method which add element to the list
    /// </summary>
    /// <param name="coordinates"></param>
    public void AddToList(Vector3 coordinates)
    {
        coordinatesList.Add(coordinates);
    }

    /// <summary>
    /// Method which check if element is already in list
    /// </summary>
    /// <param name="coordinates"></param>
    /// <returns>Information that element is in list or not</returns>
    public bool CheckList(Vector3 coordinates)
    {
        bool OnList=false;
        foreach(Vector3 c in coordinatesList)
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

    /// <summary>
    /// Method which remove element from list
    /// </summary>
    /// <param name="coordinates"></param>
    public void RemoveFromList(Vector3 coordinates)
    {
        coordinatesList.Remove(coordinates);
    }

    /// <summary>
    /// Method returns first element in list 
    /// </summary>
    /// <returns>First element</returns>
    public Vector3 GetFirstElement()
    {
        return coordinatesList[0];
    }
}
