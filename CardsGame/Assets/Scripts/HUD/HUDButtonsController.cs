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
            DataManager.Instance.points = GameBoardController.Instance.points;

            // Load a End Menu scene
            SceneManager.LoadScene(2);
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