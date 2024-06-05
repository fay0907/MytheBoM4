using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterClickHandler : MonoBehaviour
{
    public GameObject menuPanel;

    void Start()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false); // Zorg ervoor dat het menu verborgen is bij de start
        }
    }

    void OnMouseDown()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(true); // Open het menu wanneer op het karakter wordt geklikt
        }
    }
}
