using UnityEngine;

public class carWheelRotation : MonoBehaviour
{
    // Speed at which the wheel rotates around its X-axis per frame
    private float rotationSpeed = 15f;

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
        // Check if the game is still running before executing movement
        if (collisionChecker.isGameOver == false)
        {
            // Rotate the wheel around its local X-axis based on rotationSpeed
            transform.Rotate(rotationSpeed, 0, 0);
        }
    }
}