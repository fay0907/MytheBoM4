using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JasonUpgradesTopPath : MonoBehaviour
{
    internal int topPathJason = 0;
    internal TowerAttack tower;
    public GameObject jasonButtonB;
    JasonUpgradeBottomPath bottompath;
    public GameObject jason;
    private void Start()
    {
        tower = jason.GetComponent<TowerAttack>();
        bottompath = jasonButtonB.GetComponent<JasonUpgradeBottomPath>();
    }
    public void UpgradeJasonT()
    {
        if (topPathJason == 0 && Money.moneyvalue >= 150) 
        {
            tower.damage += 3;
            tower.atkspd -= 0.05f;
            Money.moneyvalue -= 150;
            topPathJason++;
            Debug.Log("upgraded: damage " + tower.damage + " upgraded speed: " + tower.atkspd);
        }
        if (topPathJason == 1 && Money.moneyvalue >= 500)
        {
            tower.atkspd -= 0.1f;
            tower.damage += 6;
            topPathJason++;
            Money.moneyvalue -= 500;
            Debug.Log("upgrade successfull");
        }
        if (topPathJason == 2 && bottompath.bottomPathJason <= 2 && Money.moneyvalue >= 1500)
        {
            tower.damage += 10;
            tower.atkspd -= 0.1f;
            topPathJason++;
            Money.moneyvalue -= 1500;
            Debug.Log("bottom path locked");
        }
        if (topPathJason == 3 && bottompath.bottomPathJason <= 2 && Money.moneyvalue >= 4000)
        {
            tower.damage += 75;
            tower.atkspd -= 0.15f;
            topPathJason++;
            Money.moneyvalue -= 4000;
        }
        if (topPathJason == 4 && Money.moneyvalue >= 10000) 
        {
            tower.damage += 100;
            tower.atkspd -= 0.2f;
            topPathJason++;
            Money.moneyvalue -= 10000;
        }
    }
}
