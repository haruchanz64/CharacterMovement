using UnityEngine;

public class RBPlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float movementSpeed = 12.0f;
    private float jumpHeight = 2.5f;
    private float groundCheckDistance = 1.1f; // Distance to check for ground
    private LayerMask groundLayer; // Layer for ground detection

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent the Rigidbody from rotation
        rb.interpolation = RigidbodyInterpolation.Interpolate; // Enable interpolation for smooth movement.
        groundLayer = LayerMask.GetMask("Ground"); // Set the ground layer (make sure to set this in the Inspector)
    }

    private void FixedUpdate()
    {
        // Check if the player is grounded
        bool isPlayerGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        // Handle horizontal movement
        var move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        var moveDirection = move * movementSpeed;

        // Rotate the player to face the direction of the movement
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Apply movement force
        rb.AddForce(moveDirection, ForceMode.Acceleration);

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerGrounded)
        {
            // Calculate jump force
            float jumpForce = Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }
}