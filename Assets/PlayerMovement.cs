using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f; // Degrees per second for yaw rotation
    public float verticalSpeed = 5f;   // Speed for up/down movement

    private Vector2 moveInput;  // For horizontal movement (X, Z)
    private Vector2 mouseInput; // For rotation (X for yaw)
    private InputSystem_Actions controls;

    void Awake()
    {
        controls = new InputSystem_Actions();
        if (controls != null)
        {
            // Movement input (WASD or Arrow keys)
            controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
            controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

            // Mouse look input (only X for yaw)
            controls.Player.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
            controls.Player.Look.canceled += ctx => mouseInput = Vector2.zero;

            controls.Player.Enable();
        }
        else
        {
            Debug.LogError("Controls failed to initialize in PlayerMovement!");
        }
    }

    void OnDisable()
    {
        if (controls != null) controls.Player.Disable();
    }

    void Update()
    {
        // Horizontal movement only (X and Z)
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y).normalized * moveSpeed * Time.deltaTime;

        // Vertical movement (Y axis)
        float vertical = 0f;
        if (Keyboard.current.spaceKey.isPressed)
            vertical += 1f;
        if (Keyboard.current.leftShiftKey.isPressed)
            vertical -= 1f;

        Vector3 verticalMovement = new Vector3(0, vertical * verticalSpeed * Time.deltaTime, 0);

        // Apply combined movement
        transform.Translate(movement + verticalMovement, Space.Self);

        // Rotation (yaw only, using mouse X)
        float yaw = mouseInput.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, yaw, 0, Space.World);
    }
    public IEnumerator ApplySpeedBoost(float boostAmount, float duration)
    {
        float originalSpeed = moveSpeed;

        // Apply speed boost and change color
        moveSpeed += boostAmount;

        yield return new WaitForSeconds(duration);

        // Revert speed and color
        moveSpeed = originalSpeed;
    }
}