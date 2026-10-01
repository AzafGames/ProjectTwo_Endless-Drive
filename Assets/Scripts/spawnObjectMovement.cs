using UnityEngine;

public class spawnObjectMovement : MonoBehaviour
{
    // Speed at which the spawned object moves backward
    private float speed = 15f;

    // The Z-axis distance limit before the object gets removed from the scene
    private int maxRangeZ = -100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the object backward smoothly every frame
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Check if the object has moved past the backward boundary
        if (transform.position.z <= maxRangeZ)
        {
            // Destroy this spawned object to keep the scene clean and save memory
            Destroy(gameObject);
        }
    }
}