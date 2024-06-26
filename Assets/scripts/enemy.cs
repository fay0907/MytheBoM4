using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image healthbar;
    private Transform target;
    public int hp = 10;
    public float speed = 2f;
    private bool isDead = false; // Flag to track if the enemy is dead

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Boat").transform;
        if (target == null)
        {
            Debug.LogError("Target (Boat) not found in the scene.");
        }
    }

    void Update()
    {
        if (!IsDead() && target != null)
        {
            MoveTowardsTarget();

            // Add logic to attack the boat when in range
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget < 100.0f) // Adjust this distance as needed
            {
                AttackTarget();
            }
        }
        healthbar.fillAmount = (hp / 200f);
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void AttackTarget()
    {
        Debug.Log("attacking boat");
        // Implement attack logic here
        // For example, deal damage to the boat
        HealthManager boatHealth = target.GetComponent<HealthManager>();
        if (boatHealth != null)
        {
            boatHealth.removeHealth(hp); // Adjust damage amount as needed
            BoatAttacked(hp);
        }
    }

    public void TakeDamage()
    {
        if (IsDead())
            return;

        if (hp <= 0)
        {
            hp = 0;
            isDead = true;
        }
    }
    public void BoatAttacked(int damage)
    {
        hp -= damage;
        TakeDamage();
    }
    public bool IsDead() // Method to check if the enemy is dead
    {
        if (isDead)
        {
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }
}
