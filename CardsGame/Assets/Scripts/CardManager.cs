using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to create elements in list of cards
/// </summary>
public class CardManager : MonoBehaviour
{
    /// <summary>
    /// List of card when card be added
    /// </summary>
    public CardsList cardsList = new CardsList();
    /// <summary>
    /// Object represent builing in card
    /// </summary>
    public GameObject building;

    /// <summary>
    /// Method added card to list of cards
    /// </summary>
    void Awake()
    {
        
        Card KingCard = new Card
        {
            cardID = 1,
            symbolCard = symbol.Pik,
            pictographCard = pictograph.Krol,
            parametersList = new List<Parameters>(){ new Parameters() { category = "ParametrA", points = 6 }, new Parameters() { category = "ParametrB", points = 5 }},
            buildingModel = building
            
        };
        Card AsCard = new Card
        {
            cardID = 1,
            symbolCard = symbol.Kier,
            pictographCard = pictograph.As,
            parametersList = new List<Parameters>(){ new Parameters() { category = "ParametrB", points = 4 }},
            buildingModel = building
            
        };

        Card N9Card = new Card
        {
            cardID = 1,
            symbolCard = symbol.Karo,
            pictographCard = pictograph.n9,
            parametersList = new List<Parameters>(){ new Parameters() { category = "ParametrB", points = 7 }},
            buildingModel = building
            
        };

        Card N3Card = new Card
        {
            cardID = 1,
            symbolCard = symbol.Trefl,
            pictographCard = pictograph.n3,
            parametersList = new List<Parameters>(){ new Parameters() { category = "ParametrA", points = 3 }},
            buildingModel = building
            
        };

        Card N2Card = new Card
        {
            cardID = 1,
            symbolCard = symbol.Pik,
            pictographCard = pictograph.n2,
            parametersList = new List<Parameters>(){ new Parameters() { category = "ParametrA", points = 2 }},
            buildingModel = building
            
        };

        cardsList.Create(KingCard);
        cardsList.Create(AsCard);
        cardsList.Create(N9Card);
        cardsList.Create(N3Card);
        cardsList.Create(N2Card);
        GameBoardController.Instance.cardList = cardsList;
    }

}
