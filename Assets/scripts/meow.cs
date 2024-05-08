using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meow : MonoBehaviour
{
    private Rigidbody rb;
    
    void Start()
    {
        gameObject.tag = "meow";
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        new Vector2(0, -1);
    }
}
