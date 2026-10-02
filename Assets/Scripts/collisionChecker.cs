using UnityEngine;

public class collisionChecker : MonoBehaviour
{
    // Global flag to track if the game is over across all scripts
    public static bool isGameOver = false;

    // Keeps track of the total collected points (persists across collisions)
    public static int score = 0;

    public ParticleSystem explosionEffect;
    public ParticleSystem coinCollectEffect;

    public AudioSource audioSource;
    public AudioClip coinCollectSound;
    public AudioClip explosionSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Runs automatically whenever this GameObject collides with another 3D object
    private void OnCollisionEnter(Collision other)
    {
        // Check if the object we hit has the "Collectible" tag
        if (other.gameObject.CompareTag("Collectible") && isGameOver == false)
        {
            // Remove the collectible object from the scene
            Destroy(other.gameObject);

            coinCollectEffect.Play();
            audioSource.PlayOneShot(coinCollectSound, 1.0f);

            // Increase point count by 1
            score++;

            // Print the updated point total to the Console
            Debug.Log(score + " point collected");
        }
        // Check if the object we hit has the "Obstacle" tag
        else if (other.gameObject.CompareTag("Obstacle"))
        {
 
            // Destroy the obstacle
            Destroy(other.gameObject);

            explosionEffect.Play();
            audioSource.PlayOneShot(explosionSound, 1.0f);

            // Display Game Over in the Console and update the game over status
            Debug.Log("Game Over!");
            isGameOver = true;
        }
    }
}