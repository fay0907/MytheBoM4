using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class argusupgradestoppath : MonoBehaviour
{
    internal int toppathargus = 0;
    TowerAttack tower;
    argusupgradesbottompath bottompath;
    private void Start()
    {
        tower = GetComponent<TowerAttack>();
        bottompath = GetComponent<argusupgradesbottompath>();
    }
    public void upgradeargusT()
    {
        if (toppathargus == 0 && Money.moneyvalue >= 150) 
        {
            tower.damage += 1;
            tower.atkspd -= 0.05f;
            Money.moneyvalue -= 150;
            toppathargus++;
            Debug.Log("upgraded: damage " + tower.damage + " upgraded speed: " + tower.atkspd);
        }
    }
}
