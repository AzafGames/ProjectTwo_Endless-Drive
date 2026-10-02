using UnityEngine;

public class collisionChecker : MonoBehaviour
{
    // Global flag to track if the game is over across all scripts
    public static bool isGameOver = false;

    // Keeps track of the total collected points (persists across collisions)
    public static int score = 0;

    // Particle effect references assigned via the Inspector
    public ParticleSystem explosionEffect;
    public ParticleSystem coinCollectEffect;

    // Audio components for playing sound effects
    public AudioSource audioSource;
    public AudioClip coinCollectSound;
    public AudioClip explosionSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get and store the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Runs automatically whenever this GameObject collides with another 3D object
    private void OnCollisionEnter(Collision other)
    {
        // Check if the object we hit has the "Collectible" tag and the game is still active
        if (other.gameObject.CompareTag("Collectible") && isGameOver == false)
        {
            // Remove the collectible object from the scene
            Destroy(other.gameObject);

            // Play the visual collection particle effect
            coinCollectEffect.Play();

            // Play the coin pickup audio clip once at full volume
            audioSource.PlayOneShot(coinCollectSound, 1.0f);

            // Increase point count by 1
            score++;
        }
        // Check if the object we hit has the "Obstacle" tag
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            // Destroy the obstacle object
            Destroy(other.gameObject);

            // Trigger the explosion visual particle effect
            explosionEffect.Play();

            // Play the explosion sound effect at full volume
            audioSource.PlayOneShot(explosionSound, 1.0f);

            // Set the global game state flag to true to end the game
            isGameOver = true;
        }
    }
}