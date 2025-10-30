using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    // Movement settings
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float rotationSpeed = 5f;
    public float gravity = -9.8f;
    private Vector3 velocity;

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 100f;
    public Transform cameraTransform; // Use this for FPS camera
    private float xRotation = 0f;

    // Components
    private CharacterController characterController;
    private Camera mainCamera;

    // Movement control
    public float mouseInputDelay = 1f;
    public bool IsMoveable = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;

        // Lock cursor to center
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (IsMoveable)
        {
            HandleMovement();
            HandleMouseLook();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * currentSpeed * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        // Reset Y velocity when grounded
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void HandleMouseLook()
    {
        // Get raw mouse input (standard FPS control)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertical rotation (look up/down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotations
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // up/down (camera only)
        transform.Rotate(Vector3.up * mouseX); // left/right (player body)
    }
}
