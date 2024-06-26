using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasonUpgradeBottomPath : MonoBehaviour
{
    internal int bottomPathJason = 0;
    TowerAttack tower;
    public GameObject jasonButtonT;
    JasonUpgradesTopPath toppath;
    public GameObject jason;
    CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
        tower = jason.GetComponent<TowerAttack>();
        toppath = jasonButtonT.GetComponent<JasonUpgradesTopPath>();
        circleCollider = jason.GetComponent<CircleCollider2D>();
    }

    public void UpgradeJasonB()
    {
        if (bottomPathJason == 0 && Money.moneyvalue >= 100)
        {
            circleCollider.radius = 7;
            tower.damage += 2;
            Money.moneyvalue -= 100;
            bottomPathJason++;
            Debug.Log("upgraded radius. new radius: " + circleCollider.radius.ToString());
        }
        if (bottomPathJason == 1 && Money.moneyvalue >= 300)
        {
            circleCollider.radius = 9;
            Money.moneyvalue -= 300;
            bottomPathJason++;
            Debug.Log("upgrade works");
        }
        if (bottomPathJason == 2 && toppath.topPathJason <= 2 && Money.moneyvalue >= 1000)
        {
            circleCollider.radius = 10.5f;
            tower.damage += 5;
            tower.atkspd -= 0.1f;
            bottomPathJason++;
            Money.moneyvalue -= 1000;
            Debug.Log("toppath locked");
        }
        if (bottomPathJason == 3 && Money.moneyvalue >= 3000)
        {
            tower.damage += 120;
            circleCollider.radius = 12f;
            bottomPathJason++;
            Money.moneyvalue -= 3000;
        }
        if (bottomPathJason == 4 && Money.moneyvalue >= 12000)
        {
            tower.damage += 300;
            tower.atkspd += 1;
            circleCollider.radius = 14;
            bottomPathJason++;
        }
    }
}
