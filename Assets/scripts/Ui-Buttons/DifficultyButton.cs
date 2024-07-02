using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    public static int difficulty;
    public int difficultyButton;

    public void difficultyselection()
    {
        difficulty = difficultyButton;
        ChangeScene("Game");
    }
    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
