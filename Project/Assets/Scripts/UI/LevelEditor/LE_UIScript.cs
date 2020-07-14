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
    public GameObject elementPanel, deleteButton, openElementPanelButton;
    public Button closeMenuButton;

    private void Start()
    {
        graphicRaycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }

    public void OnCloseMenuButtonClick()
    {
        elementPanel.SetActive(false);
        openElementPanelButton.SetActive(true);
    }    

    public void OnOpenElementPanelButtonClick()
    {
        elementPanel.SetActive(true);
        openElementPanelButton.SetActive(false);
        
    }

    public void ShowDeleteButton()
    {
        elementPanel.transform.localScale = Vector3.zero;
        // deleteButton.SetActive(true);
    }

    public void ShowElementPanel()
    {
        elementPanel.transform.localScale = Vector3.one;
        // deleteButton.SetActive(false);
    }

    public static bool IsMouseOverUIElement()
    {
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, raycastResults);

        return (raycastResults.Count > 0);
    }


    public void OnMainMenuButtonClicked()
    {
        GameManager.GoToMainMenu();
    }





}
