using UnityEngine;

namespace Game
{
    /// <summary>
    /// Controls the camera's movement based on player input.
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        /// <summary>
        /// Flag informed about mouse dragging
        /// </summary>
        private bool isDragging = false;

        /// <summary>
        /// Start camera position
        /// </summary>
        private Vector3 dragStartPosition;

        /// <summary>
        /// Minimal X value in camera positon
        /// </summary>
        public float minX = 0f;
        /// <summary>
        /// Maximal X value in camera position
        /// </summary>
        public float maxX = 120f;
        /// <summary>
        /// Minimal Y vaue in camera position
        /// </summary>
        public float minY = 15f;
        /// <summary>
        /// Maximal Y value in camera position
        /// </summary>
        public float maxY = 40f;

        void Update()
        {
            HandleMouseInput();
        }
        /// <summary>
        /// Method allows move camera using mouse dragging
        /// </summary>
        void HandleMouseInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                dragStartPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }

            if (isDragging)
            {
                Vector3 dragDelta = Input.mousePosition - dragStartPosition;
                dragStartPosition = Input.mousePosition;

                // Dostosuj przesunięcie kamery na podstawie przesunięcia myszy
                float newX = Mathf.Clamp(Camera.main.transform.position.x - dragDelta.x * 0.1f, minX, maxX);
                float newY = Mathf.Clamp(Camera.main.transform.position.y - dragDelta.y * 0.1f, minY, maxY);

                Camera.main.transform.position = new Vector3(newX, newY, Camera.main.transform.position.z);
            }
        }
    }
}