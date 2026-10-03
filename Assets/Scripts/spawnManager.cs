
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Objects that can be spawned
    [SerializeField] private GameObject[] spawnObjects;

    // Available X positions / lanes
    private readonly int[] fixedPos = { -3, 3 };

    // Spawn settings
    private float startDelay = 1f;
    private float spawnInterval = 1f;

    // Spawn position
    private float spawnPosY = 1f;
    private float spawnPosZ = -60f;

    // Reference to collisionChecker
    private collisionChecker collisionChecker;


    private void OnEnable()
    {
        // Start spawning when this object becomes enabled
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
    }


    private void OnDisable()
    {
        // Stop spawning when this object becomes disabled
        CancelInvoke("SpawnRandomObject");
    }


    private void SpawnRandomObject()
    {
        // Don't spawn if the game is over
        if (collisionChecker.isGameOver)
        {
            return;
        }

        // Select random prefab
        int objectIndex = Random.Range(0, spawnObjects.Length);

        // Select random lane
        int randomPosIndex = Random.Range(0, fixedPos.Length);

        // Create spawn position
        Vector3 spawnPosition = new Vector3(
            fixedPos[randomPosIndex],
            spawnPosY,
            spawnPosZ
        );

        // Spawn object
        Instantiate(
            spawnObjects[objectIndex],
            spawnPosition,
            spawnObjects[objectIndex].transform.rotation
        );
    }
}
