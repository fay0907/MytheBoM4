using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private bool hasTower = false;
    private BoxCollider2D mycollider;

    private void Start()
    {
        mycollider=GetComponent<BoxCollider2D>();
    }

    public void SetTowerPlaced()
    {
        mycollider.enabled = false;
        hasTower = true;
    }

    internal bool HasTower()
    {
        return hasTower;
    }
}