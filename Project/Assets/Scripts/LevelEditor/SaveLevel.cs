using System.Collections.Generic;
using UnityEngine;

public class SaveLevel : MonoBehaviour
{
    public List<GameObject> placedObjects;

    void Start()
    {
        print("sup");
    }

    public void SaveAsJson()
    {
        Dictionary<string, Vector2> objects = new Dictionary<string, Vector2>();
        foreach(GameObject obj in placedObjects)
        {
            string prefabName = obj.GetComponent<DraggableElement>().linkedPrefab.name;
            Vector2 objPos = obj.transform.position;

            objects.Add(prefabName, objPos);
        }

        string json = JsonUtility.ToJson(objects);
        print(json);
    }
}
