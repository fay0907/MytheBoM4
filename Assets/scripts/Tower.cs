using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDragAndDrop : MonoBehaviour
{
    bool canMove = true;
    Vector2 pillerPosistion;

    private string isCollidingWith;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision tag : " + collision.tag);
        if (collision.tag == "Tower")
        {
            isCollidingWith = "Tower";
            pillerPosistion = collision.transform.position;
            Debug.Log(pillerPosistion);
        }
        else
        {
            isCollidingWith = "None";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*
        if (collision.tag == "Tower")
        {
            Debug.Log(pillerPosistion);
            pillerPosistion = new Vector2();
        }*/
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(isCollidingWith);
            if (pillerPosistion == new Vector2())
            {
                // Destroy(gameObject);
                Debug.Log("if");
            }
            else
            {
                transform.position = pillerPosistion;
                Debug.Log("else");
            }
        }
        Debug.Log(pillerPosistion);
        

        if (canMove)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }
}

