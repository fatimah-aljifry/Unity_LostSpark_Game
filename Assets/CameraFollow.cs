using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float distance = 3f;         // Fixed distance from player
    public float rotationSpeed = 100f;  // Degrees per second for camera rotation
    public float maxPitch = 80f;        // Limit up/down rotation

    private Vector2 mouseInput;         // Mouse input for rotation
    private float yaw = 0f;             // Horizontal angle (left/right rotation)
    private float pitch = -15f;          // Vertical angle (start slightly above)
    private InputSystem_Actions controls;

    void Awake()
    {
        controls = new InputSystem_Actions();
        controls.Player.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += ctx => mouseInput = Vector2.zero;
    }

    void OnEnable() => controls.Player.Enable();
    void OnDisable() => controls.Player.Disable();

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is not assigned in CameraFollow!");
            return;
        }

        // Update only yaw (horizontal rotation) based on mouse X input
        yaw += mouseInput.x * rotationSpeed * Time.deltaTime;

        // Remove vertical movement or limit pitch to prevent up/down rotation
        // pitch -= mouseInput.y * rotationSpeed * Time.deltaTime; // Remove this line for no vertical rotation
        // pitch = Mathf.Clamp(pitch, -maxPitch, maxPitch);       // Remove or keep to limit vertical tilt

        // Calculate camera position using spherical coordinates (adjusted for behind the player)
        Vector3 offset = new Vector3(
            Mathf.Sin(yaw * Mathf.Deg2Rad) * Mathf.Cos(pitch * Mathf.Deg2Rad),
            Mathf.Sin(pitch * Mathf.Deg2Rad),
            Mathf.Cos(yaw * Mathf.Deg2Rad) * Mathf.Cos(pitch * Mathf.Deg2Rad)
        ).normalized * distance;

        // Adjust the camera to be behind the player
        transform.position = player.position - offset; // Change to subtract offset to be behind
        transform.LookAt(player);
    }
}