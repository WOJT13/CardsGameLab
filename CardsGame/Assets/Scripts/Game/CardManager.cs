using Model;
using System.Collections.Generic;
using UnityEngine;

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
            var kingCard = new Card
            {
                cardID = 1,
                symbol = Symbol.Pik,
                pictograph = Pictograph.Krol,
                parametersList = new List<Parameters>() { new Parameters() { category = "ParametrA", points = 6 }, new Parameters() { category = "ParametrB", points = 5 } },
                buildingModel = building,
                cardModel = card,
                treeLocations = new List<Vector3>
                {
                    new Vector3(-3, 0, -3), // Corner 1
                    new Vector3(3, 0, -3), // Corner 2
                    new Vector3(-3, 0, 3), // Corner 3
                    //new Vector3(3, 0, 3)// Corner 4
                },
                fountainLocations = new List<Vector3>
                {
                    new Vector3(3, 0, 3) // Corner 4
                },

                cardImage = cardImg,
            };
            var asCard = new Card
            {
                cardID = 2,
                symbol = Symbol.Pik,
                pictograph = Pictograph.As,
                parametersList = new List<Parameters>() { new Parameters() { category = "ParametrB", points = 4 } },
                buildingModel = building,
                cardModel = card,
                treeLocations = new List<Vector3>
                {
                    new Vector3(-3, 0, -3), // Corner 1
                    new Vector3(3, 0, -3), // Corner 2
                    new Vector3(-3, 0, 3), // Corner 3
                    //new Vector3(3, 0, 3)// Corner 4
                },
                fountainLocations = new List<Vector3>
                {
                    new Vector3(3, 0, 3) // Corner 4
                },
                cardImage = cardImg,
            };

            var n9Card = new Card
            {
                cardID = 3,
                symbol = Symbol.Pik,
                pictograph = Pictograph.n9,
                parametersList = new List<Parameters>() { new Parameters() { category = "ParametrB", points = 7 } },
                buildingModel = building,
                cardModel = card,
                treeLocations = new List<Vector3>
                {
                    new Vector3(-3, 0, -3), // Corner 1
                    new Vector3(3, 0, -3), // Corner 2
                    new Vector3(-3, 0, 3), // Corner 3
                    //new Vector3(3, 0, 3)// Corner 4
                },
                fountainLocations = new List<Vector3>
                {
                    new Vector3(3, 0, 3) // Corner 4
                },
                cardImage = cardImg,
            };

            var n3Card = new Card
            {
                cardID = 4,
                symbol = Symbol.Pik,
                pictograph = Pictograph.n3,
                parametersList = new List<Parameters>() { new Parameters() { category = "ParametrA", points = 3 } },
                buildingModel = building,
                cardModel = card,
                treeLocations = new List<Vector3>
                {
                    new Vector3(-3, 0, -3), // Corner 1
                    new Vector3(3, 0, -3), // Corner 2
                    new Vector3(-3, 0, 3), // Corner 3
                    //new Vector3(3, 0, 3)// Corner 4
                },
                fountainLocations = new List<Vector3>
                {
                    new Vector3(3, 0, 3) // Corner 4
                },
                cardImage = cardImg,
            };

            var n2Card = new Card
            {
                cardID = 5,
                symbol = Symbol.Pik,
                pictograph = Pictograph.n2,
                parametersList = new List<Parameters>() { new Parameters() { category = "ParametrA", points = 2 } },
                buildingModel = building,
                cardModel = card,
                treeLocations = new List<Vector3>
                {
                    new Vector3(-3, 0, -3), // Corner 1
                    new Vector3(3, 0, -3), // Corner 2
                    new Vector3(-3, 0, 3), // Corner 3
                    //new Vector3(3, 0, 3)// Corner 4
                },
                fountainLocations = new List<Vector3>
                {
                    new Vector3(3, 0, 3) // Corner 4
                },
                cardImage = cardImg,
            };

            cardsList.Create(kingCard);
            cardsList.Create(asCard);
            cardsList.Create(n9Card);
            cardsList.Create(n3Card);
            cardsList.Create(n2Card);
            cardsList.Create(kingCard);
            cardsList.Create(asCard);
            cardsList.Create(n9Card);
            cardsList.Create(n3Card);
            cardsList.Create(n2Card);
            cardsList.Create(kingCard);
            cardsList.Create(asCard);
            cardsList.Create(n9Card);
            cardsList.Create(n3Card);
            cardsList.Create(n2Card);

            GameBoardController.Instance.cardList = cardsList;
            GameBoardController.Instance.hand = new CardsList();

            for(int i=0; i < DataManager.Instance.difficultyLevel.startCardsCount; i++)
            {
                var drawedCard = cardsList.GetCardAtIndex(UnityEngine.Random.Range(0, cardsList.CardCount()));
                GameBoardController.Instance.hand.Create(drawedCard);
                var newGameObject = Instantiate(drawedCard.cardModel, container);
                var newCard = newGameObject.GetComponent<CardsDisplayer>();
                newCard.id = drawedCard.cardID;
    }
            
        }

    }
}