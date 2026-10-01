using UnityEngine;

public class spawnManager : MonoBehaviour
{
    // Array to hold the prefabs to spawn (e.g., collectibles, obstacles)
    public GameObject[] spawnObject;

    // Fixed X positions (lanes) where objects can spawn
    private int[] fixedPos = { -3, 3 };

    // Initial delay before spawning starts (in seconds)
    private int startDelay = 1;

    // Time interval between consecutive spawns (in seconds)
    private int spawnInterval = 1;

    // Fixed Y and Z coordinates for spawning objects
    private int spawnPosY = 1;
    private int spawnPosZ = -60;

    // Reference to the collisionChecker script to check game state
    private collisionChecker collisionChecker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Repeatedly calls the SpawnRandomObject method starting after startDelay seconds
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Custom method to spawn a random object at a random lane position
    void SpawnRandomObject()
    {
        // Only spawn objects if the game is NOT over
        if (collisionChecker.isGameOver == false)
        {
            // Pick a random object from the spawnObject array
            int objectIndex = Random.Range(0, spawnObject.Length);

            // Pick a random lane index from the fixedPos array
            int randomPosIndex = Random.Range(0, fixedPos.Length);

            // Combine chosen X position with fixed Y and Z coordinates
            Vector3 randomPos = new Vector3(fixedPos[randomPosIndex], spawnPosY, spawnPosZ);

            // Create (spawn) the selected prefab at the calculated position and default rotation
            Instantiate(spawnObject[objectIndex], randomPos, spawnObject[objectIndex].transform.rotation);
        }
    }
}