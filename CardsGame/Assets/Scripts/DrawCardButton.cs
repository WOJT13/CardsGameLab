using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// Class to handle click button
/// </summary>
public class DrawCardButton : MonoBehaviour
{
    public CoordinatesList coordinatesList = new CoordinatesList();
    /// <summary>
    /// X coorindate of building model
    /// </summary>    
    public int building_x;
    /// <summary>
    /// Z coordinate of building model
    /// </summary>
    public int building_z;

    /// <summary>
    /// Point of building placement
    /// </summary>
    public Vector2Int coordinates = new Vector2Int();

    /// <summary>
    /// Variable tells building is on grid or not
    /// </summary>
    public bool isOn = false;

    /// <summary>
    /// Information text
    /// </summary>
    public TMP_Text info;

    /// <summary>
    /// Method handles button click operation
    /// </summary>
    public void Click()
    {
        Debug.Log(DataManager.Instance == null);
        Debug.Log(DataManager.Instance.cardList == null);
        //DataManager.Instance.cardList.BuildBuilding(building_x, building_y, 0);
        building_x = Random.Range(0, 2);
        building_z = Random.Range(0, 2); 
        Debug.Log(DataManager.Instance.coordinatesList == null);
        coordinates.x = building_x;
        coordinates.y = building_z;
        isOn = DataManager.Instance.coordinatesList.CheckList(coordinates);
        if (isOn == false)
        {
            DataManager.Instance.coordinatesList.AddToList(coordinates);
        }
        //coordinatesList.AddToList(building_x, building_y);


        Debug.Log(isOn);

        if (isOn == false)
        {
            DataManager.Instance.cardList.BuildBuilding(building_x, building_z, 0);
        }
        else
        {
            if (DataManager.Instance.coordinatesList.Count() < 4)
            {
                Debug.Log("nie ma miejsca jeszcze raz");
                Click();
            }
            else
            {
                 info.text = "NIE MA MIEJSCA";
            }
        }
    }
}
