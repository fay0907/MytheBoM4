using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class jasonupgradetoppathtext : MonoBehaviour
{
    public TMP_Text textMeshProUGUI;
    public JasonUpgradesTopPath topPath;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        topPath = button.GetComponent<JasonUpgradesTopPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (topPath.topPathJason == 0)
        {
            UpdateText("damage + 3" + " " + "attackspeed - 0.05" + " " + "€150");
        }
        else if (topPath.topPathJason == 1)
        {
            UpdateText("damage + 6" + " " + "attackspeed - 0.1" + " " + "€500");
        }
        else if (topPath.topPathJason == 2 && topPath.locked == true)
        {
            UpdateText("locked");
        }
        else if (topPath.topPathJason == 2)
        {
            UpdateText("damage + 10" + " " + "attackspeed - 0.1" + " " + "€1500");
        }
        else if (topPath.topPathJason == 3)
        {
            UpdateText("damage + 75" + " " + "attackspeed - 0.15" + " " + "€4000");
        }
        else if (topPath.topPathJason == 4)
        {
            UpdateText("damage + 100" + " " + "attackspeed - 0.2" + " " + "€10000");
        }
        else
        {
            UpdateText("max");
        }
    }
    public void UpdateText(string text)
    {
        if (textMeshProUGUI != null)
        {
            textMeshProUGUI.text = text;
        }
    }
}
