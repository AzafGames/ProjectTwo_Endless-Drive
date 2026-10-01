using UnityEngine;

public class detectCollisions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            int i = 1;
            Debug.Log(i + " point collected");
            i++;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Game Over!");
        }
        
    }
}
