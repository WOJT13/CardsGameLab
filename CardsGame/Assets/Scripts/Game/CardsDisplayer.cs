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

            var buildingController = newBuilding.GetComponent<BuildingController>();
            buildingController.coordinates = selectedPlanePosition;
            PlaceTreesAndFountains(card, selectedPlanePosition, buildingController, gameBoardController);

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

        /// <summary>
        /// Places trees and fountains on the card.
        /// </summary>
        /// <param name="card">The card to place trees and fountains on.</param>
        /// <param name="buildingPosition">The position of the building.</param>
        /// <param name="buildingController">The building controller.</param>
        /// <param name="gameBoardController">The game board controller</param>
        private static void PlaceTreesAndFountains(Card card, Vector3 buildingPosition, BuildingController buildingController, GameBoardController gameBoardController)
        {
            // Randomly decide to place a fountain
            if (Random.Range(0f, 1f) < 0.5f && card.fountainLocations.Count > 0) // Example probability, adjust as needed
            {
                var fountainPosition = card.fountainLocations[Random.Range(0, card.fountainLocations.Count)];
                var fountainRotation = Quaternion.Euler(-90, 0, 0);
                var item = Instantiate(gameBoardController.fountainPrefab, fountainPosition + buildingPosition, fountainRotation);
                buildingController.cardObjectList.Add(item);
            }

            // Randomly decide to place trees
            foreach (var treeLocation in card.treeLocations)
            {
                if (Random.Range(0f, 1f) < 0.7f) // Example probability, adjust as needed
                {
                    var treePrefab = gameBoardController.treePrefabs[Random.Range(0, gameBoardController.treePrefabs.Count)];
                    var item = Instantiate(treePrefab, treeLocation + buildingPosition, Quaternion.identity);
                    buildingController.cardObjectList.Add(item);
                }
            }
        }


    }
}