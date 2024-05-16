using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public LayerMask blockLayer; // Laagmasker voor de blokjes waarop torens kunnen worden geplaatst
    public GameObject towerPrefab; // Prefab van de toren die je wilt plaatsen

    private bool towerPlaced = false; // Variabele om bij te houden of er al een toren is geplaatst

    // Functie om te controleren of een toren op een blokje kan worden geplaatst en of deze al is geplaatst
    public bool CanPlaceTower(Vector3 position)
    {
        // Als er al een toren is geplaatst, kunnen we geen nieuwe toren plaatsen
        if (towerPlaced)
        {
            return false;
        }

        // Raycast naar beneden vanaf de opgegeven positie om te controleren of er een blokje is
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 0.1f, blockLayer);

        // Als de raycast een blokje raakt, kunnen we een toren plaatsen
        if (hit.collider != null)
        {
            // Hier kun je extra controle toevoegen, zoals het controleren van afstand tot andere torens, etc.
            return true;
        }
        else
        {
            // Als er geen blokje is, kan de toren niet worden geplaatst
            return false;
        }
    }

    // Functie om een toren te plaatsen en aan te geven dat er al een toren is geplaatst
    public void PlaceTower(Vector3 position)
    {
        // Controleer of een toren op deze positie kan worden geplaatst
        if (CanPlaceTower(position))
        {
            // Plaats de toren op de opgegeven positie
            Instantiate(towerPrefab, position, Quaternion.identity);

            // Markeer dat er een toren is geplaatst
            towerPlaced = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("test");
    }
}