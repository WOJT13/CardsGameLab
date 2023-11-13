using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Controls a building in the game and handles interactions with it.
/// </summary>
public class BuildingController : MonoBehaviour
{
    /// <summary>
    /// List of parameters associated with this building and their points.
    /// </summary>
    public List<ParameterWithPoints> points = new List<ParameterWithPoints>();

    /// <summary>
    /// The coordinates of the building on the game board.
    /// </summary>
    public Vector2Int coordinates = new Vector2Int();

    [FormerlySerializedAs("cardPrefablList")]
    public List<GameObject> cardObjectList = new List<GameObject>();

    /// <summary>
    /// Called once per frame to check for interactions with the building.
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    OnMouseDown();
                }
            }
        }
    }

    /// <summary>
    /// Called when the building is clicked.
    /// </summary>
    private void OnMouseDown()
    {
        //Check if building can be destroyed
        if (GameBoardController.Instance.canDestroy == true && GameBoardController.Instance.bombsLeft > 0)
        {
            // Remove building's coordinates from the game board
            GameBoardController.Instance.coordinatesList.RemoveFromList(coordinates);

            // Decrease the count of available bombs
            GameBoardController.Instance.bombsLeft--;

            // Update points for associated parameters
            foreach (var parameter in points)
            {
                var parameterToUpdate = PointsManager.Instance.Parameters.Find(p => p.name == parameter.name);

                if (parameterToUpdate != null)
                {
                    parameterToUpdate.points -= parameter.points;
                }
            }

            // Destroy the building
            Destroy(gameObject);

            foreach(var element in cardObjectList)
            {
                Destroy(element);
            }

        }
    }
}