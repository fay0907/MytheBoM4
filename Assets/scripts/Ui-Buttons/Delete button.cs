using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Deletebutton : MonoBehaviour
{
    public Button MyButton; 
    public GameObject itemToDelete;
    private void Start()
    {
        if (MyButton != null)
        {
            MyButton.onClick.AddListener(OnButtonClick);
        }

        void OnButtonClick()
        {
            if (itemToDelete != null)
            {
                Destroy(itemToDelete);
                Debug.Log("Gone");
            }
            else 
            {
                Debug.Log("BWOMPBWOMP");
            }
            
        }

    }

}
