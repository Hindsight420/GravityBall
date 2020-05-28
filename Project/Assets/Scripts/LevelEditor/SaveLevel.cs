using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class SaveLevel : MonoBehaviour
{
    public List<GameObject> placedObjects; // Moet later aangepast worden, is een lijst van objecten, geen prefabs
    public Button lE_SaveLevelButton;
    /* public string prefabName;             //Deze twee staan hier voor placeholder in het SaveLevel object
    public Vector2 objPos;                  */

    void Start()
    {
       lE_SaveLevelButton.onClick.AddListener(SaveAsJson);
    }

    /*
    // Jelle's multivalue dictionary (part 1)
    public SaveLevel(string prefabNameData, Vector2 objPosData)                  //Nieuw soort object "SaveLevel" met inhoud prefabName en objPos
    {
        prefabNameData = prefabName;
        objPosData = objPos;
    }                                                                                   */
    public void SaveAsJson()
    {
        //Zoekt alle GameObjects in de scene met script DraggableElement en plaatst ze in placedObjects
        foreach (GameObject gameObject in FindObjectsOfType<GameObject>())                      
        {
            if (gameObject.GetComponent<DraggableElement>() != null)                            
            {
                  placedObjects.Add(gameObject);               
            }
        }


        //Maakt dictionary met key prefabName en value objPos
        Dictionary<string, Vector2> objects = new Dictionary<string, Vector2>();     // Maakt dictionary "objects" met namen van de gelinkte prefabs + posities
         foreach(GameObject obj in placedObjects)
         {
             string prefabName = obj.GetComponent<DraggableElement>().linkedPrefab.name;
             Vector2 objPos = obj.transform.position;

             objects.Add(prefabName, objPos);
         }

        /*
        //Jelle's multivalue dictionary (part 2)

        Dictionary<string, SaveLevel> objects = new Dictionary<string, SaveLevel>();
        foreach(GameObject obj in placedObjects)
        {
            string instanceName = obj.name;
            prefabName = obj.GetComponent<DraggableElement>().linkedPrefab.name;
            objPos = obj.transform.position;
            SaveLevel instancePrefabPosition = obj.AddComponent<SaveLevel>();

            objects.Add(instanceName, instancePrefabPosition);
            Debug.Log(instanceName + " with prefab " + prefabName + " and position " + objPos + " was added to the dictionary.");
        }


        Debug.Log(bjects)
                                                                                        */
         
       string json = JsonConvert.SerializeObject(objects);     // Maakt een JSON van  dictionary "objects"
       print(json);
    }
}

