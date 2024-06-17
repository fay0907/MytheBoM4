using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int moneyvalue = 0;
    public TextMeshProUGUI moneytext;

    void Start()
    {
        Updatemoneytext();
    }

    void Update()
    {
        // Example: Update text every frame
        Updatemoneytext();
    }

    void Updatemoneytext()
    {
        moneytext.text = moneyvalue.ToString();
    }
}