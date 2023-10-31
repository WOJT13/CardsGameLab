using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the camera movement speed
    public float rotationSpeed = 3.0f; // Adjust the camera rotation speed

    void Update()
    {
        // Move the camera with arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Rotate the camera with Q and E keys
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}

