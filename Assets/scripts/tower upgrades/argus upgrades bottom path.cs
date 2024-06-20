using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class argusupgradesbottompath : MonoBehaviour
{
    internal int bottompathargus = 0;
    TowerAttack tower;
    argusupgradestoppath toppath;
    public GameObject argus;
    CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<TowerAttack>();
        toppath = GetComponent<argusupgradestoppath>();
        circleCollider = argus.GetComponent<CircleCollider2D>();
    }

    public void upgradeargusB()
    {
        if (bottompathargus == 0 && Money.moneyvalue >= 100)
        {
            circleCollider.radius = 6;
            Money.moneyvalue -= 100;
            bottompathargus++;
            Debug.Log("upgraded radius. new radius: " + circleCollider.radius.ToString());
        }
        if (bottompathargus == 1 && Money.moneyvalue >= 300)
        {
            circleCollider.radius = 7;
            Money.moneyvalue -= 300;
            bottompathargus++;
            Debug.Log("upgrade works");
        }
        if (bottompathargus == 2 && toppath.toppathargus <= 2 && Money.moneyvalue >= 1000)
        {
            circleCollider.radius = 8.5f;
            tower.damage += 5;
            tower.atkspd -= 0.1f;
            bottompathargus++;
            Money.moneyvalue -= 1000;
        }
        if (bottompathargus == 3 && Money.moneyvalue >= 3000)
        {
            tower.damage += 120;
            circleCollider.radius = 9.5f;
            bottompathargus++;
            Money.moneyvalue -= 3000;
        }
        if (bottompathargus == 4 && Money.moneyvalue >= 12000)
        {
            tower.damage += 300;
            tower.atkspd += 1;
            circleCollider.radius = 12;
        }
    }
}
