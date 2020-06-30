using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableElement : MonoBehaviour, IEndDragHandler, IDragHandler
{
    public GameObject linkedPrefab;
    Vector3 cursorPosition;

    public void OnDrag(PointerEventData eventData)
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(cursorPosition.x, cursorPosition.y, 0f);

        //Fix desync issue
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if cursor is above UI, if so:

        // Destroy(this.gameObject);
    }

    public static void InstantiateFromPrefab(GameObject prefab)
    {
        Vector3 initialInstancePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        GameObject elementInstance = Instantiate(prefab, initialInstancePosition, Quaternion.identity);
        elementInstance.layer = 8;

        foreach (GamePlayElement gamePlayElement in FindObjectsOfType<GamePlayElement>())
        {
            Destroy(gamePlayElement);
        }

        DraggableElement draggableElement = elementInstance.AddComponent<DraggableElement>();
        draggableElement.linkedPrefab = prefab;
        
    }

}


