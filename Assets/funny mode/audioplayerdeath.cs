using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioplayerdeath : MonoBehaviour
{
    int i = 0;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.deaths > i && funnymode.funnyMode == false)
        {
            i++;
            audiosource.Play();
        }
    }
}
