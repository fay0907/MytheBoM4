using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    Vector3 differenceVector;
    float distance;
    Vector3 Direction;
    [SerializeField] float speed = 20f;
    Vector3 velocity;
    Rigidbody2D rb;
    private healthManager chiuaua;
    public int hp = 5;
    public bool onLava = false;
    int maxAllowedDistance = 2;

    // Vector3 velocity;
    // float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        chiuaua = FindObjectOfType<healthManager>();

        float x = Random.Range(20, -20);
        if (-12 < x && x < 12)
        {
            transform.position = new Vector3(x, Random.Range(6, 11), 0);
        }
        else
        {
            transform.position = new Vector3(x, Random.Range(11, -5), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        differenceVector = GameObject.FindWithTag("Boat").transform.position - transform.position;
        Direction = differenceVector.normalized;
        velocity = Direction * Mathf.Clamp(speed * Time.deltaTime, 0f, maxAllowedDistance);
        transform.position += velocity;

        
        
    }
    internal bool isDead()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("attempted to destroy gameobject");
            return true;
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boat")
        {
            chiuaua.removeHealth(10);
            Destroy(gameObject);
        }
    }

}