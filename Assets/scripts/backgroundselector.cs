using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundselector : MonoBehaviour
{
    int difficulty = DifficultyButton.difficulty;
    public int thisdifficulty;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (difficulty == 0)
        {
        }
        else if (difficulty == thisdifficulty) 
        {
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
