using Model;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
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
        /// Object represent card
        /// </summary>
        public GameObject card;

        /// <summary>
        /// The container where the card objects will be instantiated.
        /// </summary>
        public Transform container;

        public Sprite cardImg;

        /// <summary>
        /// Method that adds card to list of cards
        /// </summary>
        private void Awake()
        {
            Symbol[] symbols = { Symbol.Pik, Symbol.Kier, Symbol.Trefl, Symbol.Karo };
            Pictograph[] pictographs = { Pictograph.As, Pictograph.Krol, Pictograph.Dama, Pictograph.Walet, 
                             Pictograph.n10, Pictograph.n9, Pictograph.n8, Pictograph.n7, 
                             Pictograph.n6, Pictograph.n5, Pictograph.n4, Pictograph.n3, 
                             Pictograph.n2 };

            int cardID = 1;
            foreach (Symbol symbol in symbols)
            {
                foreach (Pictograph pictograph in pictographs)
                {
                    // Create a new card with the current symbol and pictograph
                    var newCard = new Card
                    {
                        cardID = cardID++,
                        symbol = symbol,
                        pictograph = pictograph,
                        buildingModel = building,
                        cardModel = card,
                        treeLocations = new List<Vector3>
                        {
                            new Vector3(-3, 0, -3), // Corner 1
                            new Vector3(3, 0, -3), // Corner 2
                            new Vector3(-3, 0, 3), // Corner 3
                            //new Vector3(3, 0, 3) // Corner 4
                        },
                        fountainLocations = new List<Vector3>
                        {
                            new Vector3(3, 0, 3) // Corner 4
                        },
                        cardImage = cardImg,
                    };

                    // Add the new card to the list
                    cardsList.Create(newCard);
                }
            }             
            

            GameBoardController.Instance.cardList = cardsList;
            GameBoardController.Instance.hand = new CardsList();
            for(int i=0; i < DataManager.Instance.difficultyLevel.startCardsCount; i++)
            {
                var drawedCard = cardsList.DrawCard();
                GameBoardController.Instance.hand.Create(drawedCard);
                
                var newGameObject = Instantiate(drawedCard.cardModel, container);
                var newCard = newGameObject.GetComponent<CardsDisplayer>();
                newCard.id = drawedCard.cardID;
            }

            GameBoardController.Instance.cardsLeftInDeck = cardsList.CardCount() - DataManager.Instance.difficultyLevel.startCardsCount;
            
        }

        private void Update()
        {
            if (GameBoardController.Instance.cardsLeft == 0)
            {
                DataManager.Instance.points = GameBoardController.Instance.points;
                SceneManager.LoadScene(2);
            }
                
        }

    }
}