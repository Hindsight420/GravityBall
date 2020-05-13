using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public Button toGameMMButton, selectLevelMMButton, leveleditorMMButton, optionsMMButton;

    void Start()
    {
        toGameMMButton.onClick.AddListener(GoToGame);                           //Geeft een foutmelding in de console.
        selectLevelMMButton.onClick.AddListener(GoToLevelSelector);
        leveleditorMMButton.onClick.AddListener(GoToLevelEditor);
        optionsMMButton.onClick.AddListener(GoToOptionsMenu);

    }

    void GoToGame()
    {
        SceneManager.LoadScene(0);
    }

    void GoToLevelSelector()
    {
        Debug.Log("Loading level selector.");
    }

    void GoToLevelEditor()
    {
        Debug.Log("Loading level editor.");
    }

    void GoToOptionsMenu()
    {
        Debug.Log("Opening options.");
    }    
}
