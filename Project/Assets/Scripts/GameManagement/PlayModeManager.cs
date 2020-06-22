using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModeManager : MonoBehaviour
{

    void Start()
    {
        
    }

    public void PauseGameplay()
    {
        Time.timeScale = 0;
    }

   public void UnpauseGameplay()
    {
        Time.timeScale = 1;
    }
}
