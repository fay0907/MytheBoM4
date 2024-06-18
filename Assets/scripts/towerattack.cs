using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private List<Enemy> enemiesInRange = new List<Enemy>();
    private Enemy currentEnemy;
    private bool isAttacking;
    [SerializeField] internal float atkspd = 0.5f; // Attack speed in seconds
    [SerializeField] internal int damage = 2;
    private float attackCooldown = 0f; // Cooldown timer

    void Update()
    {
        // Handle the cooldown timer
        if (isAttacking)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0f)
            {
                Attack();
                attackCooldown = atkspd;
            }
        }
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
                    StartAttacking();
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
            attackCooldown = atkspd; // Start the cooldown
        }
    }

    void Attack()
    {
        if (currentEnemy == null)
        {
            isAttacking = false;
            return;
        }

        if (currentEnemy.IsDead())
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
                isAttacking = false;
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
            int moneyadded = hpdifference - currentEnemy.hp;
            Money.moneyvalue += moneyadded;
            Debug.Log("damage dealt. added money: " + moneyadded);

            currentEnemy.TakeDamage();
        }
    }
}