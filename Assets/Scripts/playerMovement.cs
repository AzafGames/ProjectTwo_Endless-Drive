using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    // Movement speed of the player
    private float speed = 15;

    // Input Action field to map controls (e.g., WASD / Arrow keys) in the Inspector
    public InputAction moveKey;

    // Stores the directional input vector read from the input action
    private Vector2 moveAction;

    // Reference to the player's Rigidbody component for physics movement
    private Rigidbody rb;

    // Left and right movement limit along the X-axis
    private float xRange = 4.7f;

    // Reference to the collisionChecker script to monitor game state
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // Get and store the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    { 

      // Enable input action
      moveKey.Enable(); 

    }

    private void OnDisable()
    {
        moveKey.Disable();
    }

    private void Update()
    { 
      
      // Read player input
      moveAction = moveKey.ReadValue<Vector2>(); 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Stop movement when the game has not started
        if (!GameManager.isStartButtonClicked)
        {
            return;
        }

        // Get current position
        Vector3 position = transform.position;

        // Apply horizontal movement only while the game is NOT over
        position.x += speed * Time.deltaTime * moveAction.x;

        // Keep player inside the X boundaries
        position.x = Mathf.Clamp(position.x, -xRange, xRange);

        //Move using Rigidbody physics
        rb.MovePosition(position);
    }
}
