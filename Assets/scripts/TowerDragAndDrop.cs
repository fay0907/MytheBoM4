using System;
using UnityEngine;

public class TowerDragAndDrop : MonoBehaviour
{
    public bool canMove = true;
    internal bool canAttack = false;
    private Collider2D collider;
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        if (circleCollider == null)
        {
            Debug.LogError("CircleCollider2D not found on the GameObject.");
        }

        if (boxCollider == null)
        {
            Debug.LogError("BoxCollider2D not found on the GameObject.");
        }

        circleCollider.enabled = false;
        boxCollider.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canMove == false || collision is CircleCollider2D) //placed don't run placement code
        {
            return;
        }

        if (collision.CompareTag("Towerplacement"))
        {
            collider = collision;
        }
        else
        {
            collider = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (canMove == false) //placed don't run placement code
        {
            return;
        }

        collider = null;
    }

    private void Update()
    {
        LeftButtonCheck();

        if (canMove)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    private void LeftButtonCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (collider == null)
            {
                Debug.Log("collider = null");
                return;
            }

            TowerPlacement tower = collider.GetComponent<TowerPlacement>();

            if (tower == null)
            {
                Debug.Log("object does not have the script TowerPlacement!");
                return;
            }

            if (!tower.HasTower())
            {
                transform.position = collider.gameObject.transform.position;
                tower.SetTowerPlaced();
                canMove = false;

                if (circleCollider != null)
                {
                    circleCollider.enabled = true;
                    Debug.Log("CircleCollider2D enabled.");
                }
                else
                {
                    Debug.LogError("circleCollider is null.");
                }

                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                    Debug.Log("BoxCollider2D disabled.");
                }
                else
                {
                    Debug.LogError("boxCollider is null.");
                }

                collider = null;
                canAttack = true;

                // Disable the script only after enabling the collider
                this.enabled = false;
            }
        }
    }
}