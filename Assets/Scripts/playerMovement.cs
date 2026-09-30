using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private float speed = 15;
    public InputAction moveKey;
    private Vector2 moveAction;

    private float xRange = 4.7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveKey.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Read keyboard/controller input
        moveAction = moveKey.ReadValue<Vector2>();

        // Get current position
        Vector3 position = transform.position;

        // Apply movement
        position.x += speed * Time.deltaTime * moveAction.x;

        // Keep player inside the X boundaries
        position.x = Mathf.Clamp(position.x, -xRange, xRange);

        // Apply final position
        transform.position = position;
    }
}
