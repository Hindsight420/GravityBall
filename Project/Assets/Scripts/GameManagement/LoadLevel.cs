using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Unity.Collections;
using System.IO;

public class LoadLevel : MonoBehaviour
{
    static List<GameObject> elementObjects = new List<GameObject>();
    public static int currentLevel = 1;

    // Start is called before the first frame update


    void Start()
    {
        LoadCurrentLevel();
    }

    public static void LoadNextLevel()
    {
        currentLevel++;
        LoadCurrentLevel();
    }

    public static void SetCurrentLevel(int levelIndex)
    {
        currentLevel = levelIndex;
    }
    public static void LoadCurrentLevel()
    {
        DestroyElementObjects();
        string path = InputOutput.GetLevelPath(currentLevel);
        string jsonData = InputOutput.LoadJsonDataFromPath(path);
        ConvertJsonDataToObjectPositions(jsonData);
    }
    
    public static void ChangeCurrentLevelByName(string fileName)
    {
        currentLevel = InputOutput.GetLevelIndex(fileName);
    }

    static void DestroyElementObjects()
    {
        foreach (GameObject elementObject in elementObjects)
        {
            Destroy(elementObject);
        }
    }


    static void ConvertJsonDataToObjectPositions(string jsonData)
    {
        LevelData levelData = new LevelData(jsonData);

        foreach (LevelData.ElementPosition elementPosition in levelData.elementPositions)
        {
            elementObjects.Add(Instantiate((GameObject)Resources.Load("Prefabs/" + elementPosition.element, typeof(GameObject)), elementPosition.position, Quaternion.identity));
        }
    }

}
