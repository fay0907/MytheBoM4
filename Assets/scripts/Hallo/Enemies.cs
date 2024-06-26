using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    internal int difficulty;
    internal int wave;
    internal bool wavespawner = false;
    public GameObject weakestenemy;
    public GameObject fastweakenemy;
    public GameObject weakenemy;
    public GameObject enemy;
    public GameObject fastenemy;
    public GameObject fasterenemy;
    public GameObject strongenemy;
    public GameObject boss1;

    private void Update()
    {
        if (difficulty == 0)
        {
            if (wave == 0 && wavespawner == false)
            {
                StartCoroutine(EnemySpawnerWave1());
            }
            else if (wave == 1 && wavespawner == false)
            {
                StartCoroutine(EnemySpawnerWave2());
            }
            else if (wave == 2 && wavespawner == false)
            {
                StartCoroutine(EnemySpawnerWave3());
            }
            else if (wave == 3 && wavespawner == false)
            {
                StartCoroutine(EnemySpawnerWave4());
            }
            else if (wave == 4 && wavespawner == false)
            {
                StartCoroutine(EnemySpawnerWave5());
            }
            else if (wave == 5 && wavespawner == false)
            {
                StartCoroutine(EnemySpawnerWave6());
            }
            else if (wave == 6 && wavespawner == false)
            {
                StartCoroutine(EnemySpawnerWave7());
            }
        }
    }

    private IEnumerator EnemySpawnerWave1()
    {
        wavespawner = true;
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(3, 0, 5)));
        yield return new WaitForSeconds(10);
        wave++;
        Money.moneyvalue += 100;
        Debug.Log("wave finished " + wave.ToString());
        wavespawner = false;
    }

    private IEnumerator EnemySpawnerWave2()
    {
        wavespawner = true;
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(2, 0, 5)));
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(0.5f, 0, 3)));
        yield return new WaitForSeconds(10);
        wave++;
        Money.moneyvalue += 100;
        wavespawner = false;
    }

    private IEnumerator EnemySpawnerWave3()
    {
        wavespawner = true;
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(2, 0, 6)));
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(3, 0, 6)));
        yield return new WaitForSeconds(10);
        wave++;
        Money.moneyvalue += 150;
        wavespawner = false;
    }

    private IEnumerator EnemySpawnerWave4()
    {
        wavespawner = true;
        yield return StartCoroutine(FastWeakEnemySpawner(new SpawnerState(1.5f, 0, 8)));
        yield return new WaitForSeconds(10);
        wave++;
        Money.moneyvalue += 150;
        wavespawner = false;
    }
    private IEnumerator EnemySpawnerWave5()
    {
        wavespawner = true;
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(1, 0, 10)));
        yield return new WaitForSeconds(12);
        wave++;
        Money.moneyvalue += 200;
        wavespawner = false;
    }
    private IEnumerator EnemySpawnerWave6()
    {
        wavespawner = true;
        yield return StartCoroutine(WeakEnemySpawner(new SpawnerState(4, 0, 3)));
        yield return new WaitForSeconds(10);
        wave++;
        Money.moneyvalue += 200;
        wavespawner = false;
    }
    private IEnumerator EnemySpawnerWave7()
    {
        wavespawner = true;
        StartCoroutine(WeakestEnemySpawner(new SpawnerState(5, 0, 3)));
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(2, 0, 10)));
        yield return new WaitForSeconds(11);
        wave++;
        Money.moneyvalue += 250;
        wavespawner = false;
    }

    private IEnumerator WeakestEnemySpawner(SpawnerState state)
    {
        while (state.CurrentAmount < state.Total)
        {
            GameObject newEnemyObject = Instantiate(weakestenemy);
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
            Debug.Log("enemy spawn amount: " + state.CurrentAmount.ToString() + "of total: " + state.Total.ToString());
            yield return new WaitForSeconds(state.Timer);
        }
    }

    private IEnumerator FastWeakEnemySpawner(SpawnerState state)
    {
        while (state.CurrentAmount < state.Total)
        {
            GameObject newEnemyObject = Instantiate(fastweakenemy);
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
            yield return new WaitForSeconds(state.Timer);
        }
    }
    private IEnumerator WeakEnemySpawner(SpawnerState state)
    {
        while (state.CurrentAmount < state.Total)
        {
            GameObject newEnemyObject = Instantiate(weakenemy);
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

    private IEnumerator EnemySpawner(SpawnerState state)
    {
        while (state.CurrentAmount < state.Total)
        {
            GameObject newEnemyObject = Instantiate(enemy);
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

    private IEnumerator FastEnemySpawner(SpawnerState state)
    {
        while (state.CurrentAmount < state.Total)
        {
            GameObject newEnemyObject = Instantiate(fastenemy);
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

    private IEnumerator FasterEnemySpawner(SpawnerState state)
    {
        while (state.CurrentAmount < state.Total)
        {
            GameObject newEnemyObject = Instantiate(fasterenemy);
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

    private IEnumerator StrongEnemySpawner(SpawnerState state)
    {
        while (state.CurrentAmount < state.Total)
        {
            GameObject newEnemyObject = Instantiate(strongenemy);
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

    private IEnumerator Boss1Spawner(SpawnerState state)
    {
        while (state.CurrentAmount < state.Total)
        {
            GameObject newEnemyObject = Instantiate(boss1);
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
