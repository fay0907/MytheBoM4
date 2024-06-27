using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioplayerdrem : MonoBehaviour
{
    private AudioSource AudioSource;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Projectiledrem.minerstouched > i)
        {
            i++;
            AudioSource.Play();
        }
    }
}
