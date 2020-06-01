using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class SaveLevel : MonoBehaviour
{
    List<DraggableElement> placedObjects = new List<DraggableElement>();
    public Button lE_SaveLevelButton;
   
    void Start()
    {
       lE_SaveLevelButton.onClick.AddListener(SaveAsJson);
    }    


    
    public void SaveAsJson()
    {
        placedObjects = FindObjectsOfType<DraggableElement>().ToList();

        var levelData = new LevelData();
                     
        foreach (DraggableElement obj in placedObjects)
        {
            string prefabName = obj.GetComponent<DraggableElement>().linkedPrefab.name;
            Vector2 objPos = obj.transform.position;
            
            
            levelData.elementPositions.Add(new LevelData.ElementPosition { element = prefabName, position = objPos }); 
        }
       


                                                                   
      string json = JsonConvert.SerializeObject(levelData.elementPositions);
      print(json);

        PlayerPrefs.SetString("level1", json);

    }
}


