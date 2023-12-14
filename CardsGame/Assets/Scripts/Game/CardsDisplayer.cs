using UnityEngine;
using UnityEngine.UI;
using Model;

namespace Game
{
    /// <summary>
    /// Class displays card and place building model
    /// </summary>
    public class CardsDisplayer : MonoBehaviour
    {
        /// <summary>
        /// Card index
        /// </summary>
        public int id;

        /// <summary>
        /// Card image
        /// </summary>
        public Sprite cardImgDisplay;

        private void Start()
        {
            //Display();
        }

        /// <summary>
        /// Method display card
        /// </summary>
        /// <param name="cardIndex"></param>
        public void Display()
        {
            /*GameBoardController.Instance.hand = new CardsList();

            for(int i=0; i < DataManager.Instance.difficultyLevel.startCardsCount; i++)
            {
                Debug.Log(i);
                var drawedCard = GameBoardController.Instance.cardList.GetAll()[UnityEngine.Random.Range(0, DataManager.Instance.difficultyLevel.startCardsCount)];
                GameBoardController.Instance.hand.Create(drawedCard);
                Instantiate(drawedCard.cardModel, container);
            }*/
        }

        /// <summary>
        /// Method used for click on card
        /// </summary>
        public void PlaceOnClick()
        {
            var gameBoardController = GameBoardController.Instance;
            var card = gameBoardController.cardList.GetByID(id);

            if (gameBoardController.selectedPlanePosition is null)
            {
                return;
            }

            var selectedPlanePosition = (Vector3)gameBoardController.selectedPlanePosition;
            var plane = gameBoardController.FindPlane(selectedPlanePosition);

            if (!gameBoardController.isBoardEmpty && (plane == null || !gameBoardController.allowedNeighbourList.CheckList(selectedPlanePosition))) return;

            var newBuilding = Instantiate(card.buildingModel, selectedPlanePosition, Quaternion.identity);
            gameBoardController.ChangePlaneStatusToOccupied(selectedPlanePosition);
            gameBoardController.cardPlacementTracker.Add(selectedPlanePosition, card);

            var planes = gameBoardController.FindAdjacentPlanes(selectedPlanePosition);

            foreach (var neighboringPlane in planes)
            {
                neighboringPlane.ChangeColor(Color.blue);
                neighboringPlane.isAvailable = true;
                var coordinates = neighboringPlane.transform.position;
                gameBoardController.allowedNeighbourList.AddToListUnique(coordinates);
            }
            gameBoardController.points += 2;
            gameBoardController.isBoardEmpty = false;

            QuestManager.Instance.CheckQuests(gameBoardController.cardPlacementTracker);
            Destroy(gameObject);
            gameBoardController.hand.Remove(card.cardID);
            gameBoardController.cardsLeft = gameBoardController.hand.CardCount();

        }


    }
}