using Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace BuildingSystem
{
    /// <summary>
    /// Class allows to select planes.
    /// </summary>
    public class PlaneSelect : MonoBehaviour
    {
        /// <summary>
        /// Information plane occupied or not
        /// </summary>
        [FormerlySerializedAs("isOccupied")]
        public bool isOcc = false;

        /// <summary>
        /// Information plane available or not
        /// </summary>
        public bool isAvailable = true;

        /// <summary>
        /// Information plane is clicked
        /// </summary>
        public bool isClicked = false;

        /// <summary>
        /// Coordinates of selected plane
        /// </summary>
        public Vector3 Coordinates { get; private set; }

        /// <summary>
        /// Method used for click on the plane
        /// </summary>
        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            if (isClicked)
            {
                Unselect();
            }
            else
            {
                Select();
            }
        }

        /// <summary>
        /// Method marks the plane
        /// </summary>
        private void Select()
        {
            var gameBoardController = GameBoardController.Instance;
            Coordinates = transform.position;

            if (!gameBoardController.isBoardEmpty &&
            ( (isOcc || !isAvailable) || !gameBoardController.allowedNeighbourList.CheckList(Coordinates))) return;

            if (gameBoardController.selectedPlanePosition != null)
            {
                var selectedPlanePosition = (Vector3)gameBoardController.selectedPlanePosition;
                var plane = gameBoardController.FindPlane(selectedPlanePosition);
                plane.Unselect();
            }

            isClicked = true;
            ChangeColor(Color.red);
            SaveCoordinates(Coordinates);
            

            
        }

        /// <summary>
        /// Method unmark the plane
        /// </summary>
        public void Unselect()
        {
            Coordinates = transform.position;
            isClicked = false;
            if (isAvailable && !GameBoardController.Instance.isBoardEmpty)
            {
                ChangeColor(Color.blue);
            }
            else
            {
                ChangeColor(Color.white);
            }
            RemoveCoordinates(Coordinates);
        }

        /// <summary>
        /// Method changes plane status to occupied
        /// </summary>
        public void StatusToOccupied()
        {
            isOcc = true;
            isAvailable = false;
            isClicked = false;
            ChangeColor(Color.gray);
            RemoveCoordinates(Coordinates);
        }

        /// <summary>
        /// Method changes plane color
        /// </summary>
        /// <param name="color"></param>
        public void ChangeColor(Color color)
        {
            var component = GetComponent<Renderer>();
            component.material.color = color;
        }

        /// <summary>
        /// Method saves plane coordinates
        /// </summary>
        /// <param name="coordinates"></param>
        private void SaveCoordinates(Vector3 coordinates)
        {
            //GameBoardController.Instance.coordinatesList.AddToListUnique(coordinates);
            GameBoardController.Instance.selectedPlanePosition = coordinates;
            Debug.Log("Lista");
        }

        /// <summary>
        /// Method removes plane coordinates
        /// </summary>
        /// <param name="coordinates"></param>
        public void RemoveCoordinates(Vector3 coordinates)
        {
            //GameBoardController.Instance.coordinatesList.RemoveFromList(coordinates);
            GameBoardController.Instance.selectedPlanePosition = null;
        }
    }
}