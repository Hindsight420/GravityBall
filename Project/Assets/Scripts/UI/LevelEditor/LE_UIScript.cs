using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LE_UIScript : MonoBehaviour
{
    static GraphicRaycaster graphicRaycaster;
    static PointerEventData pointerEventData;
    static EventSystem eventSystem;

    private void Start()
    {
        graphicRaycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }

    public static bool IsMouseOverUIElement()
    {
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, raycastResults);

        if (raycastResults.Count > 0)
        {
            return true;
        }
        else { return false; }
    }


    public void OnMainMenuButtonClicked()
    {
        GameManager.GoToMainMenu();
    }





}
