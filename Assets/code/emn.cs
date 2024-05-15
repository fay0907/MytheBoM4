using UnityEngine;

public class emn : MonoBehaviour
{
    public int hp = 5; // Assuming 5 is the initial HP of the enemy
    internal int speed = 2;
    private bool isAttacking = false;

    // Method to perform the attack
    void Attack()
    {
        hp -= towr.damage; // Directly accessing the static damage variable from the towr class
        Debug.Log("Enemy attacked. Remaining HP: " + hp);

        // Check if the enemy's health has reached zero
        if (hp <= 0)
        {
            // Destroy the enemy object when its health is zero
            Destroy(gameObject);
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        }
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
            InvokeRepeating("Attack", towr.atkspd, towr.atkspd); // Repeats the method every 1 second
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

    // Update is called once per frame
    void Update()
    {

        // Move the object downwards over time
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
