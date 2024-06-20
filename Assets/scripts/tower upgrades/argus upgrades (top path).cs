using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class argusupgradestoppath : MonoBehaviour
{
    internal int toppathargus = 0;
    TowerAttack tower;
    argusupgradesbottompath bottompath;
    public GameObject argus;
    private void Start()
    {
        tower = argus.GetComponent<TowerAttack>();
        bottompath = GetComponent<argusupgradesbottompath>();
    }
    public void upgradeargusT()
    {
        Debug.Log("buton work ");
        if (toppathargus == 0 && Money.moneyvalue >= 150) 
        {
            tower.damage += 2;
            tower.atkspd -= 0.05f;
            Money.moneyvalue -= 150;
            toppathargus++;
            Debug.Log("upgraded: damage " + tower.damage + " upgraded speed: " + tower.atkspd);
        }
        if (toppathargus == 1 && Money.moneyvalue >= 500)
        {
            tower.atkspd -= 0.1f;
            tower.damage += 3;
            toppathargus++;
            Money.moneyvalue -= 500;
            Debug.Log("upgrade successfull");
        }
        if (toppathargus == 2 && bottompath.bottompathargus <= 2 && Money.moneyvalue >= 1500)
        {
            tower.damage += 10;
            tower.atkspd -= 0.1f;
            toppathargus++;
            Money.moneyvalue -= 1500;
            Debug.Log("bottom path locked");
        }
        if (toppathargus == 3 && bottompath.bottompathargus <= 2 && Money.moneyvalue >= 4000)
        {
            tower.damage += 75;
            tower.atkspd -= 0.15f;
            toppathargus++;
            Money.moneyvalue -= 4000;
        }
        if (toppathargus == 4 && Money.moneyvalue >= 10000) 
        {
            tower.damage += 100;
            tower.atkspd -= 0.2f;
            toppathargus++;
            Money.moneyvalue -= 10000;
        }
    }
}
