using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    public Button resetButton;

    void Awake()
    {
        resetButton.onClick.AddListener(OnClick);

    }
    void OnClick()
    {
        LoadLevel.ResetLevel();
    }
}
