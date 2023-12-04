using UnityEngine;
using UnityEngine.UI;

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
        public int index;

        /// <summary>
        /// Card image
        /// </summary>
        public Image cardImgDisplay;

        private void Start()
        {
            Display(index);
        }

        /// <summary>
        /// Method display card
        /// </summary>
        /// <param name="cardIndex"></param>
        public void Display(int cardIndex)
        {
            if (cardIndex < 0 || cardIndex >= GameBoardController.Instance.cardList.CardCount()) return;

            var displayedCard = GameBoardController.Instance.cardList.GetCardAtIndex(cardIndex);
            cardImgDisplay.sprite = displayedCard.cardImage;
        }

        /// <summary>
        /// Method used for click on card
        /// </summary>
        public void PlaceOnClick()
        {
            var gameBoardController = GameBoardController.Instance;
            var card = gameBoardController.cardList.GetAll()[index];

            if (gameBoardController.selectedPlanePosition is null)
            {
                return;
            }

            var selectedPlanePosition = (Vector3)gameBoardController.selectedPlanePosition;
            var plane = gameBoardController.FindPlane(selectedPlanePosition);
            Debug.Log(plane.isOcc);

            if (!gameBoardController.isBoardEmpty && (plane == null || !gameBoardController.allowedNeighbourList.CheckList(selectedPlanePosition))) return;

            Debug.Log(selectedPlanePosition);
            var newBuilding = Instantiate(card.buildingModel, selectedPlanePosition, Quaternion.identity);
            gameBoardController.ChangePlaneStatusToOccupied(selectedPlanePosition);

            var planes = gameBoardController.FindAdjacentPlanes(selectedPlanePosition);

            foreach (var neighboringPlane in planes)
            {
                neighboringPlane.ChangeColor(Color.blue);
                neighboringPlane.isAvailable = true;
                var coordinates = neighboringPlane.transform.position;
                gameBoardController.allowedNeighbourList.AddToListUnique(coordinates);
            }

            gameBoardController.isBoardEmpty = false;
            Debug.Log(gameBoardController.allowedNeighbourList.Count());
        }


    }
}