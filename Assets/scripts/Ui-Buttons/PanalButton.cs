using TMPro;
using UnityEngine;

public class CharacterClickHandler : MonoBehaviour
{
    [SerializeField] private string text;
    private GameObject menuPanel;

    private TowerDragAndDrop towerDragAndDrop;

    void Start()
    {


        GameObject child = transform.GetChild(0).gameObject;
        menuPanel = child.transform.GetChild(0).gameObject;
        towerDragAndDrop = GetComponent<TowerDragAndDrop>();

        if (menuPanel != null && !menuPanel.activeSelf)
        {

            menuPanel.SetActive(false); // Zorg ervoor dat het menu verborgen is bij de start
        }
    }

    void OnMouseDown()
    {
        if (menuPanel.activeSelf)
        {
            menuPanel.SetActive(false);
        }
        else if (menuPanel != null && !towerDragAndDrop.canMove)
        {
            GameObject[] towerUis = GameObject.FindGameObjectsWithTag("TowerUI");

            for (int i = 0; i < towerUis.Length; i++)
            {
                towerUis[i].SetActive(false);
            }

            menuPanel.SetActive(true); // Toggle de zichtbaarheid
        }
    }
}
