using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;

    private void OnMouseDown()
    {
        isDragging = true;
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        // Check if tower can be placed at current position
        // If valid placement, snap tower to grid or map position
        // Otherwise, return tower to its original position
    }
}

