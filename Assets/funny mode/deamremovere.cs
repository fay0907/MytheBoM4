using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deamremovere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (funnymode.funnyMode == false)
        {
            Destroy(gameObject);
        }
    }
}
