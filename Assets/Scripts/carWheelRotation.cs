using UnityEngine;

public class carWheelRotation : MonoBehaviour
{
    // Speed at which the wheel rotates on its X-axis
    private float rotationSpeed = 15;
    public collisionChecker collisionChecker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotates the wheel around the X-axis every frame
        if (collisionChecker.isGameOver == false)
        {
            transform.Rotate(rotationSpeed, 0, 0);
        }
    }
}