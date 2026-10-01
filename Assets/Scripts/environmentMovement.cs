using UnityEngine;

public class environmentMovement : MonoBehaviour
{
    // Speed at which the environment moves backward
    private float speed = 15f;

    // The Z position to reset the environment back to for endless scrolling
    private float startPos = 312;

    // The Z threshold position that triggers the reset
    private int maxRangeZ = -24;

    // Reference to the collisionChecker script to check game state
    public collisionChecker collisionChecker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Only move the environment while the game is NOT over
        if (collisionChecker.isGameOver == false)
        {
            // Move the environment backward over time at a constant speed
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        // Check if the environment has moved past the backward limit
        if (transform.position.z <= maxRangeZ)
        {
            // Loop the environment by resetting its Z position back to startPos
            transform.position = new Vector3(transform.position.x, transform.position.y, startPos);
        }
    }
}