
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class towr : MonoBehaviour
{
    emn enemy = new emn();
    public static int damage = 2;
    public static double atkspddouble = 0.5;
    internal float atkspd = (float)atkspddouble;
    private bool isAttacking = false;

    void Attack()
    {
        enemy.hp -= damage; // Directly accessing the static damage variable from the towr class
        Debug.Log("Enemy attacked. Remaining HP: " + enemy.hp);

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected with: " + other.gameObject.name); // Added debug log

        // Check if the collided object has the tag "trowe"
        if (other.gameObject.CompareTag("trowe") && !isAttacking)
        {
            isAttacking = true;
            Debug.Log("Enemy triggered with tower.");
            // Start invoking the Attack method repeatedly
            InvokeRepeating("Attack", atkspd, atkspd); // Repeats the method every 1 second
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger exit detected with: " + other.gameObject.name); // Added debug log

        // Stop attacking when the enemy stops triggering with the tower
        if (other.gameObject.CompareTag("trowe"))
        {
            isAttacking = false;
            CancelInvoke("Attack");
            Debug.Log("Enemy stopped triggering with tower.");
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}