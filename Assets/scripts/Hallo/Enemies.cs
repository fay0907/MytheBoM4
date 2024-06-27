using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public static int difficulty;
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
        if (difficulty == 0 && wavespawner == false)
        {
            StartCoroutine(EasyMode());
          
        }
    }
    private IEnumerator EasyMode()
    {
        wavespawner = true;
        yield return StartCoroutine(EnemySpawnerWave1());
        yield return StartCoroutine(EnemySpawnerWave2());
        yield return StartCoroutine(EnemySpawnerWave3());
        yield return StartCoroutine(EnemySpawnerWave4());
        yield return StartCoroutine(EnemySpawnerWave5());
        yield return StartCoroutine(EnemySpawnerWave6());
        yield return StartCoroutine(EnemySpawnerWave7());
        yield return StartCoroutine(EnemySpawnerWave8());
        yield return StartCoroutine(EnemySpawnerWave9());
        yield return StartCoroutine(EnemySpawnerWave10());
        yield return StartCoroutine(EnemySpawnerWave11());
        yield return StartCoroutine(EnemySpawnerWave12());
        yield return StartCoroutine(EnemySpawnerWave13());
        yield return StartCoroutine(EnemySpawnerWave14());
        yield return StartCoroutine(EnemySpawnerWave15());
        wavespawner = false;
    }

    private IEnumerator EnemySpawnerWave1()
    {
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(3, 0, 5)));
        yield return new WaitForSeconds(10);
        wave++;
        Money.moneyvalue += 100;
        Debug.Log("wave finished " + wave.ToString());
    }

    private IEnumerator EnemySpawnerWave2()
    {
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(2, 0, 5)));
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(0.5f, 0, 3)));
        yield return new WaitForSeconds(10);
        wave++;
        Money.moneyvalue += 100;
    }

    private IEnumerator EnemySpawnerWave3()
    {
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(2, 0, 6)));
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(3, 0, 6)));
        yield return new WaitForSeconds(10);
        Money.moneyvalue += 150;
    }

    private IEnumerator EnemySpawnerWave4()
    {
        yield return StartCoroutine(FastWeakEnemySpawner(new SpawnerState(1.5f, 0, 8)));
        yield return new WaitForSeconds(10);
        Money.moneyvalue += 150;
    }
    private IEnumerator EnemySpawnerWave5()
    {
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(1, 0, 10)));
        yield return new WaitForSeconds(12);
        Money.moneyvalue += 200;
    }
    private IEnumerator EnemySpawnerWave6()
    {
        yield return StartCoroutine(WeakEnemySpawner(new SpawnerState(4, 0, 3)));
        yield return new WaitForSeconds(10);
        Money.moneyvalue += 200;
    }
    private IEnumerator EnemySpawnerWave7()
    {
        StartCoroutine(WeakestEnemySpawner(new SpawnerState(5, 0, 3)));
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(2, 0, 10)));
        yield return new WaitForSeconds(11);
        Money.moneyvalue += 250;
    }
    private IEnumerator EnemySpawnerWave8()
    {
        StartCoroutine(WeakEnemySpawner(new SpawnerState(2, 0, 6)));
        yield return StartCoroutine(FastWeakEnemySpawner(new SpawnerState(3, 0, 3)));
        yield return new WaitForSeconds(12);
        Money.moneyvalue += 400;
    }
    private IEnumerator EnemySpawnerWave9()
    {
        StartCoroutine(WeakEnemySpawner(new SpawnerState(3, 0, 5)));
        StartCoroutine(WeakestEnemySpawner(new SpawnerState(1, 0, 8)));
        yield return StartCoroutine(FastWeakEnemySpawner(new SpawnerState(1, 0, 5)));
        yield return new WaitForSeconds(13);
        Money.moneyvalue += 500;
    }
    private IEnumerator EnemySpawnerWave10()
    {
        yield return StartCoroutine(EnemySpawner(new SpawnerState(6, 0, 1)));
        StartCoroutine(WeakEnemySpawner(new SpawnerState(0.5f, 0, 8)));
        yield return StartCoroutine(FastWeakEnemySpawner(new SpawnerState(1, 0, 8)));
        yield return new WaitForSeconds(13);
        Money.moneyvalue += 500;
    }
    private IEnumerator EnemySpawnerWave11()
    {
        yield return StartCoroutine(EnemySpawner(new SpawnerState(5, 0, 2)));
        yield return new WaitForSeconds(6);
        StartCoroutine(WeakEnemySpawner(new SpawnerState(2, 0, 8)));
        yield return StartCoroutine(WeakestEnemySpawner(new SpawnerState(0.2f, 0, 8)));
        yield return new WaitForSeconds(10);
        Money.moneyvalue += 300;
    }
    private IEnumerator EnemySpawnerWave12()
    {
        StartCoroutine(EnemySpawner(new SpawnerState(2, 0, 1)));
        yield return StartCoroutine(WeakEnemySpawner(new SpawnerState(1, 0, 8)));
        yield return new WaitForSeconds(11);
        Money.moneyvalue += 700;
    }
    private IEnumerator EnemySpawnerWave13()
    {
        yield return StartCoroutine(FastEnemySpawner(new SpawnerState(7, 0, 1)));
        StartCoroutine(WeakEnemySpawner(new SpawnerState(1, 0, 8)));
        yield return StartCoroutine(EnemySpawner(new SpawnerState(3, 0, 5)));
        yield return new WaitForSeconds(12);
        Money.moneyvalue += 300;
    }
    private IEnumerator EnemySpawnerWave14()
    {
        yield return StartCoroutine(FasterEnemySpawner(new SpawnerState(6, 0, 2)));
        StartCoroutine(FastWeakEnemySpawner(new SpawnerState(1, 0, 7)));
        yield return StartCoroutine(WeakEnemySpawner(new SpawnerState(1.5f, 0, 5)));
        Money.moneyvalue += 800;

    }
    private IEnumerator EnemySpawnerWave15()
    {
        StartCoroutine(EnemySpawner(new SpawnerState(1, 0, 3)));
        StartCoroutine(FastEnemySpawner(new SpawnerState(8, 0, 2)));
        StartCoroutine(WeakEnemySpawner(new SpawnerState(1, 0, 12)));
        yield return StartCoroutine(FastWeakEnemySpawner(new SpawnerState(0.5f, 0, 15)));
        Money.moneyvalue += 500;

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
