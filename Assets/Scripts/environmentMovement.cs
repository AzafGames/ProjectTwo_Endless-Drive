using UnityEngine;

public class environmentMovement : MonoBehaviour
{
    private float speed = 15f;

    private float startPos = 312;

    private int maxRangeZ = -24;
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
            transform.position = new Vector3(transform.position.x, transform.position.y, startPos);
        }
    }
}
