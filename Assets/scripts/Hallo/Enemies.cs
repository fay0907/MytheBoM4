using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Enemies : MonoBehaviour
{
    internal int difficulty = DifficultyButton.difficulty;
    internal int wave;
    internal bool wavespawner = false;
    public static bool completed = false;

    public GameObject weakestenemy;
    public GameObject fastweakenemy;
    public GameObject weakenemy;
    public GameObject enemy;
    public GameObject fastenemy;
    public GameObject fasterenemy;
    public GameObject strongenemy;
    public GameObject boss1;

    private Dictionary<string, GameObject> enemyTypes;

    private void Start()
    {
        enemyTypes = new Dictionary<string, GameObject>
        {
            { "weakestenemy", weakestenemy },
            { "fastweakenemy", fastweakenemy },
            { "weakenemy", weakenemy },
            { "enemy", enemy },
            { "fastenemy", fastenemy },
            { "fasterenemy", fasterenemy },
            { "strongenemy", strongenemy },
            { "boss1", boss1 }
        };

        Debug.Log(difficulty);
    }

    private void Update()
    {
        if (difficulty == 1 && !wavespawner)
        {
            StartCoroutine(EasyMode());
        }
    }

    private IEnumerator EasyMode()
    {
        wavespawner = true;
        for (int i = 1; i <= 16; i++)
        {
            yield return StartCoroutine(SpawnWave(i));
        }
    }

    private IEnumerator SpawnWave(int waveNumber)
    {
        switch (waveNumber)
        {
            case 1:
                yield return SpawnEnemies("weakestenemy", new SpawnerState(3, 0, 5));
                break;
            case 2:
                yield return SpawnEnemies("weakestenemy", new SpawnerState(2, 0, 5));
                yield return SpawnEnemies("weakestenemy", new SpawnerState(0.5f, 0, 3));
                break;
            case 3:
                yield return SpawnEnemies("weakestenemy", new SpawnerState(2, 0, 6));
                yield return SpawnEnemies("weakestenemy", new SpawnerState(3, 0, 6));
                break;
            case 4:
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(1.5f, 0, 8));
                break;
            case 5:
                yield return SpawnEnemies("weakestenemy", new SpawnerState(1, 0, 10));
                break;
            case 6:
                yield return SpawnEnemies("weakenemy", new SpawnerState(4, 0, 3));
                break;
            case 7:
                yield return SpawnEnemies("weakestenemy", new SpawnerState(5, 0, 3));
                yield return SpawnEnemies("weakestenemy", new SpawnerState(2, 0, 10));
                break;
            case 8:
                yield return SpawnEnemies("weakenemy", new SpawnerState(2, 0, 6));
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(3, 0, 3));
                break;
            case 9:
                yield return SpawnEnemies("weakenemy", new SpawnerState(3, 0, 5));
                yield return SpawnEnemies("weakestenemy", new SpawnerState(1, 0, 8));
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(1, 0, 5));
                break;
            case 10:
                yield return SpawnEnemies("enemy", new SpawnerState(6, 0, 1));
                yield return SpawnEnemies("weakenemy", new SpawnerState(0.5f, 0, 8));
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(1, 0, 8));
                break;
            case 11:
                yield return SpawnEnemies("enemy", new SpawnerState(5, 0, 2));
                yield return SpawnEnemies("weakenemy", new SpawnerState(2, 0, 8));
                yield return SpawnEnemies("weakestenemy", new SpawnerState(0.2f, 0, 8));
                break;
            case 12:
                yield return SpawnEnemies("enemy", new SpawnerState(2, 0, 1));
                yield return SpawnEnemies("weakenemy", new SpawnerState(1, 0, 8));
                break;
            case 13:
                yield return SpawnEnemies("fastenemy", new SpawnerState(7, 0, 1));
                yield return SpawnEnemies("weakenemy", new SpawnerState(1, 0, 8));
                yield return SpawnEnemies("enemy", new SpawnerState(3, 0, 5));
                break;
            case 14:
                yield return SpawnEnemies("fasterenemy", new SpawnerState(6, 0, 2));
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(1, 0, 7));
                yield return SpawnEnemies("weakenemy", new SpawnerState(1.5f, 0, 5));
                break;
            case 15:
                yield return SpawnEnemies("enemy", new SpawnerState(1, 0, 3));
                yield return SpawnEnemies("fastenemy", new SpawnerState(8, 0, 2));
                yield return SpawnEnemies("weakenemy", new SpawnerState(1, 0, 12));
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(0.5f, 0, 15));
                break;
            case 16:
                yield return SpawnEnemies("strongenemy", new SpawnerState(1, 0, 1));
                completed = true;
                break;
        }
        wave++;
        Money.moneyvalue += 100 * waveNumber;
        Debug.Log("wave finished " + wave.ToString());
    }

    private IEnumerator SpawnEnemies(string enemyType, SpawnerState state)
    {
        if (!enemyTypes.ContainsKey(enemyType))
        {
            Debug.LogError("Enemy type not found: " + enemyType);
            yield break;
        }

        GameObject enemyPrefab = enemyTypes[enemyType];

        while (state.CurrentAmount < state.Total)
        {
            GameObject newEnemyObject = Instantiate(enemyPrefab);
            state.CurrentAmount++;

            if (newEnemyObject == null)
            {
                Debug.LogError("Failed to instantiate enemy prefab");
                yield break;
            }

            Enemy newEnemy = newEnemyObject.GetComponent<Enemy>();
            if (newEnemy == null)
            {
                Debug.LogError("Enemy component not found on instantiated prefab");
                yield break;
            }
            Debug.Log("enemy spawn amount: " + state.CurrentAmount.ToString() + " of total: " + state.Total.ToString());
            yield return new WaitForSeconds(state.Timer);
        }
    }
}

public class SpawnerState
{
    public float Timer { get; }
    public int CurrentAmount { get; set; }
    public int Total { get; }

    public SpawnerState(float timer, int currentAmount, int total)
    {
        Timer = timer;
        CurrentAmount = currentAmount;
        Total = total;
    }
}
