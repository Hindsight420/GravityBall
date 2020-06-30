using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Button openMenuButton, continueButton, resetButton, toMainMenuButton, optionsButton;
    public GameObject menuButtonObject;
    GameObject pauseMenu;
    PlayModeManager playModeManager;

    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
        playModeManager = GameObject.Find("PlayModeManager").GetComponent<PlayModeManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) TogglePauseMenu();
    }

    public void TogglePauseMenu()
    {
        bool isOpen = pauseMenu.activeSelf;
        pauseMenu.SetActive(!isOpen);
        menuButtonObject.SetActive(isOpen);
        if (!isOpen) playModeManager.PauseGameplay();
        else playModeManager.UnpauseGameplay();
    }

    public void OnResetButtonClicked()
    {
        TogglePauseMenu();
        LoadLevel.LoadCurrentLevel();
    }

    public void OnToMainMenuButtonClicked()
    {
        GameManager.GoToMainMenu();
    }


}
