using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to create elements in list of cards
/// </summary>
public class CardManager : MonoBehaviour
{
    /// <summary>
    /// List of cards
    /// </summary>
    public CardsList cardsList = new CardsList();
    /// <summary>
    /// Object represent building in card
    /// </summary>
    public GameObject building;

    /// <summary>
    /// Method that adds card to list of cards
    /// </summary>
    void Awake()
    {

        Card KingCard = new Card{
            cardID = 1,
            symbolCard = symbol.Pik,
            pictographCard = pictograph.Krol,
            parametersList = new List<Parameters>(){new Parameters(){category = "ParametrA", points = 6}, new Parameters(){category = "ParametrB", points = 5}},
            buildingModel = building,
            treeLocations = new List<Vector3>{
                new Vector3(-3, 0, -3),// Corner 1
                new Vector3(3, 0, -3),// Corner 2
                new Vector3(-3, 0, 3),// Corner 3
                //new Vector3(3, 0, 3)// Corner 4
            },
            fountainLocations = new List<Vector3>{
                new Vector3(3, 0, 3)// Corner 4
            },

        };
        Card AsCard = new Card{
            cardID = 1,
            symbolCard = symbol.Kier,
            pictographCard = pictograph.As,
            parametersList = new List<Parameters>(){new Parameters(){category = "ParametrB", points = 4}},
            buildingModel = building,
            treeLocations = new List<Vector3>{
                new Vector3(-3, 0, -3),// Corner 1
                new Vector3(3, 0, -3),// Corner 2
                new Vector3(-3, 0, 3),// Corner 3
                //new Vector3(3, 0, 3)// Corner 4
            },
            fountainLocations = new List<Vector3>{
                new Vector3(3, 0, 3)// Corner 4
            },

        };

        Card N9Card = new Card{
            cardID = 1,
            symbolCard = symbol.Karo,
            pictographCard = pictograph.n9,
            parametersList = new List<Parameters>(){new Parameters(){category = "ParametrB", points = 7}},
            buildingModel = building,
            treeLocations = new List<Vector3>{
                new Vector3(-3, 0, -3),// Corner 1
                new Vector3(3, 0, -3),// Corner 2
                new Vector3(-3, 0, 3),// Corner 3
                //new Vector3(3, 0, 3)// Corner 4
            },
            fountainLocations = new List<Vector3>{
                new Vector3(3, 0, 3)// Corner 4
            },

        };

        Card N3Card = new Card{
            cardID = 1,
            symbolCard = symbol.Trefl,
            pictographCard = pictograph.n3,
            parametersList = new List<Parameters>(){new Parameters(){category = "ParametrA", points = 3}},
            buildingModel = building,
            treeLocations = new List<Vector3>{
                new Vector3(-3, 0, -3),// Corner 1
                new Vector3(3, 0, -3),// Corner 2
                new Vector3(-3, 0, 3),// Corner 3
                //new Vector3(3, 0, 3)// Corner 4
            },
            fountainLocations = new List<Vector3>{
                new Vector3(3, 0, 3)// Corner 4
            },

        };

        Card N2Card = new Card{
            cardID = 1,
            symbolCard = symbol.Pik,
            pictographCard = pictograph.n2,
            parametersList = new List<Parameters>(){new Parameters(){category = "ParametrA", points = 2}},
            buildingModel = building,
            treeLocations = new List<Vector3>{
                new Vector3(-3, 0, -3),// Corner 1
                new Vector3(3, 0, -3),// Corner 2
                new Vector3(-3, 0, 3),// Corner 3
                //new Vector3(3, 0, 3)// Corner 4
            },
            fountainLocations = new List<Vector3>{
                new Vector3(3, 0, 3)// Corner 4
            },

        };

        cardsList.Create(KingCard);
        cardsList.Create(AsCard);
        cardsList.Create(N9Card);
        cardsList.Create(N3Card);
        cardsList.Create(N2Card);
        GameBoardController.Instance.cardList = cardsList;
    }

}