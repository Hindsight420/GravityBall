using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LE_ElementButton : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    public GameObject prefab;
    GameObject objectInstance;
    DraggableElement draggableElementScript;


    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Destroy(objectInstance);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown called.");
        objectInstance = DraggableElement.InstantiateFromPrefab(prefab);
        draggableElementScript = objectInstance.GetComponent<DraggableElement>();

        eventData.pointerDrag = objectInstance;
        ExecuteEvents.Execute(objectInstance, eventData, ExecuteEvents.initializePotentialDrag);
        ExecuteEvents.Execute(objectInstance, eventData, ExecuteEvents.pointerDownHandler);

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("ElementButton OnDrag called.");
        draggableElementScript.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("ElementButton OnEndDrag called.");
        draggableElementScript.OnEndDrag(eventData);
    }
}
