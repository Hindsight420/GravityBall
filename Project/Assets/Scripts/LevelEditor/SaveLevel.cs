using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;


public class SaveLevel : MonoBehaviour
{
    List<DraggableElement> placedObjects = new List<DraggableElement>();
    public Button lE_SaveLevelButton;

    void Start()
    {
        lE_SaveLevelButton.onClick.AddListener(SaveLevelClicked);
    }

    private string ConvertObjectPositionsToJsonData()
    {
        placedObjects = FindObjectsOfType<DraggableElement>().ToList();

        var levelData = new LevelData();

        foreach (DraggableElement obj in placedObjects)
        {
            string prefabName = obj.GetComponent<DraggableElement>().linkedPrefab.name;
            Vector2 objPos = obj.transform.position;


            levelData.elementPositions.Add(new LevelData.ElementPosition { element = prefabName, position = objPos });
        }
        string jsonData = JsonConvert.SerializeObject(levelData.elementPositions);
        return jsonData;
    }

    public void SaveLevelClicked()
    {
        string jsonData = ConvertObjectPositionsToJsonData();
        int highestLevelNumberPlusOne = InputOutput.FindHighestLevelFileNumber() + 1;
        string path = InputOutput.GetLevelPath(highestLevelNumberPlusOne);
        InputOutput.SaveJsonDataToPath(jsonData, path);
        Debug.Log("Saved the level to " + path);
    }
}


