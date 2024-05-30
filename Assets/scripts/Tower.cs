using System;
using UnityEngine;

public class TowerDragAndDrop : MonoBehaviour
{
    bool canMove = true;
    bool debugFollow = true;
    Collider2D collider;
    BoxCollider2D boxCollider;
    CircleCollider2D circleCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        circleCollider.enabled = false;
        boxCollider.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(canMove==false || collision is CircleCollider2D)//placed don't run placementcode
        {
            return;
        }
        Debug.Log("OnTriggerStay2D " + DateTime.Now + collision);
        Debug.Log("OnTriggerStay2D " + DateTime.Now + collision.tag + " "+ collision.name);
        if (collision.tag == "Tower")
        {
            Debug.Log("OnTriggerStay2D " + DateTime.Now + collision + " is tower");
            collider = collision;
        }
        else
        {
            collider = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (canMove == false)//placed don't run placementcode
        {
            return;
        }
       Debug.Log("OnTriggerExit2D " + DateTime.Now + collision);
         Debug.Log("OnTriggerExit2D " + DateTime.Now + collision.tag + " " + collision.name);
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
        if (Input.GetMouseButtonDown(0) )//&& canMove)
        {
            if (collider == null) { Debug.Log("collider = null");  return; };
            Debug.Log(DateTime.Now + " LeftButtonCheck " + name);

            TowerPlacement tower = collider.GetComponent<TowerPlacement>();

            if (tower == null) { Debug.Log("object does not have the script TowerPlacement!"); return; };

            if (!tower.HasTower())
            {
                transform.position = collider.gameObject.transform.position;
                tower.SetTowerPlaced();
                canMove = false;
                circleCollider.enabled = true;
                boxCollider.enabled = false;
                enabled = false;
                collider = null;
                this.enabled = false;
            }
            else
            {
                Debug.Log("hastower = true");
            }
        }
    }
}