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
    internal bool locked;

    private readonly int[] upgradeCosts = { 150, 500, 1500, 4000, 10000 };
    private readonly int[] damageIncreases = { 3, 6, 10, 75, 100 };
    private readonly float[] atkspdReductions = { 0.05f, 0.1f, 0.1f, 0.15f, 0.2f };

    private void Start()
    {
        tower = jason.GetComponent<TowerAttack>();
        bottompath = jasonButtonB.GetComponent<JasonUpgradeBottomPath>();
    }

    public void UpgradeJasonT()
    {
        if (bottompath.bottomPathJason >= 2)
        {
            locked = true;
            return;
        }

        if (topPathJason < upgradeCosts.Length && Money.moneyvalue >= upgradeCosts[topPathJason])
        {
            tower.damage += damageIncreases[topPathJason];
            tower.atkspd -= atkspdReductions[topPathJason];
            Money.moneyvalue -= upgradeCosts[topPathJason];
            topPathJason++;
            Debug.Log($"Upgrade success: damage {tower.damage}, speed {tower.atkspd}");
        }
    }
}
