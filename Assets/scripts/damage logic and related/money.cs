using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static int moneyvalue = 1000;
    public TextMeshProUGUI moneytext;

    void Start()
    {
        UpdateMoneyText();
    }

    void Update()
    {
        UpdateMoneyText();
    }

    public void AddMoney(int amount)
    {
        moneyvalue += amount;
        UpdateMoneyText();
    }

    void UpdateMoneyText()
    {
        if (moneytext != null)
        {
            moneytext.text = moneyvalue.ToString();
        }
    }
}