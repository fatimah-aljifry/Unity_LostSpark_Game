using UnityEngine;

public class StarController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component on the star
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input for movement (vertical) and rotation (horizontal)
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;

        // Use Rigidbody to move and rotate the star smoothly
        rb.MovePosition(transform.position + transform.forward * move);
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0f, turn, 0f));
    }
}

