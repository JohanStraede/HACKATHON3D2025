using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // Speed of the player movement
    public float jumpForce; // Jump force of the player
    public LayerMask groundLayer; // Layer mask for the ground

    private bool isGrounded; // Flag to check if the player is grounded

    void Start()
    {
        isGrounded = false; // Initialize the grounded flag to false
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name + ", Layer: " + collision.gameObject.layer);

        // Check if the collided object is in the "Ground" layer
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true; // Set the grounded flag to true
            Debug.Log("Player is grounded.");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exited collision with: " + collision.gameObject.name + ", Layer: " + collision.gameObject.layer);

        // Check if the exited object is in the "Ground" layer
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false; // Set the grounded flag to false
            Debug.Log("Player is not grounded.");
        }
    }

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal"); // Get horizontal input
        Vector3 moveDirection = new Vector3(horizontalMovement, 0, 0); // Create a movement vector
        transform.position += moveDirection * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && isGrounded) // Check if jump key is pressed and player is grounded
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply jump force
        }
    }
}