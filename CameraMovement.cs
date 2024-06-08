using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 200f;

    private float xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen
        // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse movement input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player body based on the horizontal mouse movement
        playerBody.Rotate(Vector3.up * mouseX);

        // Calculate the new vertical rotation for the camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 80f); // Prevent the camera from flipping over

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
