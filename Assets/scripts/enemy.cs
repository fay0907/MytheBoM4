using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{
    
    Vector3 differenceVector;
    float distance;
    Vector3 Direction;
    [SerializeField] float speed = 20f;
    Vector3 velocity;
    Rigidbody2D rb;
    private healthManager chiuaua;
    public int hp = 1;
    public bool onLava = false;

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
        //distance = differenceVector.magnitude;
        Direction = differenceVector.normalized;
        velocity = Direction * speed * Time.deltaTime;
        transform.position += velocity;

        
        
    }
    public void removeEnemyHealth(int damage)
    {
        hp -= damage;

    }
    internal bool isDead()
    {
        if (hp < 0)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boat")
        {
            // Debug.Log("ik word betast");
            chiuaua.removeHealth(10);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "floor")
        {
            //  Debug.Log("ik raak aan");
            
            onLava = true;
            transform.gameObject.tag = ("LavaEnemy");
        }
        
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "floor")
        {
           // Debug.Log("ik raak niet meer aan");
            onLava = false;
            transform.gameObject.tag = ("Enemy");
        }
    }

    public void Kill()
    {
        
        Debug.Log("kill");
      //  if (onLava == true)
       // {
            Debug.Log("ik hoor dood te zijn");
            Destroy(GameObject.FindWithTag("LavaEnemy"));
          //  Destroy(gameObject.Find("enemy(Clone)"));
      //  }
    }


}