using UnityEngine;

public class spawnObjectMovement : MonoBehaviour
{
    // Speed at which the spawned object moves backward (units per second)
    private float speed = 20f;

    // The Z-axis distance limit before the object gets removed from the scene
    private int maxRangeZ = -100;

    // Reference to the collisionChecker script to check if the game is active
    public collisionChecker collisionChecker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialization logic can be placed here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Only move the spawned object while the game is NOT over
        if (collisionChecker.isGameOver == false)
        {
            // Move the object backward smoothly in world space using DeltaTime for frame-rate independence
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            
        }

        // Check if the object has moved past the backward cleanup boundary line
        if (transform.position.z <= maxRangeZ)
        {
            // Destroy this GameObject to keep the scene hierarchy clean and free up memory
            Destroy(gameObject);
        }
    }
}