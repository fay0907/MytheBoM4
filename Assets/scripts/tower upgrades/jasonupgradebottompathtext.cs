using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class jasonupgradebottompathtext : MonoBehaviour
{
    public TMP_Text textMeshProUGUI;
    public JasonUpgradeBottomPath bottomPath;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        bottomPath = button.GetComponent<JasonUpgradeBottomPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bottomPath.bottomPathJason == 0)
        {
            UpdateText("damage + 3" + " " + "radius + 1" + " " + "€100");
        }
        else if (bottomPath.bottomPathJason == 1)
        {
            UpdateText("radius + 2" + " " + "€300");
        }
        else if (bottomPath.bottomPathJason == 2 && bottomPath.locked == true)
        {
            UpdateText("locked");
        }
        else if (bottomPath.bottomPathJason == 2)
        {
            UpdateText("damage + 5" + " " + "attackspeed - 0.1" + " " + "radius + 1.5" + " " + "€1000");
        }
        else if (bottomPath.bottomPathJason == 3)
        {
            UpdateText("damage + 120" + " " + "radius + 1.5" + " " + "€3000");
        }
        else if (bottomPath.bottomPathJason == 4)
        {
            UpdateText("damage + 300" + " " + "attackspeed + 1" + " " + "radius + 2" + " " + "€12000");
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

