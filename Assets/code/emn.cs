using UnityEngine;

public class emn : MonoBehaviour
{
    public int hp = 5; // Assuming 5 is the initial HP of the enemy
    internal int speed = 2;


    // Method to perform the attack
    void Attack()
    {
        hp -= towr.damage;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "towr"
        if (collision.gameObject.tag == "trowe")
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            // Start invoking the Attack method repeatedly
            Invoke("Attack", 1.0f); // Repeats the method every 1 second starting immediately
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object downwards over time
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Check if the enemy's health has reached zero
        if (hp <= 0)
        {
            // Destroy the enemy object when its health is zero
            Destroy(gameObject);
        }
    }
}