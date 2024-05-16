using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    
    void Start()
    {
        // Instantiate clones of the enemy prefab
        for (emn.alive = 0; emn.alive < 2; emn.alive++) // Example: Instantiate 2 enemies
        {
            InstantiateEnemy();
        }
    }

    void InstantiateEnemy()
    {
        // Instantiate the enemy prefab at a random position
        Vector3 spawnPosition = new Vector3(Random.Range(0f, 4f), Random.Range(6f, 7f), 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}