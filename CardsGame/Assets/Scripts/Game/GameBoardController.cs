using BuildingSystem;
using Model;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Manages the game board and related data and actions.
    /// </summary>
    public class GameBoardController : MonoBehaviour
    {
        /// <summary>
        /// Get and set the singleton instance of the GameBoardController.
        /// </summary>
        public static GameBoardController Instance { get; private set; }

        /// <summary>
        /// Reference to a single card object.
        /// </summary>
        public Card card = null;

        /// <summary>
        /// Reference to a list of card objects.
        /// </summary>
        public CardsList cardList = null;

        /// <summary>
        /// The position of the selected plane.
        /// </summary>
        public Vector3? selectedPlanePosition = null;

        /// <summary>
        /// List of neighbor coordinates of building models
        /// </summary>
        public CoordinatesList allowedNeighbourList = new CoordinatesList();

        /// <summary>
        /// Flag indicating whether the player can destroy buildings on the game board.
        /// </summary>
        public bool canDestroy = false;

        /// <summary>
        /// The number of bombs left for the player to use.
        /// </summary>
        public int bombsLeft;

        /// <summary>
        /// Flag indicating whether the player can move on the game board.
        /// </summary>
        public bool canWalk = false;

        /// <summary>
        /// Information about first building on grid
        /// </summary>
        public bool isBoardEmpty = true;

        /// <summary>
        /// Method for instantiating controller
        /// </summary>
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        /// <summary>
        /// Method allows unmark plane
        /// </summary>
        /// <param name="coordinates"></param>
        public void ChangePlaneStatusToOccupied(Vector3 coordinates)
        {
            var all = FindObjectsOfType<PlaneSelect>();
            foreach (var plane in all)
            {
                if (plane.transform.position != coordinates) continue;
                plane.StatusToOccupied();
                break;
            }
        }

        /// <summary>
        /// Method finds plane
        /// </summary>
        /// <param name="position"></param>
        /// <returns>Plane</returns>
        public PlaneSelect FindPlane(Vector3 position)
        {
            var colliders = Physics.OverlapSphere(position, 0.1f);
            foreach (var collider in colliders)
            {
                var plane = collider.GetComponent<PlaneSelect>();
                if (plane != null)
                {
                    return plane;
                }
            }
            return null;
        }

        /// <summary>
        /// Method finds buildings neihbor planes
        /// </summary>
        /// <param name="position"></param>
        /// <returns>List of planes</returns>
        public PlaneSelect[] FindAdjacentPlanes(Vector3 position)
        {
            const float radius = 10.0f;

            var colliders = Physics.OverlapSphere(position, radius);

            var adjacentPlanes = new List<PlaneSelect>();

            foreach (var collider in colliders)
            {
                var plane = collider.GetComponent<PlaneSelect>();

                if (plane != null && !plane.isOcc)
                {
                    adjacentPlanes.Add(plane);
                }
            }

            return adjacentPlanes.ToArray();
        }
    }
}