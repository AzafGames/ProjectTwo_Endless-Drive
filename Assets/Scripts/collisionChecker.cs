using UnityEngine;

public class collisionChecker : MonoBehaviour
{
    // Global flag to track if the game is over across all scripts
    public static bool isGameOver = false;

    // Keeps track of the total collected points (persists across collisions)
    private int i = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Runs automatically whenever this GameObject collides with another 3D object
    private void OnCollisionEnter(Collision other)
    {
        // Check if the object we hit has the "Collectible" tag
        if (other.gameObject.CompareTag("Collectible"))
        {
            // Remove the collectible object from the scene
            Destroy(other.gameObject);

            // Increase point count by 1
            i++;

            // Print the updated point total to the Console
            Debug.Log(i + " point collected");
        }
        // Check if the object we hit has the "Obstacle" tag
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            // Destroy both the player object and the obstacle
            Destroy(gameObject);
            Destroy(other.gameObject);

            // Display Game Over in the Console and update the game over status
            Debug.Log("Game Over!");
            isGameOver = true;
        }
    }
}