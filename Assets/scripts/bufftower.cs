using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bufftower : MonoBehaviour
{
    TowerAttack towerAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            TowerAttack towerAttack = GetComponent<TowerAttack>();
            towerAttack.atkspd = towerAttack.atkspd / 1.2f;
            towerAttack.damage = Mathf.RoundToInt(towerAttack.damage * 1.25f);
        }
        
    }
}
