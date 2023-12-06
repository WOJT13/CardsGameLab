using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Game
{
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
        public Vector3 coordinates = new Vector3();

        /// <summary>
        /// List of card objects
        /// </summary>
        [FormerlySerializedAs("cardPrefablList")]
        public List<GameObject> cardObjectList = new List<GameObject>();


        /// <summary>
        /// Called once per frame to check for interactions with the building.
        /// </summary>
        void Update()
        {
            // Check for left mouse button click
            if (!Input.GetMouseButtonDown(0)) return;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    OnMouseDown();
                }
            }
        }

        /// <summary>
        /// Called when the building is clicked.
        /// </summary>
        private void OnMouseDown()
        {
            var gameBoardController = GameBoardController.Instance;
            if (gameBoardController == null)
                return;

            if (EventSystem.current.IsPointerOverGameObject()) return;

            //Check if building can be destroyed
            if (gameBoardController.canDestroy != true || gameBoardController.bombsLeft <= 0) return;

            // Decrease the count of available bombs
            gameBoardController.bombsLeft--;

            // Update points for associated parameters
            foreach (var parameter in points)
            {
                var parameterToUpdate = PointsManager.Instance.parameters.Find(p => p.name == parameter.name);

                if (parameterToUpdate != null)
                {
                    parameterToUpdate.points -= parameter.points;
                }
            }

            var plane = gameBoardController.FindPlane(transform.position);
            plane.isAvailable = true;
            plane.isOcc = false;

            if (gameBoardController.cardPlacementTracker.Count == 1)
                gameBoardController.isBoardEmpty = true;

            if(gameBoardController.isBoardEmpty)
                plane.ChangeColor(Color.white);
            else
                plane.ChangeColor(Color.blue);

            var neighboringPlanes = gameBoardController.FindAdjacentPlanes(transform.position);

            gameBoardController.cardPlacementTracker.Remove(transform.position);
            foreach(var neighboringPlane in neighboringPlanes)
            {
                neighboringPlane.ChangeColor(Color.white);
                neighboringPlane.isAvailable = false;
            }

            gameBoardController.CreateNeighbourhood();

            // Destroy the building
            Destroy(gameObject);

            foreach (var element in cardObjectList)
            {
                Destroy(element);
            }
        }
    }
}