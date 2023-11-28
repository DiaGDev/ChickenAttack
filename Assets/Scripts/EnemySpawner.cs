using UnityEngine;
using Pathfinding;
using Mono.Cecil.Cil;
using System;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;

public class EnemySpawner : MonoBehaviour
{
    // The enemy prefab to be spawned
    public GameObject enemyPrefab;

    // The point where the enemies will be spawned
    public Transform spawnPoint;

    // The player object to follow
    public Transform player;

    // The number of enemies to spawn
    public int numberOfEnemies = 10;

    // The time between each spawn
    public float spawnTime = 20f;

    void Start()
    {
        // Start spawning enemies every 20 seconds
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);
    }

    void SpawnEnemy()
    {
        // Spawn the enemies
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Instantiate the enemy prefab at the spawn point
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Set the enemy's parent to this spawner object
            enemy.transform.SetParent(transform);

            // Get the AIDestinationSetter component on the enemy object
            AIDestinationSetter destinationSetter = enemy.GetComponent<AIDestinationSetter>();

            // Set the target of the AIDestinationSetter to follow the player
            if (destinationSetter != null && player != null)
            {
                destinationSetter.target = player;
            }
        }
    }
}




