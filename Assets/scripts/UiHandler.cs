using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;

    public void Tower1()
    {
        Instantiate(towers[0]);
    }
    public void Tower2()
    {
        Instantiate(towers[1]);
    }

    public void Tower3()
    {
        Instantiate(towers[2]);
    }

    public void Tower4()
    {
        Instantiate(towers[3]);
    }

    public void Tower5()
    {
        Instantiate(towers[4]); 
    }
        public void Tower6()
    {
        Instantiate(towers[5]); 
    }
}
