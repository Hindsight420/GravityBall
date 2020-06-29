using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LE_ElementButton : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        DraggableElement.InstantiateFromPrefab(prefab);
    }
}
