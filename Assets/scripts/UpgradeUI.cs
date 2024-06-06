using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public static Action<bool> buttonOne;

    public void ButtonOne()
    {
        buttonOne?.Invoke(true);
    }   
}

