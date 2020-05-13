using System.Collections;
using System.Collections.Generic;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
    }
    void Awake()
    {

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    // Update is called once per frame
    void Click()
    {
        int Index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(Index);
        Debug.Log("Hello world!");
    }
}
