using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Reflection;
using UnityEditor;

public class LE_ElementButton : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    public GameObject prefab;
    GameObject elementPreview;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Destroy(elementPreview);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        elementPreview = Instantiate(prefab, new Vector3(eventData.position.x, eventData.position.y, -9f), Quaternion.identity);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        elementPreview.transform.position = new Vector3(cursorPosition.x, cursorPosition.y, -9f);

        //Fix desync issues
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(elementPreview);

        //Check if cursor is above UI. If not:

        DraggableElement.InstantiateFromPrefab(prefab);
    }

}
