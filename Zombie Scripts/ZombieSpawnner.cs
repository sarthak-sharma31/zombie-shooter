using UnityEngine;

public class ZombieSpawnner : MonoBehaviour
{
    public GameObject zombiePrefab; // Reference to the zombie prefab
    public Transform player; // Reference to the player
    public float spawnInterval = 3.0f; // Time interval between spawns
    public float spawnRadius = 10.0f; // Radius around the spawner where zombies will appear
    public float EnemyCount = 5f;
    float SpawnedUnits = 0f;

    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval; // Initialize the spawn timer
    }

    void Update()
    {
        // Update the spawn timer
        spawnTimer -= Time.deltaTime;

        if (SpawnedUnits <= EnemyCount){
            // Check if it's time to spawn a new zombie
            if (spawnTimer <= 0)
            {
                SpawnZombie();
                SpawnedUnits += 1;
                spawnTimer = spawnInterval; // Reset the spawn timer
            }
        }
    }

    void SpawnZombie()
    {
        // Calculate a random position within the spawn radius
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0; // Keep the y-coordinate the same to spawn on the ground

        // Instantiate a new zombie at the calculated position
        GameObject zombie = Instantiate(zombiePrefab, transform.position + spawnPosition, Quaternion.identity);

        // Set the zombie's player reference
        ZombieMovement zombieMovement = zombie.GetComponent<ZombieMovement>();
        if (zombieMovement != null)
        {
            zombieMovement.player = player;
        }
    }
}
