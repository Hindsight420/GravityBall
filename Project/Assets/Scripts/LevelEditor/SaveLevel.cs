using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Common;
using UnityEngine;

public class SaveLevel : MonoBehaviour
{
    public static List<GameObject> placedObjects;
    static Vector2 playerPos;
    static Vector2 goalPos;
    static List<Vector2> gravityCirclesPos;
    // static List<Vector2> obstaclesPos;

    // Start is called before the first frame update
    static void Start()
    {
        Debug.Log("Saving Data.");

        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Debug.Log("Added player position to the level data.");
        goalPos = GameObject.FindGameObjectWithTag("Goal").transform.position;
        Debug.Log("Added goal position to the level data.");
        
       
        foreach (GameObject gameObject in placedObjects)
         {
            if (gameObject.tag == "LE_GravCircle")
            {
                gravityCirclesPos.Add(gameObject.transform.position);
                Debug.Log("Added a circle to the level data.");
            }
          /*  else if (gameObject.tag == "LE_Obstacle")
            {
                obstaclesPos.Add(gameObject.transform.position);
                Debug.Log("Added an obstacle to the level data.")
            } */
         }
        

        new LevelData(playerPos, goalPos, gravityCirclesPos); //obstaclesPos (=> In LevelData toevoegen)

       
    }

    // Update is called once per frame
    static void Update()
    {

    }

    static void SaveAsJson()
    {

    }
}
