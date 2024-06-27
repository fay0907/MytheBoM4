using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Projectiledrem : MonoBehaviour
{
    public GameObject tower;
    TowerAttack grab;
    private Transform miner;
    public int speed2 = 500;
    public GameObject kaboom2;
    public static int minerstouched;

    // Start is called before the first frame update
    void Start()
    {
        grab = nearestminer();
        Debug.Log("i work");
        Debug.Log(grab.damage.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        grabminer();
        if (grab.currentEnemy != null)
        {
            miner = grab.currentEnemy.transform;
            Vector3 direction = (miner.position - transform.position).normalized;
            transform.position += direction * speed2 * Time.deltaTime;
        }
        if (grab.currentEnemy == null)
        {
            Destroy(gameObject);
        }
        if (grab.attacked == true)
        {
            Debug.Log("towerattacked is true");
        }
    }
    private void grabminer()
    {
        if (grab.attacked == true)
        {
            grab.attacked = false;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int hpbeforeattack = grab.currentEnemy.hp;
            grab.currentEnemy.hp -= grab.damage;
            if (grab.currentEnemy.hp < 0)
            {
                grab.currentEnemy.hp = 0;
            }
            Money.moneyvalue += hpbeforeattack - grab.currentEnemy.hp;
            minerstouched++;
            Destroy(gameObject);
        }
    }
    private TowerAttack nearestminer()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        GameObject nearestTower = null;
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject towerObj in towers)
        {
            float distance = Vector3.Distance(transform.position, towerObj.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestTower = towerObj;
            }
        }
        if (nearestTower != null)
        {
            return nearestTower.GetComponent<TowerAttack>();
        }
        else
        {
            return null;
        }
    }
}
