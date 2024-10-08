using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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

    private void Update()
    {
        
        //Vector3 MousePos = Input.mousePosition;
        //Vector3 Position = transform.position;
        //float difference = Vector3.Distance(Position, MousePos);
       // Debug.Log(Vector2.Distance(mouseWorldPos, towerDragAndDrop.transform.position));
      // Debug.Log(mouseWorldPos);
        //Debug.Log(towerDragAndDrop.transform.position);

    }
    void OnMouseDown()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (menuPanel.activeSelf)
        {
            menuPanel.SetActive(false);
        }
        else if (menuPanel != null && !towerDragAndDrop.canMove && Vector2.Distance(mouseWorldPos, towerDragAndDrop.transform.position) < 0.5) 
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
