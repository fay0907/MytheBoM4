using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab

    void Start()
    {
        // Instantiate clones of the enemy prefab
        for (int i = 0; i < 5; i++) // Example: Instantiate 5 enemies
        {
            InstantiateEnemy();
        }
    }

    void InstantiateEnemy()
    {
        // Instantiate the enemy prefab at a random position
        Vector3 spawnPosition = new Vector3(Random.Range(0f, 4f), Random.Range(6f, 6f), 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}