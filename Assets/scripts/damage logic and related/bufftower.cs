using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bufftower : MonoBehaviour
{
    TowerAttack towerAttack;
    TowerDragAndDrop placement;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            TowerAttack towerAttack = other.GetComponent<TowerAttack>(); // Retrieve the attack component from the tower
            TowerDragAndDrop placement = other.GetComponent<TowerDragAndDrop>();
            if (towerAttack != null && placement.canAttack == true)
            {
                towerAttack.atkspd = towerAttack.atkspd / 1.2f;
                towerAttack.damage = Mathf.RoundToInt(towerAttack.damage * 1.25f);
                Debug.Log("Tower updated: " + towerAttack.ToString() + ", updated damage = " + towerAttack.damage);
            }
            else
            {
                Debug.LogWarning("No TowerAttack component found on the tower.");
            }
        }
    }
}
