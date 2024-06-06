using UnityEngine;

public class CharacterClickHandler : MonoBehaviour
{
    private TowerDragAndDrop towerDragAndDrop;
    private GameObject menuPanel;
  
    void Start()
    {
       
        menuPanel = GameObject.FindGameObjectWithTag("TowerUI");
        towerDragAndDrop = GetComponent<TowerDragAndDrop>();

        if (menuPanel != null)
        {

            menuPanel.SetActive(false); // Zorg ervoor dat het menu verborgen is bij de start
        }
    }

    void OnMouseDown()
    {
        if (menuPanel != null && !towerDragAndDrop.canMove) 
        {

            menuPanel.SetActive(!menuPanel.activeSelf); // Toggle de zichtbaarheid
        }
    }
}
