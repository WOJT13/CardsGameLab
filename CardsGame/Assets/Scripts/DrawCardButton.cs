using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to handle click button
/// </summary>
public class DrawCardButton : MonoBehaviour
{
    /// <summary>
    /// X coorindate of building model
    /// </summary>    
    public int building_x;
    /// <summary>
    /// Z coordinate of building model
    /// </summary>
    public int building_y;

    /// <summary>
    /// Method handles button click operation
    /// </summary>
    public void Click()
    {
        Debug.Log(DataManager.Instance == null);
        Debug.Log(DataManager.Instance.cardList == null);
        //DataManager.Instance.cardList.BuildBuilding(building_x, building_y, 0);
        building_x = Random.Range(0, 2);
        building_y = Random.Range(0, 2); 
        DataManager.Instance.cardList.BuildBuilding(building_x, building_y, 0);
    }
}
