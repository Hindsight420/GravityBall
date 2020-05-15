using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    static LevelData testLevel;
    static public GameObject gravityCircleObject;
    static public GameObject playerObject;
    static public GameObject goalObject;
    static int currentLevel = 0;
    static List<GameObject> loadedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gravityCircleObject = (GameObject)Resources.Load("Prefabs/GravityCircle", typeof(GameObject));
        playerObject = (GameObject)Resources.Load("Prefabs/Player", typeof(GameObject));
        goalObject = (GameObject)Resources.Load("Prefabs/Goal", typeof(GameObject));
        LoadCurrentLevel();
    }

    static public void LoadCurrentLevel()
    {
        testLevel = LevelData.GetDummyData()[currentLevel];

        loadedObjects.Add(Instantiate(playerObject, testLevel.playerPosition, Quaternion.identity));
        loadedObjects.Add(Instantiate(goalObject, testLevel.goalPosition, Quaternion.identity));

        foreach (Vector2 gravityCirclePositions in testLevel.gravityCirclesPosition)
        {
            loadedObjects.Add(Instantiate(gravityCircleObject, gravityCirclePositions, Quaternion.identity));
        }
    }

    static public void FinishLevel()
    {
        while (loadedObjects.Count > 0)
        {
            Destroy(loadedObjects[0]);
            loadedObjects.RemoveAt(0);
        } 
        currentLevel++;
        LoadCurrentLevel();
    }

    static public void ResetLevel()
    {
        foreach (GameObject loadedObject in loadedObjects)
        {
          Destroy(loadedObject);
        }
        LoadCurrentLevel();
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
