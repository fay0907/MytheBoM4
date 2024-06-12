using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private List<enemy> enemiesInRange = new List<enemy>();
    private enemy currentEnemy;
    private Money money;
    private bool isAttacking;
    public float atkspd = 1; 
    internal int damage = 2;
    internal int hpbeforeattack;

    void Start()
    {
        money = FindObjectOfType<Money>();
        if (money == null )
        {
            Debug.Log("object not found");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            enemy Enemy = other.GetComponent<enemy>();
            if (Enemy != null && !enemiesInRange.Contains(Enemy))
            {
                enemiesInRange.Add(Enemy);
                Debug.Log("Enemy added");

                if (!isAttacking)
                {
                    StartAttacking();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            enemy Enemy = other.GetComponent<enemy>();
            if (Enemy != null && enemiesInRange.Contains(Enemy))
            {
                enemiesInRange.Remove(Enemy);
                
                if (currentEnemy == Enemy)
                {
                    currentEnemy = null;
                    isAttacking = false;
                    CancelInvoke("Attack");
                    if (enemiesInRange.Count > 0)
                    {
                        StartAttacking();
                    }
                }
            }
        }
    }

    void StartAttacking()
    {
        if (enemiesInRange.Count > 0)
        {
                currentEnemy = enemiesInRange[0];
                hpbeforeattack = currentEnemy.hp; // Initialize hpbeforeattack when starting to attack
                isAttacking = true;
                InvokeRepeating("Attack", atkspd, atkspd); // Repeats the method at specified attack speed
        }
    }

    void Attack()
    {
        if (currentEnemy == null)
        {
            StopAttacking();
            return;
        }

        Debug.Log("Attacking: " + currentEnemy.name);

        int damageDealt = damage; // Define the damage to be dealt

        currentEnemy.hp -= damageDealt; // Deal damage
        if (currentEnemy.hp < 0)
        {
            currentEnemy.hp = 0;
        }
        money.moneyvalue += (hpbeforeattack - currentEnemy.hp); // Update moneyvalue based on HP difference
        Debug.Log("money = " + money.moneyvalue);
        hpbeforeattack = currentEnemy.hp; // Update hpbeforeattack after attack

        bool enemyIsDead = currentEnemy.isDead(); // Check if the enemy is dead

        if (enemyIsDead)
        {
            enemiesInRange.Remove(currentEnemy);
            currentEnemy = null;

            if (enemiesInRange.Count > 0)
            {
                currentEnemy = enemiesInRange[0];
                hpbeforeattack = currentEnemy.hp; // Initialize hpbeforeattack for the new enemy
            }
            else
            {
                StopAttacking();
            }
        }
    }

    void StopAttacking()
    {
        isAttacking = false;
        CancelInvoke("Attack");
    }
}
