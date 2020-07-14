using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableElement : MonoBehaviour, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    public GameObject linkedPrefab;
    LE_UIScript uiScript;

    void Awake()
    {
        uiScript = FindObjectOfType<LE_UIScript>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("DraggableElement OnPointerDown called.");
        uiScript.ShowDeleteButton();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("DraggableElement OnDrag called.");
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(cursorPosition.x, cursorPosition.y, -9f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("DraggableElement OnEndDrag called.");
        uiScript.ShowElementPanel();
    }

    public static GameObject InstantiateFromPrefab(GameObject prefab)
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

        return elementInstance;
    }

}


