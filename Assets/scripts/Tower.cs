using UnityEngine;

public class TowerDragAndDrop : MonoBehaviour
{
    bool canMove = true;
    Vector2 pillerPosistion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test");
        if (collision.tag == "Tower")
        {
            pillerPosistion = collision.transform.position;
        }
        else
        {
            pillerPosistion = new Vector2 (0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.tag == "Tower")
        {
            pillerPosistion = new Vector2();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (pillerPosistion == new Vector2())
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = pillerPosistion;
                canMove = false;
            }
        }
        

        if (canMove)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }
}

