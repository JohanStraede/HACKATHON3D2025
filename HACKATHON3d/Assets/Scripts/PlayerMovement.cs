using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float speed;// Speed of the player movement
public float yspeed;

    public float jumpForce; // Jump force of the player
    //private float gravity = -20f; // Gravity value


    private CharacterController controller; // Reference to the CharacterController component
    private Vector3 velocity; // Velocity of the player
    public bool isGrounded; // Flag to check if the player is grounded


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        isGrounded = true; // Initialize the grounded flag to true
        //controller = GetComponent<CharacterController>(); // Get the CharacterController component attached to the player   
    }

    /*void FixedUpdate()
    { 
       float h = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
         float v = Input.GetAxis("Vertical"); // Get vertical input (W/S or Up/Down arrow keys)
          Vector3 moveDirrection = h *transform.forward * v; // Create a movement vector based on input
          moveDirrection.Normalize(); // Normalize the movement vector to ensure consistent speed in all directions
          controller.Move(moveDirrection * speed * Time.deltaTime); // Move the player using the CharacterController
    
       
        if (controller.isGrounded && velocity.y < 0f) // If the player is grounded and the vertical speed is less than 0
            velocity.y = -1f; // Set the vertical speed to a small negative value
        
       if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) // Check if the jump key is pressed and the player is grounded
        {
            velocity.y = jumpForce; // Apply jump force
            //isGrounded = false; // Set the grounded flag to false
        }
        //velocity.y += gravity * Time.deltaTime; // Apply gravity to the vertical speed
        //controller.Move(velocity * Time.deltaTime); // Move the player using the CharacterController
     }*/

    // Update is called once per frame 

    void OnCollisionEnter(Collision collision)
    {
        
    }
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        float verticalMovement = Input.GetAxis("Vertical"); // Get vertical input (W/S or Up/Down arrow keys)

        Vector3 moveDirrection = new Vector3(horizontalMovement, 0, 0); // Create a movement vector based on input
        transform.position += moveDirrection * speed * Time.deltaTime;
        //moveDirrection.Normalize(); // Normalize the movement vector to ensure consistent speed in all directions
        //controller.SimpleMove(moveDirrection * speed); // Move the player using the CharacterController

        //ySpeed += Physics.gravity.y * Time.deltaTime; // Apply gravity to the vertical speed
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) 
        {
            yspeed =  4f; 
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * yspeed, ForceMode.Impulse); // Apply jump force
            isGrounded = false; // Set the grounded flag to flase
        }else if (isGrounded == false && !Input.GetKeyDown(KeyCode.Space))
        {
            yspeed = 0;
        }

        Vector3 vel = moveDirrection * speed; 
        //vel.y = yspeed; // Set the vertical speed
        //transform.position += vel * Time.deltaTime; // Update the player's position based on the velocity
        //controller.Move(vel * Time.deltaTime); // Move the player using the CharacterController

        /*if (controller.isGrounded) // Check if the player is grounded
        {
            ySpeed = -0.5f; // Reset vertical speed if grounded
            isGrounded = true; // Set the grounded flag to true
            if (Input.GetKeyDown(KeyCode.Space)) // Check if the jump key is pressed
            {
                ySpeed = jumpForce; // Apply jump force
                isGrounded = false; // Set the grounded flag to false
            }
        }*/
    }
    
        
}
