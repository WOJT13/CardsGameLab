using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public enum symbol
{
    Pik,
    Kier,
    Trefl,
    Karo
}

public enum pictograph
{
    As,
    Krol,
    Dama,
    Walet,
    n10,
    n9,
    n8,
    n7,
    n6,
    n5,
    n4,
    n3,
    n2
}
/// <summary>
/// Class represent card
/// </summary>
[System.Serializable]

public class Card : MonoBehaviour
{
    /// <summary>
    /// ID of card
    /// </summary>
    public int cardID;

    /// <summary>
    /// Symbol of card
    /// </summary>
    public symbol symbolCard;

    /// <summary>
    /// Pictograph of card
    /// </summary>
    public pictograph pictographCard;

    /// <summary>
    /// List of card parameters
    /// </summary>
    public List<Parameters> parametersList;

    /// <summary>
    /// Model of builing from card
    /// </summary>
    public GameObject buildingModel;

    /// <summary>
    /// Method to place the building model on x and z cooridinates
    /// </summary>
    /// <param name="building_x"></param>
    /// <param name="building_z"></param>
    public void PlacementBuilding(int building_x, int building_z)
    {
   
        Vector3 buildingPosition = new Vector3(building_x * 10, 0, building_z * 10);
        Instantiate(buildingModel, buildingPosition, Quaternion.identity);
    }
}


