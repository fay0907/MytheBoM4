using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private List<Enemy> enemiesInRange = new List<Enemy>();
    private Enemy currentEnemy;
    private bool isAttacking;
    [SerializeField] internal float atkspd = 0.5f; // Attack speed in seconds
    [SerializeField] internal int damage = 2;
    internal bool removedEnemy = false;
    internal int enemieskilled;

    private void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("collision");
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && !enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Add(enemy);

                if (!isAttacking)
                {
                    StartAttacking();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Remove(enemy);

                if (currentEnemy == enemy)
                {
                    currentEnemy = null;
                    isAttacking = false;
                    StopAttacking();
                }
            }
        }
    }

    void StartAttacking()
    {
        if (enemiesInRange.Count > 0)
        {
            currentEnemy = enemiesInRange[0];
            isAttacking = true;
        }
    }
            /*InvokeRepeating("Attack", 0f , atkspd); // Repeats the method at specified attack speed
        }
    }*/

    void Attack()
    {
        if (currentEnemy == null)
        {
            StopAttacking();
            return;
        }

        else if (currentEnemy.IsDead()) // Call the IsDead method to check if the enemy is dead
        {
            enemiesInRange.Remove(currentEnemy);
            currentEnemy = null;
            Destroy(currentEnemy);
            

            if (enemiesInRange.Count > 0)
            {
                currentEnemy = enemiesInRange[0];
            }
            else
            {
                StopAttacking();
            }
        }
        else
        {
            int hpdifference = currentEnemy.hp;
            currentEnemy.hp -= damage;
            if (currentEnemy.hp < 0)
            {
                currentEnemy.hp = 0;
            }
            Money.moneyvalue += hpdifference - currentEnemy.hp; //calculates difference between hp before and after attack
            
            currentEnemy.TakeDamage();
        }
    }
    void StopAttacking()
    {
        isAttacking = false;
        CancelInvoke("Attack");
    }
}
