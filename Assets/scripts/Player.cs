using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed = 5;

    private Rigidbody2D rb2D; // Reference to the Rigidbody2D component
    private float move; // Variable to store horizontal movement input
    public float jumpForce = 5; // Force applied when jumping
    private bool isGrounded; // Flag to check if the player is on the ground
    public Transform groundCheck; // Transform used to check if the player is grounded
    public float groundRadius = 0.1f;
    public LayerMask groundLayer; // Layer mask for the ground

    public Animator animator; // Reference to the Animator component
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y); // Set the velocity of the Rigidbody2D based on input and speed
    
        if (Input.GetButtonDown("Jump") && isGrounded) // Check if the jump button is pressed and the player is grounded
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce); // Apply jump force to the Rigidbody2D
        }
        
        if (move != 0){ // Check if there is horizontal movement input
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1); // Flip the player's sprite based on movement direction
        }
        animator.SetFloat("speed", Mathf.Abs(move)); // Update the "Speed" parameter in the Animator based on the absolute value of movement input
        animator.SetFloat("VerticalVelocity", rb2D.linearVelocity.y); // Update the "Verticalvelocity" parameter in the Animator based on the vertical velocity
        animator.SetBool("isGrounded", isGrounded); // Update the "isGrounded" parameter in the Animator based on whether the player is grounded

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer); // Check if the player is grounded using a circle overlap
    }
}
