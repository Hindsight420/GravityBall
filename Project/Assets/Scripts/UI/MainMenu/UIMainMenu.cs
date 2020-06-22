using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{

    public void OnPlayButtonClick()
    {
        GameManager.GoToPlayMode();
    }

    public void OnSelectLevelClick()
    {
        GameManager.GoToLevelSelector();
    }

    public void OnCreateLevelClick()
    {
        GameManager.GoToLevelEditor();
    }

}
