using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableElement : MonoBehaviour
{
    Vector3 cursorPosition;
    Vector3 translationMouseToObject;
    bool mouseIsDown;

     void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mouseIsDown) transform.position = cursorPosition - translationMouseToObject;
    }
    

    void OnMouseDown()
    {
        translationMouseToObject = cursorPosition - transform.position;
        mouseIsDown = true;
    }

    void OnMouseUp()
    {
        mouseIsDown = false;
    }
}

