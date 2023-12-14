using Model;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            /*Symbol[] symbols = { Symbol.Pik, Symbol.Kier, Symbol.Trefl, Symbol.Karo };
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
            }*/

            int cardID = 1;
            List<string> cardsName = new List<string>() {"3_PIK", "4_KARO", "6_KIER", "7_TREFL","8_PIK","D_KIER", "K_KARO", "K_TREFL"};
            for (int i = 0; i < 5; i++) {
                foreach (var cardName in cardsName) {
                    var Card1 = new Card
                    {
                        cardID = cardID++,
                        symbol = MapSymbol(cardName),
                        pictograph = MapPictogtaph(cardName),
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
                        cardImage = Resources.Load<Sprite>($"cardsImg/{cardName}"),
                    };
                    cardsList.Create(Card1);
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
                var image = newGameObject.GetComponent<Image>();
                image.sprite = drawedCard.cardImage;
                //newCard.cardImgDisplay = drawedCard.cardImage;
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

        private Pictograph MapPictogtaph(string name)
        {
            var symbol = name[0];

            switch(symbol)
            {
                case ('3'):
                    return Pictograph.n3;
                case ('4'):
                    return Pictograph.n4;
                case ('6'):
                    return Pictograph.n6;
                case ('7'):
                    return Pictograph.n7;
                case ('8'):
                    return Pictograph.n8;
                case ('D'):
                    return Pictograph.Dama;
                case ('K'):
                    return Pictograph.Krol;
                default:
                    return Pictograph.As;
            }
        }

        private Symbol MapSymbol(string name)
        {
            var symbol = name.Substring(2);

            switch (symbol)
            {
                case ("PIK"):
                    return Symbol.Pik;
                case ("KARO"):
                    return Symbol.Karo;
                case ("KIER"):
                    return Symbol.Kier;
                case ("TREFL"):
                    return Symbol.Trefl;
                default:
                    return Symbol.Pik;
            }
        }
    }
}