using UnityEngine;

public class environmentMovement : MonoBehaviour
{
    // Speed at which the environment moves backward (units per second)
    private float speed = 20f;

    // The Z position to reset the environment back to for endless scrolling
    private float startPos = 312f;

    // The Z threshold position that triggers the reset once crossed
    private int maxRangeZ = -24;

    // Reference to the collisionChecker component/script to monitor game state
    public collisionChecker collisionChecker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Only move the environment forward/backward while the game is actively running
        if (collisionChecker.isGameOver == false)
        {
            // Move the environment object backward over time in world space at a constant rate
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        // Check if the environment position has scrolled past the backward boundary line
        if (transform.position.z <= maxRangeZ)
        {
            // Reset the Z coordinate to startPos to create a seamless looping effect
            transform.position = new Vector3(transform.position.x, transform.position.y, startPos);
        }
    }
}