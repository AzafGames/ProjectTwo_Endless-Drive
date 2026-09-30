using UnityEngine;

public class spawnObjectMovement : MonoBehaviour
{
    private float speed = 15f;

    private int maxRangeZ = -100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z <= maxRangeZ)
        {
            Destroy(gameObject);
        }
    }
}
