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
}
