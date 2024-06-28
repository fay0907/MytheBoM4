using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int difficulty;
    public void ChangeScene(string sceneName)
    {
        if (difficulty == 0)
        {
            SceneManager.LoadScene(sceneName);
            // laad easy mode
        }
        if (difficulty == 1)
        {
            SceneManager.LoadScene(sceneName);
            // laad normal mode
        }
        if (difficulty == 2)
        {
            SceneManager.LoadScene(sceneName);
            // laad hard mode
        }
        if (difficulty == 3)
        {
            SceneManager.LoadScene(sceneName);
            // laad infinite mode
        }
    }
}
