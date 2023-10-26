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
    void Start()
    {
        Card KingCard = new Card
        {
            cardID = 1,
            symbolCard = symbol.Pik,
            pictographCard = pictograph.Krol,
            parametersList = new List<Parameters>()
            
        };
        KingCard.parametersList.Add(new Parameters() { category = "a", points = 2 });
        KingCard.buildingModel = building;
        cardsList.Create(KingCard);
        DataManager.Instance.cardList = cardsList;
        Debug.Log(DataManager.Instance.cardList == null) ;
    }

}
