using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class creates the grid
/// </summary>
public class GridManager : MonoBehaviour
{
    /// <summary>
    /// Column length of grid
    /// </summary>
    [SerializeField]
    public int columnLength;
    /// <summary>
    /// Row length of grid
    /// </summary>
    //[SerializeField]
    public int rowLength;

    /// <summary>
    /// Space between parts of grid
    /// </summary>
    public int x_Space;
   /// <summary>
   /// Space between parts of grid
   /// </summary>
    public int z_Space;

    /// <summary>
    /// Plane which create the grid
    /// </summary>
    [SerializeField]
    private GameObject prefab;

    /// <summary>
    /// Bool variable informed that grid is created
    /// </summary>
    public bool gridIsCreated;


    /// <summary>
    /// Method which create a grid
    /// </summary>
    void Start()
    {
        if(gridIsCreated == false)
        {
            for(int i = 0; i < columnLength; i++)
            { 
                for(int j = 0; j < rowLength; j++)
                {
                    Instantiate(prefab, new Vector3(x_Space*i-5,0,j*z_Space), Quaternion.identity);
                    //Vector3 buildingPosition = new Vector3(1 * x_Space, 0, 0 * z_Space);
                    //Instantiate(building, buildingPosition, Quaternion.identity);
                }
            }
            gridIsCreated = true;
        }
    }
}
