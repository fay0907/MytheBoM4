using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class argusupgradesbottompath : MonoBehaviour
{
    internal int bottompathargus;
    TowerAttack tower;
    argusupgradestoppath toppath;
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<TowerAttack>();
        toppath = GetComponent<argusupgradestoppath>();

    }

    public void upgradeargusB()
    {
        if (bottompathargus == 0 && Money.moneyvalue >= 100)
        {

        }
    }
}
