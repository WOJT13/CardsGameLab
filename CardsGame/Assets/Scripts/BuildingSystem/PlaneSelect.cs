using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class allows to select planes.
/// </summary>
public class PlaneSelect : MonoBehaviour
{   
    /// <summary>
    /// Information plane occupied or not
    /// </summary>
    public bool isOcccupied = false;

    /// <summary>
    /// Information plane is clicked
    /// </summary>
    public bool isClicked = false;

    /// <summary>
    /// Coordinates of selected plane
    /// </summary>
    public Vector3 Coordinates { get; private set; }
   
    /// <summary>
    /// Method used for click on the plane
    /// </summary>
    private void OnMouseDown()
    { 
        if (isClicked)
        {
            unselect();
        }
        else
        {
            select();
        }
    }

    /// <summary>
    /// Method marks the plane
    /// </summary>
    private void select()
    {
        Coordinates = transform.position;
        if (!isOcccupied)
        {
            isClicked = true;
            changeColor(Color.red);
            safeCoordinates(Coordinates);
        }
    }
    
    /// <summary>
    /// Method unmark the plane
    /// </summary>
    public void unselect()
    {
        Coordinates = transform.position;
        isClicked =false;
        isOcccupied=false;
        changeColor(Color.white);
        removeCoordinates(Coordinates);
    }

    /// <summary>
    /// Method changes plane color
    /// </summary>
    /// <param name="color"></param>
    public void changeColor(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }

    /// <summary>
    /// Method saves plane coordinates
    /// </summary>
    /// <param name="coordinates"></param>
    private void safeCoordinates(Vector3 coordinates)
    {
        GameBoardController.Instance.coordinatesList.AddToList(coordinates);
        Debug.Log("Lista");
    }

    /// <summary>
    /// Method removes plane coordinates
    /// </summary>
    /// <param name="coordinates"></param>
    public void removeCoordinates(Vector3 coordinates)
    {
        GameBoardController.Instance.coordinatesList.RemoveFromList(coordinates);
    }
}
