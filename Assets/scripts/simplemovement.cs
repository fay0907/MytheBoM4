using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // Speed of the downward movement in units per second
    public float speed = 2.0f;

    void Update()
    {
        // Calculate the movement amount
        float moveAmount = speed * Time.deltaTime;

        // Move the object downwards
        transform.position -= new Vector3(0, moveAmount, 0);
    }
}