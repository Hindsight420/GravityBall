using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundary : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Something left the screen.");
        string collidertag = collider.tag;

        if (collidertag == "Player")
        {
            LoadLevel.ResetLevel();
        }
        
    }
}
