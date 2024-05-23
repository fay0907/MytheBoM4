
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towr : MonoBehaviour
{
    private emn enemy;
    public static int damage = 2;
    public static double atkspddouble = 0.5;
    internal float atkspd = (float)atkspddouble;
    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        // Don't add the enemy component here. The tower should not have an enemy component.
    }

    void Attack()
    {
        if (enemy != null)
        {
            enemy.hp -= damage;
            Debug.Log("Enemy attacked. Remaining HP: " + enemy.hp);

            if (enemy.hp <= 0)
            {
                enemy = null; // Stop attacking if the enemy is dead
                CancelInvoke("Attack");
                isAttacking = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected with: " + other.gameObject.name); // Added debug log

        // Check if the collided object has the tag "enemy"
        if (other.gameObject.CompareTag("trowe") && !isAttacking)
        {
            enemy = other.GetComponent<emn>();
            if (enemy != null)
            {
                isAttacking = true;
                Debug.Log("Enemy triggered with tower.");
                // Start invoking the Attack method repeatedly
                InvokeRepeating("Attack", atkspd, atkspd); // Repeats the method at specified attack speed
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger exit detected with: " + other.gameObject.name); // Added debug log

        // Stop attacking when the enemy stops triggering with the tower
        if (other.gameObject.CompareTag("trowe") && enemy != null)
        {
            isAttacking = false;
            CancelInvoke("Attack");
            enemy = null; // Clear the reference to the enemy
            Debug.Log("Enemy stopped triggering with tower.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}