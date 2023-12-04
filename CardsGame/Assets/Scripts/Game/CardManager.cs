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
                cardID = 1,
                symbol = Symbol.Pik,
                pictograph = Pictograph.As,
                parametersList = new List<Parameters>() { new Parameters() { category = "ParametrB", points = 4 } },
                buildingModel = building,
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
                cardID = 1,
                symbol = Symbol.Pik,
                pictograph = Pictograph.n9,
                parametersList = new List<Parameters>() { new Parameters() { category = "ParametrB", points = 7 } },
                buildingModel = building,
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
                cardID = 1,
                symbol = Symbol.Pik,
                pictograph = Pictograph.n3,
                parametersList = new List<Parameters>() { new Parameters() { category = "ParametrA", points = 3 } },
                buildingModel = building,
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
                cardID = 1,
                symbol = Symbol.Pik,
                pictograph = Pictograph.n2,
                parametersList = new List<Parameters>() { new Parameters() { category = "ParametrA", points = 2 } },
                buildingModel = building,
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
            GameBoardController.Instance.cardList = cardsList;
        }

    }
}