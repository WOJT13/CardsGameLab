using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles button interactions in the HUD and controls game logic.
/// </summary>
public class HUDButtonsController : MonoBehaviour
{
    /// <summary>
    /// Reference to the main camera in the scene.
    /// </summary>
    public Camera mainCamera;

    /// <summary>
    /// Handles button click event for ending the game and loading a End Menu scene.
    /// </summary>
    public void onEndGameButtonClick()
    {
        // Check if the player wins based on game parameters
        foreach (var parameter in DataManager.Instance.difficultyLevel.parameters)
        {
            int points = PointsManager.Instance.Parameters.Find(p => p.name == parameter.name).points;

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

    /// <summary>
    /// Handles button click event for drawing a new card and placing it on the board.
    /// </summary>
    public void onDrawNextButtonClick()
    {
        // Generate random coordinates
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Random.Range(0, 2);
        coordinates.y = Random.Range(0, 2);

        // Check if the coordinates are available
        bool isOn = GameBoardController.Instance.coordinatesList.CheckList(coordinates);

        if (isOn == false)
        {
            // Add coordinates to the list
            GameBoardController.Instance.coordinatesList.AddToList(coordinates);

            // Randomly select a card from the list
            int index = Random.Range(0, GameBoardController.Instance.cardList.GetAll().Count);
            var card = GameBoardController.Instance.cardList.GetAll()[index];

            // Calculate the building position based on coordinates
            Vector3 buildingPosition = new Vector3(coordinates.x * 10 - 5, 0, coordinates.y * 10);

            // Instantiate the building model at the calculated position
            GameObject newBuilding = Instantiate(card.buildingModel, buildingPosition, Quaternion.identity);
            BuildingController buildingController = newBuilding.GetComponent<BuildingController>();
            buildingController.coordinates = coordinates;

            // Update points and store information about the building
            foreach (var parameter in card.parametersList)
            {
                var parameterToUpdate = PointsManager.Instance.Parameters.Find(p => p.name == parameter.category);

                if (parameterToUpdate != null)
                {
                    parameterToUpdate.points += parameter.points;
                    buildingController.points.Add(new ParameterWithPoints()
                    {
                        name = parameter.category,
                        points = parameter.points
                    });
                }
            }
        }
        else
        {
            // Retry drawing if the coordinates are already in use
            if (GameBoardController.Instance.coordinatesList.Count() < 4)
            {
                onDrawNextButtonClick();
            }
        }
    }

    /// <summary>
    /// Toggles the ability to move the camera or lock it in place.
    /// </summary>
    public void onWalkButtonClick()
    {
        // Toggle the ability to move the camera
        GameBoardController.Instance.canWalk = !GameBoardController.Instance.canWalk;

        // Go back to the camera's first position when walking is disabled
        if (GameBoardController.Instance.canWalk == false)
            mainCamera.transform.position = new Vector3(0f, 7.58f, -15.66f);
    }
}
