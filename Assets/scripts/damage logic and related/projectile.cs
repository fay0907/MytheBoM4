using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject tower;
    TowerAttack towerattack;
    private Transform target;
    public int speed = 500;
    public GameObject kaboom;
    
    // Start is called before the first frame update
    void Start()
    {
        towerattack = FindNearestTower();
    }

    // Update is called once per frame
    void Update()
    {
        TriggerProjectile();
        if (towerattack.currentEnemy != null)
        {
            target = towerattack.currentEnemy.transform;
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        if (towerattack.currentEnemy == null)
        {
            Destroy(gameObject);
        }
        if (towerattack.attacked == true)
        {
            Debug.Log("towerattacked is true");
        }
    }
    private void TriggerProjectile()
    {
        if (towerattack.attacked == true)
        {
            towerattack.attacked = false;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(kaboom, target.position, target.rotation);
            int hpbeforeattack = towerattack.currentEnemy.hp;
            towerattack.currentEnemy.hp -= towerattack.damage;
            if (towerattack.currentEnemy.hp < 0)
            {
                towerattack.currentEnemy.hp = 0;
            }
            Money.moneyvalue += hpbeforeattack - towerattack.currentEnemy.hp;
            Destroy(gameObject);
        }
    }
    private TowerAttack FindNearestTower()
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
