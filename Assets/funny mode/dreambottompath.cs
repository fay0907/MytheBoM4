using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamBottomPath : MonoBehaviour
{
    internal int bottomPathDream = 0;
    private TowerAttack tower;
    public GameObject dreamButtonT;
    private DreamUpgradesTopPath toppath;
    public GameObject dream;
    private CircleCollider2D circleCollider;

    // Start is called before the first frame update
    void Start()
    {
        tower = dream.GetComponent<TowerAttack>();
        toppath = dreamButtonT.GetComponent<DreamUpgradesTopPath>();
        circleCollider = dream.GetComponent<CircleCollider2D>();
    }

    public void UpgradeDreamB()
    {
        if (bottomPathDream == 0 && Money.moneyvalue >= 100)
        {
            circleCollider.radius = 10;
            tower.damage += 50;
            Money.moneyvalue -= 100;
            bottomPathDream++;
            Debug.Log("upgraded radius. new radius: " + circleCollider.radius.ToString());
        }
        else if (bottomPathDream == 1 && Money.moneyvalue >= 200)
        {
            circleCollider.radius = 12;
            Money.moneyvalue -= 200;
            bottomPathDream++;
            Debug.Log("upgrade works");
        }
        else if (bottomPathDream == 2 && toppath.topPathDream <= 2 && Money.moneyvalue >= 500)
        {
            circleCollider.radius = 15;
            tower.damage += 1000;
            tower.atkspd -= 0.3f;
            bottomPathDream++;
            Money.moneyvalue -= 500;
            Debug.Log("toppath locked");
        }
        else if (bottomPathDream == 3 && Money.moneyvalue >= 800)
        {
            tower.damage += 5000;
            circleCollider.radius = 17;
            bottomPathDream++;
            Money.moneyvalue -= 800;
        }
        else if (bottomPathDream == 4 && Money.moneyvalue >= 1200)
        {
            tower.damage += 10000;
            tower.atkspd -= 0.3f;
            circleCollider.radius = 20;
            bottomPathDream++;
        }
    }
}
