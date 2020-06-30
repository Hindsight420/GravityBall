using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void GoToPlayMode()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public static void GoToLevelSelector()
    {
        SceneManager.LoadScene(2);
    }

    public static void GoToLevelEditor()
    {
        SceneManager.LoadScene(3);
    }

}
