using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kabombaudio : MonoBehaviour
{
    int i = 0;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mrrorooowww.AAAAA > i)
        {
            i++;
            audio.Play();
        }
    }
}
