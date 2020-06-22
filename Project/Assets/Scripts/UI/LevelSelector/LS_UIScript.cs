using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LS_UIScript : MonoBehaviour
{
    public GameObject levelButton;
    public Transform panelTransform;

    void Start()
    {
        InstantiateAllLevelButtons();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstantiateLevelButton(string levelName)
    {
        GameObject levelButtonInstance = Instantiate(levelButton, panelTransform);
        Text levelText = levelButtonInstance.GetComponentInChildren<Text>();
        levelText.text = levelName;
        Button btnLevelInstance = levelButtonInstance.GetComponent<Button>();
        btnLevelInstance.onClick.AddListener(() => OnLevelButtonClicked(levelName));
    }

    public void InstantiateAllLevelButtons()
    {
        foreach (FileInfo fileInfo in InputOutput.GetAllLevelFiles())
        {
            InstantiateLevelButton(fileInfo.Name);
        }
    }

    public void OnLevelButtonClicked(string levelName)
    {
        LoadLevel.ChangeCurrentLevelByName(levelName);
        GameManager.GoToPlayMode();

    }

    public void OnBackButtonClicked()
    {
        GameManager.GoToMainMenu();
    }
}
