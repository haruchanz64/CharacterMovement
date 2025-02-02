using UnityEngine;

public class CCPlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isPlayerGrounded;
    private float movementSpeed = 12.0f;
    private float jumpHeight = 2.5f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the player is grounded
        isPlayerGrounded = characterController.isGrounded;

        // Reset vertical velocity if grounded
        if (isPlayerGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        // Debug.Log to check if the player is grounded (True / False)
        Debug.Log($"{gameObject.name} is grounded? {isPlayerGrounded}");

        // Handle horizontal movement
        var move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * movementSpeed);

        // Rotate the player to face the direction of movement
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // Apply gravity
        velocity.y += gravityValue * Time.deltaTime;

        // Move the character with the updated velocity
        characterController.Move(velocity * Time.deltaTime);
    }
}