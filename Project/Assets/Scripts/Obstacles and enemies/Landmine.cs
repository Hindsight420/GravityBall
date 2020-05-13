using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{     private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Checking collision with landmine.");
        string colliderTag = collider.tag;

        if (colliderTag == "Player")
        {
            Debug.Log("Player hit landmine.");
            LoadLevel.ResetLevel();
        }

    }
   
}
    