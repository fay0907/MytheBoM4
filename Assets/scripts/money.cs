using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int moneyvalue = 0;
    public TextMeshProUGUI moneytext;
    internal int moneydifference = 0;

    void Start()
    {
        Updatemoneytext();
    }

    void Update()
    {
       if (moneydifference < moneyvalue)
        {
            Updatemoneytext();
        }
    }


    void Updatemoneytext()
    {
        moneytext.text = moneyvalue.ToString();
    }
}