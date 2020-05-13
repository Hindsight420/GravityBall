using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    public Button mainMenuButton;

    void Awake()
    {
        mainMenuButton.onClick.AddListener(OnClick);

    }
    void OnClick()
    {
        Debug.Log("Going to the main menu!");
        SceneManager.LoadScene(1);
    }
}
