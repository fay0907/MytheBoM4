using UnityEngine;

public class DreamUpgradesTopPath : MonoBehaviour
{
    internal int topPathDream = 0;
    internal TowerAttack tower;
    public GameObject dreamButtonB;
    private JasonUpgradeBottomPath bottompath;
    public GameObject dream;

    private void Start()
    {
        tower = dream.GetComponent<TowerAttack>();
        bottompath = dreamButtonB.GetComponent<JasonUpgradeBottomPath>();
    }

    public void UpgradeDreamT()
    {
        if (topPathDream == 0 && Money.moneyvalue >= 100)
        {
            tower.damage += 50;
            tower.atkspd -= 0.1f;
            Money.moneyvalue -= 100;
            topPathDream++;
            Debug.Log("upgraded: damage " + tower.damage + " upgraded speed: " + tower.atkspd);
        }
        else if (topPathDream == 1 && Money.moneyvalue >= 200)
        {
            tower.atkspd -= 0.1f;
            tower.damage += 100;
            topPathDream++;
            Money.moneyvalue -= 200;
            Debug.Log("upgrade successful");
        }
        else if (topPathDream == 2 && bottompath.bottomPathJason <= 2 && Money.moneyvalue >= 900)
        {
            tower.damage += 1000;
            tower.atkspd -= 0.3f;
            topPathDream++;
            Money.moneyvalue -= 900;
            Debug.Log("bottom path locked");
        }
        else if (topPathDream == 3 && bottompath.bottomPathJason <= 2 && Money.moneyvalue >= 1500)
        {
            tower.damage += 10000;
            tower.atkspd -= 0.2f;
            topPathDream++;
            Money.moneyvalue -= 1500;
        }
        else if (topPathDream == 4 && Money.moneyvalue >= 3000)
        {
            tower.damage += 9172502;
            tower.atkspd -= 0.2f;
            topPathDream++;
            Money.moneyvalue -= 3000;
        }
    }
}   