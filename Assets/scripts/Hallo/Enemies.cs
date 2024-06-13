using System.Collections;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    bool working = false;

    void Start()
    {
        // No initialization needed in Start if using Coroutine for spawning
    }

    void Update()
    {
        if (!working)
        {
            StartCoroutine(enemyspawner());
        }
    }

    IEnumerator enemyspawner()
    {
        working = true;

        // Instantiate the enemy prefab
        GameObject newEnemyObject = Instantiate(enemyPrefab);
        if (newEnemyObject == null)
        {
            Debug.LogError("Failed to instantiate enemy prefab");
            working = false;
            yield break;
        }
        // Access the Enemy component attached to the instantiated GameObject
        Enemy newEnemy = newEnemyObject.GetComponent<Enemy>();
        
            yield return new WaitForSeconds(3);
            working = false;
    }
}