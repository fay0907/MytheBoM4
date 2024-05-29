using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private List<enemy> enemiesInRange = new List<enemy>();
    private enemy currentEnemy;
    private bool isAttacking;
    public float atkspd; // attack speed

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected with: " + other.gameObject.name); // Added debug log

        // Check if the collided object has the tag "trowe"
        if (other.gameObject.CompareTag("enemy"))
        {
            enemy Enemy = other.GetComponent<enemy>();
            if (Enemy != null && !enemiesInRange.Contains(Enemy))
            {
                enemiesInRange.Add(Enemy);
                Debug.Log("Enemy entered range: " + Enemy.name);

                if (!isAttacking)
                {
                    StartAttacking();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger exit detected with: " + other.gameObject.name); // Added debug log

        if (other.gameObject.CompareTag("trowe"))
        {
            enemy Enemy = other.GetComponent<enemy>();
            if (Enemy != null && enemiesInRange.Contains(Enemy))
            {
                enemiesInRange.Remove(Enemy);
                Debug.Log("Enemy exited range: " + Enemy.name);

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
            isAttacking = true;
            InvokeRepeating("Attack", atkspd, atkspd); // Repeats the method at specified attack speed
            Debug.Log("Started attacking: " + currentEnemy.name);
        }
    }

    void Attack()
    {
        if (currentEnemy == null)
        {
            StopAttacking();
            return;
        }

        // Implement your attack logic here
        // Example:
        Debug.Log("Attacking: " + currentEnemy.name);

        // Check if the enemy is dead (replace this with your actual check)
        bool enemyIsDead = currentEnemy.isDead(); // Assuming isDead() is a method in your emn class

        if (enemyIsDead)
        {
            enemiesInRange.Remove(currentEnemy);
            currentEnemy = null;
            Debug.Log("Enemy killed.");

            if (enemiesInRange.Count > 0)
            {
                currentEnemy = enemiesInRange[0];
                Debug.Log("Switching to new enemy: " + currentEnemy.name);
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
        Debug.Log("Stopped attacking.");
    }
}
