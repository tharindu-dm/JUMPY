using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private PlayerController playerControllerScript;

    public GameObject SlantPlatformPrefab;
    public GameObject ShortFlatPlatformPrefab;
    public GameObject LongFlatPlatformPrefab;
    public GameObject TallFlatPlatformPrefab;
    public GameObject ObstaclePrefab;

    private float startDelay = 0f;
    private float repeatRate = 0.5f;
    private bool lastWasSlant = false;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnPlatform", startDelay, repeatRate);
    }

    private void Update()
    {
    }

    private void SpawnPlatform()
    {
        if (playerControllerScript.gameOver == false)
        {
            GameObject platformToSpawn = ChoosePlatform();
            Vector3 spawnPosition = GetSpawnPosition(platformToSpawn);

            // Instantiate the platform at the calculated position
            Instantiate(platformToSpawn, spawnPosition, Quaternion.identity);

            // Randomly spawn an obstacle if the platform is LongFlat
            if (platformToSpawn == LongFlatPlatformPrefab)
            {
                SpawnObstacle(spawnPosition);
            }
        }
    }

    private GameObject ChoosePlatform()
    {
        // Randomly choose a platform type
        int randomValue = Random.Range(0, 100);
        GameObject platform;

        if (lastWasSlant)
        {
            // If the last platform was a slant, avoid spawning a tall platform
            platform = Random.Range(0, 100) < 20 ? ShortFlatPlatformPrefab : LongFlatPlatformPrefab; // 20% chance for ShortFlat
            lastWasSlant = false; // Reset the flag
        }
        else
        {
            // Randomly choose a platform type with slants being rare
            if (Random.Range(0, 100) < 10) // 10% chance for Slant
            {
                platform = SlantPlatformPrefab;
                lastWasSlant = true; // Set the flag
            }
            else
            {
                // 70% chance for LongFlat, 30% for ShortFlat or TallFlat
                int platformChoice = Random.Range(0, 100);
                if (platformChoice < 70)
                {
                    platform = LongFlatPlatformPrefab;
                }
                else
                {
                    platform = Random.Range(0, 100) < 50 ? ShortFlatPlatformPrefab : TallFlatPlatformPrefab; // 50% chance for ShortFlat or TallFlat
                }
            }
        }

        return platform;
    }

    private Vector3 GetSpawnPosition(GameObject platform)
    {
        // Define the spawn position based on the platform type
        Vector3 spawnPosition = new Vector3(9, -1, 0); // Replace with your logic to determine the spawn position

        // Example logic to create gaps between platforms
        float gap = Random.Range(3.0f, 5.5f); // Random gap
        spawnPosition.x -= gap; // Adjust the Y position for the gap

        // Adjust the spawn position based on the platform's height
        if (platform == ShortFlatPlatformPrefab)
        {
            spawnPosition.z += 6.0f; // Adjust for ShortFlat height
        }
        else if (platform == LongFlatPlatformPrefab)
        {
            spawnPosition.z += 6.0f; // Adjust for LongFlat height
        }
        else if (platform == TallFlatPlatformPrefab)
        {
            spawnPosition.z += 5.0f; // Adjust for TallFlat height
        }
        else if (platform == SlantPlatformPrefab)
        {
            spawnPosition.y += 1.3f; // Adjust for Slant height
            spawnPosition.z += 8.5f;
        }

        return spawnPosition;
    }

    private void SpawnObstacle(Vector3 platformPosition)
    {
        //9,-1,0
        // Randomly place the obstacle on the LongFlat platform
        float obstacleOffset = Random.Range(1.0f, 3.0f); // Random offset for obstacle placement
        Vector3 obstaclePosition = new Vector3(platformPosition.x + obstacleOffset -9f, platformPosition.y + 4.5f, platformPosition.z -2f); // Adjust the Y position for the obstacle

        Instantiate(ObstaclePrefab, obstaclePosition, Quaternion.identity);
    }
}