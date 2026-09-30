using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] spawnObject;

    private int[] fixedPos = { -3, 3 };

    private int startDelay = 1;
    private int spawnInterval = 1;

    private int spawnPosY = 1;
    private int spawnPosZ = -60;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    
    void SpawnRandomObject()
    {
        int objectIndex = Random.Range(0, spawnObject.Length);
        int randomPosIndex = Random.Range(0, fixedPos.Length);

        Vector3 randomPos = new Vector3(fixedPos[randomPosIndex], spawnPosY, spawnPosZ);

        Instantiate(spawnObject[objectIndex], randomPos, spawnObject[objectIndex].transform.rotation);


    }
}
