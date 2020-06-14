using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button resetButton;
   
    void Start()
    {
        resetButton.onClick.AddListener(LoadLevel.LoadCurrentLevel);
    }
}
