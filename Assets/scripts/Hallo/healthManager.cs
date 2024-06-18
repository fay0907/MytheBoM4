using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int Health = 200;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Health / 200);
        if (Health <= 0)
        {
            SceneManager.LoadSceneAsync(6);
        }
    }

    public void removeHealth(int damage)
    {
        Health -= damage;
        healthBar.fillAmount = (Health/200f);
    }
   public  void test2()
    {
        Debug.Log("bruh");
    }
}

