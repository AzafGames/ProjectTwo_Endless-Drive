using UnityEngine;

public class carWheelRotation : MonoBehaviour
{
    private float rotationSpeed = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed, 0, 0);
    }
}
