using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class represent CRUD of list of cards
/// </summary>
public class CardsList
{
    /// <summary>
    /// List of cards
    /// </summary>
    private List<Card> cardsList = new List<Card>();

    /// <summary>
    /// Method allows read all elements of cardList
    /// </summary>
    /// <returns>Elements of cardList</returns>
    public List<Card> GetAll()
    {
        return cardsList;
    }

    /// <summary>
    /// Method allows read element by ID from cardList
    /// </summary>
    /// <param name="cardID"></param>
    /// <returns>Element of cardList</returns>
    public Card GetByID(int cardID)
    {
        return cardsList.FirstOrDefault(c => c.cardID == cardID);
    }

    /// <summary>
    /// Method which add element to cardList
    /// </summary>
    /// <param name="card"></param>
    public void Create(Card card)
    {
        cardsList.Add(card);
    }

    /// <summary>
    /// Method which modify element in cardList
    /// </summary>
    /// <param name="card"></param>
    public void Update(Card card)
    {
        Card cardToUpdate = cardsList.FirstOrDefault(c => c.cardID == card.cardID);
        if (cardToUpdate != null)
        {
            cardToUpdate.symbolCard = card.symbolCard;
            cardToUpdate.pictographCard = card.pictographCard;
            cardToUpdate.parametersList = card.parametersList;
            cardToUpdate.buildingModel = card.buildingModel;
        }
    }

    /// <summary>
    /// Method which delete element from cardList
    /// </summary>
    /// <param name="cardID"></param>
    public void Remove(int cardID)
    {
        Card cardToDelete = cardsList.FirstOrDefault(c => c.cardID == cardID);
        if (cardToDelete != null)
        {
            cardsList.Remove(cardToDelete); 
        }
    }

    public int CardCount()
    {
        return cardsList.Count;
    }

    public Card GetCardAtIndex(int index)
    {
        if (index >= 0 && index < cardsList.Count)
        {
            return cardsList[index];
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// Method to find the index of a card based on its ID
    /// </summary>
    /// <param name="cardID">ID of the card to find</param>
    /// <returns>Index of the card in the list, or -1 if not found</returns>
    public int FindIndex(int cardID)
    {
        return cardsList.FindIndex(c => c.cardID == cardID);
    }
}
