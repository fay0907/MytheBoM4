using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    internal int hp = 5; //blijf van de stat ints af en isDead function!!!!!!!!!!!!!!!!!!!!!!!!!
    internal int speed = 3; 
    internal int damage = 1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool isDead()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        return hp <= 0;
    }
    // Update is called once per frame
    void Update()
    {
        isDead();
    }
}
