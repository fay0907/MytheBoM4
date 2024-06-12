using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EenSimpelKleinScriptjeDieDeScènesLaadtAlsJeBepaaldeDingenDoet : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public void BoatGame()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Towers()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void SettingsStart()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void Lore()
    {
        SceneManager.LoadSceneAsync(5);
    }
    public void GameOver()
    {
        SceneManager.LoadSceneAsync(6);
    }
    
    
    
}
