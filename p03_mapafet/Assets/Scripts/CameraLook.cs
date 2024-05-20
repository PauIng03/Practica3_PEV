using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float zoomSpeed = 5f;
    public float maxZoom = 20f;
    public float minZoom = 0f;

    public Transform playerBody;

    float xRotation = 0;
    Camera mainCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainCamera = GetComponent<Camera>();

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelInput != 0)
        {
            Debug.Log(scrollWheelInput);
            float newFOV = mainCamera.fieldOfView - scrollWheelInput * zoomSpeed;
            newFOV = Mathf.Clamp(newFOV, minZoom, maxZoom);
            mainCamera.fieldOfView = newFOV;
        }
    }
}

