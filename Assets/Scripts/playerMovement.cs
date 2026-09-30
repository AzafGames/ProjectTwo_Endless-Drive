using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private float speed = 15;
    public InputAction moveKey;
    private Vector2 moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveKey.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveAction = moveKey.ReadValue<Vector2>();

        transform.Translate(Vector3.right * speed * Time.deltaTime * moveAction.x);

    }
}
