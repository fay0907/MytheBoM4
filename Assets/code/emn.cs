using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class emn : MonoBehaviour
{
    public int hp = 5; // Assuming 5 is the initial HP of the enemy
    internal int speed = 2;
    
    public static int alive = 0;

    // Method to perform the attack


    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        // Move the object downwards over time
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    
}
