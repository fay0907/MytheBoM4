using System.Collections;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    bool working = false;

    void Start()
    {
        Debug.Log("enemyprefab " + enemyPrefab.name);
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
            yield break;
        }

        // Access the Enemy component attached to the instantiated GameObject
        Enemy newEnemy = newEnemyObject.GetComponent<Enemy>();
        if (newEnemy == null)
        {
            Debug.LogError("Enemy component not found on instantiated prefab");
            yield break;
        }

        yield return new WaitForSeconds(2);
        working = false;
    }
}
