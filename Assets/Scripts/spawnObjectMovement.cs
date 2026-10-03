
using UnityEngine;

public class spawnObjectMovement : MonoBehaviour
{
    // Movement speed
    [SerializeField] private float speed = 20f;

    // Z-axis cleanup boundary
    [SerializeField] private float maxRangeZ = -100f;

    // Reference to collisionChecker
    private collisionChecker collisionChecker;

    // Rigidbody reference
    private Rigidbody rb;


    private void Awake()
    {
        // Get Rigidbody attached to this object
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        // Stop movement when the game is over
        if (collisionChecker.isGameOver)
        {
            return;
        }

        // Calculate movement
        Vector3 movement = Vector3.back * speed * Time.fixedDeltaTime;

        // Move using Rigidbody physics
        rb.MovePosition(rb.position + movement);

        // Destroy object after passing the cleanup boundary
        if (rb.position.z <= maxRangeZ)
        {
            Destroy(gameObject);
        }
    }
}

