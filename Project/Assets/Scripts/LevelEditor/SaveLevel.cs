using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class SaveLevel : MonoBehaviour
{
    public List<GameObject> placedObjects; // Moet later aangepast worden, is een lijst van objecten, geen prefabs
    public Button lE_SaveLevelButton;
   
    void Start()
    {
       lE_SaveLevelButton.onClick.AddListener(SaveAsJson);
    }


    public struct PrefabNameAndPosition                                                 // Maakt een custom variable voor de dictionary "objects" key aan.
    {
        public string prefabNameData;
        public Vector2 objPosData;

        public PrefabNameAndPosition(string prefabNameData, Vector2 objPosData)
        {
            this.prefabNameData = prefabNameData;
            this.objPosData = objPosData;
        }
       
    }                                                                                   
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

        /*
        //Maakt dictionary met key prefabName en value objPos
        Dictionary<string, Vector2> objects = new Dictionary<string, Vector2>();     // Maakt dictionary "objects" met namen van de gelinkte prefabs + posities
         foreach(GameObject obj in placedObjects)
         {
             string prefabName = obj.GetComponent<DraggableElement>().linkedPrefab.name;
             Vector2 objPos = obj.transform.position;

             objects.Add(prefabName, objPos);
         }
         */

        //Jelle's multivalue dictionary (part 2)

        Dictionary<string, PrefabNameAndPosition> objects = new Dictionary<string, PrefabNameAndPosition>();                //Maakt dictionary aan met de naam van de instance als key
        foreach(GameObject obj in placedObjects)                                                                            //en de prefabname + positie van het objects als value.
        {
            string instanceName = obj.name;
            string prefabName = obj.GetComponent<DraggableElement>().linkedPrefab.name;
            Vector2 objPos = obj.transform.position;
            PrefabNameAndPosition currentObjectNameAndPosition = new PrefabNameAndPosition(prefabName, objPos);

            objects.Add(instanceName, currentObjectNameAndPosition);
            Debug.Log(instanceName + " with prefabName " + prefabName + " and position " + objPos + " was added to the dictionary. currentObjectNameAndPosition value = " + currentObjectNameAndPosition);
        }
                                                                   
      string json = JsonConvert.SerializeObject(objects);     // Maakt een JSON van  dictionary "objects"
      print(json);
    }
}

