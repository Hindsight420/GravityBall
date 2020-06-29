using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class DraggableElement : MonoBehaviour
{

    public GameObject linkedPrefab;

    void OnMouseDrag()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 translationMouseToObject = cursorPosition - transform.position;
        transform.position = new Vector3(cursorPosition.x - translationMouseToObject.x, cursorPosition.y - translationMouseToObject.y, -9f);
    }

    public static void InstantiateFromPrefab(GameObject prefab)
    {
        Vector3 initialInstancePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        GameObject elementInstance = Instantiate(prefab, initialInstancePosition, Quaternion.identity);

        foreach (GamePlayElement gamePlayElement in FindObjectsOfType<GamePlayElement>())
        {
            Destroy(gamePlayElement);
        }

        DraggableElement draggableElement = elementInstance.AddComponent<DraggableElement>();
    }

}


