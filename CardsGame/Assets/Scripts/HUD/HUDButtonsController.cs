using Game;
using Model;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HUD
{
    /// <summary>
    /// This class handles button interactions in the HUD and controls game logic.
    /// </summary>
    public class HUDButtonsController : MonoBehaviour
    {
        /// <summary>
        /// Reference to the main camera in the scene.
        /// </summary>
        public Camera mainCamera;

        public List<GameObject> treePrefabs;

        public GameObject fountainPrefab;

        /// <summary>
        /// Handles button click event for ending the game and loading a End Menu scene.
        /// </summary>
        public void OnEndGameButtonClick()
        {
            // Check if the player wins based on game parameters
            foreach (var parameter in DataManager.Instance.difficultyLevel.parameters)
            {
                int points = PointsManager.Instance.parameters.Find(p => p.name == parameter.name).points;

                if (points <= parameter.max && points >= parameter.min)
                    DataManager.Instance.IsWin = true;
                else
                {
                    DataManager.Instance.IsWin = false;
                    break;
                }
            }

            // Load a End Menu scene
            SceneManager.LoadScene(2);
        }

        // public void onDrawNextButtonClick()
        // {
        //     // Generate random coordinates
        //     Vector3 coordinates = new Vector3();
        //     coordinates.x = Random.Range(0, 2);
        //     coordinates.y = Random.Range(0, 2);
        //     coordinates.z = 0f;
        //     // Check if the coordinates are available
        //     bool isOn = GameBoardController.Instance.coordinatesList.CheckList(coordinates);
        //
        //     if (isOn == false)
        //     {
        //         // Add coordinates to the list
        //         GameBoardController.Instance.coordinatesList.AddToListUnique(coordinates);
        //
        //         bool treeExisit = Random.Range(0, 100) > 10;
        //         // Randomly select a card from the list
        //         int index = Random.Range(0, GameBoardController.Instance.cardList.GetAll().Count);
        //         var card = GameBoardController.Instance.cardList.GetAll()[index];
        //
        //         // Calculate the building position based on coordinates
        //         Vector3 buildingPosition = new Vector3(coordinates.x * 10 - 5, 0, coordinates.y * 10);
        //
        //         // Instantiate the building model at the calculated position
        //         GameObject newBuilding = Instantiate(card.buildingModel, buildingPosition, Quaternion.identity);
        //         BuildingController buildingController = newBuilding.GetComponent<BuildingController>();
        //         buildingController.coordinates = coordinates;
        //
        //         PlaceTreesAndFountains(card, buildingPosition, buildingController);
        //
        //         // Update points and store information about the building
        //         foreach (var parameter in card.parametersList)
        //         {
        //             var parameterToUpdate = PointsManager.Instance.Parameters.Find(p => p.name == parameter.category);
        //
        //             if (parameterToUpdate != null)
        //             {
        //                 parameterToUpdate.points += parameter.points;
        //                 buildingController.points.Add(new ParameterWithPoints()
        //                 {
        //                     name = parameter.category,
        //                     points = parameter.points
        //                 });
        //             }
        //         }
        //     }
        //     else
        //     {
        //         // Retry drawing if the coordinates are already in use
        //         if (GameBoardController.Instance.coordinatesList.Count() < 4)
        //         {
        //             onDrawNextButtonClick();
        //         }
        //     }
        // }

        /// <summary>
        /// Places trees and fountains on the card.
        /// </summary>
        /// <param name="card">The card to place trees and fountains on.</param>
        /// <param name="buildingPosition">The position of the building.</param>
        /// <param name="buildingController">The building controller.</param>
        private void PlaceTreesAndFountains(Card card, Vector3 buildingPosition, BuildingController buildingController)
        {
            // Randomly decide to place a fountain
            if (Random.Range(0f, 1f) < 0.5f && card.fountainLocations.Count > 0) // Example probability, adjust as needed
            {
                var fountainPosition = card.fountainLocations[Random.Range(0, card.fountainLocations.Count)];
                var fountainRotation = Quaternion.Euler(-90, 0, 0);
                var item = Instantiate(fountainPrefab, fountainPosition + buildingPosition, fountainRotation);
                buildingController.cardObjectList.Add(item);
            }

            // Randomly decide to place trees
            foreach (var treeLocation in card.treeLocations)
            {
                if (Random.Range(0f, 1f) < 0.7f) // Example probability, adjust as needed
                {
                    var treePrefab = treePrefabs[Random.Range(0, treePrefabs.Count)];
                    var item = Instantiate(treePrefab, treeLocation + buildingPosition, Quaternion.identity);
                    buildingController.cardObjectList.Add(item);
                }
            }
        }

        /// <summary>
        /// Toggles the ability to move the camera or lock it in place.
        /// </summary>
        public void OnWalkButtonClick()
        {
            // Toggle the ability to move the camera
            GameBoardController.Instance.canWalk = !GameBoardController.Instance.canWalk;

            // Go back to the camera's first position when walking is disabled
            if (GameBoardController.Instance.canWalk == false)
                mainCamera.transform.position = new Vector3(0f, 7.58f, -15.66f);
        }
    }
}