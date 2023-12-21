using UnityEngine;

namespace Game
{
    /// <summary>
    /// Controls the camera's movement and rotation based on player input.
    /// </summary>
    public class CameraController : MonoBehaviour
    {/*
        /// <summary>
        /// The speed at which the camera moves.
        /// </summary>
        public float moveSpeed = 550.0f;

        /// <summary>
        /// The speed at which the camera rotates.
        /// </summary>
        public float rotationSpeed = 15.0f;

        /// <summary>
        /// Update is called once per frame to handle camera movement and rotation.
        /// </summary>
        private void Update()
        {
            //if (!GameBoardController.Instance.canWalk) return;

            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");

            var moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            transform.Translate(moveDirection * (moveSpeed * Time.deltaTime));

            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
        }*/

        private bool isDragging = false;
        private Vector3 dragStartPosition;

        // Ograniczenia kamery
        public float minX = 0f;
        public float maxX = 120f;
        public float minY = 15f;
        public float maxY = 40f;

        void Update()
        {
            HandleMouseInput();
        }

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